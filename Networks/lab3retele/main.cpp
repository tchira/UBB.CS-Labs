#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif

#include "Windows.h"
#include "winsock2.h"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
using namespace std;



#define DEBUG 0
#define BPORT 7777
#define BADDR "172.30.255.255"

struct connection {
    char ip[17];
    char date[13];
    char time[13];
    int lupdate;
};

char errors[1001][100];
connection lista[100];
int nr_conex = 0;
int err_no=0;
SOCKET sock;
struct sockaddr_in saddr;
struct sockaddr_in caddr;
struct sockaddr_in baddr;



void delete_old_entries() {
    for (int i=0; i<nr_conex; i++) {
        if (lista[i].lupdate<-3) {
            for (int j=i; j<nr_conex-1; j++) {
                lista[j] = lista[j+1];
            }
            nr_conex--;
        }
    }
}

void fancy_ip(char ip[]) {
    int a1,a2,a3,a4;
    sscanf(ip,"%d.%d.%d.%d",&a1,&a2,&a3,&a4);
    char r[15];
    sprintf(r,"%03d.%03d.%03d.%03d",a1,a2,a3,a4);
    cout<<r;
}

void print_list() {
    if (DEBUG) return;
    system("cls");
    //cout << string(50, '\n');
    cout << "---Clients list---\n";
    for(int i=0; i<nr_conex; i++) {
        fancy_ip(lista[i].ip);
        cout<<" "<<lista[i].time<<" "<<lista[i].date<<"\n";
    }
    cout << "---Errors list---\n";
    for(int i=0; i<err_no; i++) {
        cout<<errors[i]<<"\n";
    }
}

void mark_sent_query() {
    for (int i=0; i<nr_conex; i++) {
        lista[i].lupdate--;
    }
    delete_old_entries();
}

void update_date(char* ip_str, char* date) {
    for(int i=0; i<nr_conex; i++) {
        if (strcmp(ip_str,lista[i].ip)==0) {
            strcpy(lista[i].date,date);
            lista[i].lupdate = 1;
            return;
        }
    }
    strcpy(lista[nr_conex].ip,ip_str);
    strcpy(lista[nr_conex].date,date);
    strcpy(lista[nr_conex].time,"00:00:00\0");
    lista[nr_conex].lupdate = 1;
    nr_conex++;
}

void update_time(char* ip_str, char* time) {
    for(int i=0; i<nr_conex; i++) {
        if (strcmp(ip_str,lista[i].ip)==0) {
            strcpy(lista[i].time,time);
            lista[i].lupdate = 1;
            return;
        }
    }
    strcpy(lista[nr_conex].ip, ip_str);
    strcpy(lista[nr_conex].time, time);
    strcpy(lista[nr_conex].date, "00:00:0000\0");
    lista[nr_conex].lupdate = 1;
    nr_conex++;
}

void add_error(char* ip_str, char* recvbuff) {
    err_no++;
    sprintf(errors[err_no],"IP: %s   Text: %.20s",ip_str,recvbuff);
}

void CALLBACK sendDateQuery(UINT wTimerID, UINT msg,
    DWORD dwUser, DWORD dw1, DWORD dw2) {
    char * str = "DATEQUERY\0";
    if (sendto(sock,str,strlen(str)+1,0,(sockaddr *)&baddr,sizeof(caddr))<0) {
        cout<<"Error broadcasting DATEQUERY!\n";
    }
    //mark_sent_query();
}

void CALLBACK sendTimeQuery(UINT wTimerID, UINT msg,
    DWORD dwUser, DWORD dw1, DWORD dw2) {
    char *str = "TIMEQUERY\0";
    if (sendto(sock,str,strlen(str)+1,0,(sockaddr *)&baddr,sizeof(caddr))<0) {
        cout<<"Error broadcasting TIMEQUERY!\n";
    }
    mark_sent_query();
}


int main(int argc, char *argv[])
{
    WSADATA wsaData;
    WSAStartup(MAKEWORD(2,2), &wsaData);
    int err;

    sock = socket(AF_INET,SOCK_DGRAM,0);
    if (sock<0) {
        cout<<"Error creating socket!";
        closesocket(sock);
        exit(1);
    }

    char optval = 'a';
    if(setsockopt(sock,SOL_SOCKET,SO_BROADCAST,&optval,sizeof(optval)) < 0) {
        cout<<"Error in setting Broadcast option";
        closesocket(sock);
        exit(1);
    }

    int len = sizeof(struct sockaddr_in);

    saddr.sin_family       = AF_INET;
    saddr.sin_port         = htons(BPORT);
    saddr.sin_addr.s_addr  = INADDR_ANY;

    if (bind(sock,(sockaddr*)&saddr, sizeof (saddr)) < 0) {
        cout<<"Error in Binding: "<<WSAGetLastError();
        closesocket(sock);
        exit(1);
    }
    //SERVER INITIALIZED-----
    baddr.sin_family       = AF_INET;
    baddr.sin_port         = htons(BPORT);
    baddr.sin_addr.s_addr  = inet_addr(BADDR);

    cout<<"Server initialized!\n";
    MMRESULT ev1 = timeSetEvent(3000,10,sendTimeQuery,NULL,TIME_PERIODIC);
    MMRESULT ev2 = timeSetEvent(10000,10,sendDateQuery,NULL,TIME_PERIODIC);

    char recvbuff[3000];
    int recvbufflen = 3000;
    char resp[300];
	SYSTEMTIME ttime;
	char *ip_str;
	char strt[100];
	int dd,mm,yy,hh,ss;

    while (1) {
        if (DEBUG) cout<<"Waiting...";
        err = recvfrom(sock,recvbuff,recvbufflen,0,(sockaddr *)&caddr,&len);
        if (err<0) {
            cout<<"Error receiving! "<<WSAGetLastError()<<"\n";
            closesocket(sock);
            exit(0);
        }
        ip_str = inet_ntoa(caddr.sin_addr);
        if (DEBUG) cout<<"Received (from "<<ip_str<<"): "<<recvbuff<<"\n";


        GetSystemTime(&ttime);

        if (strstr(recvbuff,"TIMEQUERY") != NULL) {
            sprintf(resp,"TIME %02d:%02d:%02d",ttime.wHour,ttime.wMinute,ttime.wSecond);
            if (sendto(sock,resp,strlen(resp)+1,0,(sockaddr *)&caddr,sizeof(caddr))<0) {
                cout<<"Error sending!\n";
                closesocket(sock);
                return 0;
            }
        }

        else if (strstr(recvbuff,"DATEQUERY") != NULL) {
            sprintf(resp,"DATE %02d:%02d:%04d",ttime.wDay,ttime.wMonth,ttime.wYear);
            if (sendto(sock,resp,strlen(resp)+1,0,(sockaddr *)&caddr,sizeof(caddr))<0) {
                cout<<"Error sending!\n";
                closesocket(sock);
                return 0;
            }
        }

        else if (strstr(recvbuff,"DATE ") != NULL) {
            if (sscanf(recvbuff,"DATE %d:%d:%d",&dd,&mm,&yy)==3) {
                sprintf(strt,"%02d:%02d:%04d",dd,mm,yy);
                update_date(ip_str,strt);
            }
            else add_error(ip_str,recvbuff);
            print_list();
        }

        else if (strstr(recvbuff,"TIME ") != NULL) {
            if (sscanf(recvbuff,"TIME %d:%d:%d",&hh,&mm,&ss)==3) {
                sprintf(strt,"%02d:%02d:%02d",hh,mm,ss);
                update_time(ip_str,strt);
            }
            else add_error(ip_str,recvbuff);
            print_list();
        }

        else add_error(ip_str,recvbuff);
    }

    timeKillEvent(ev1);
    timeKillEvent(ev2);
    closesocket(sock);
    WSACleanup();
    return 0;
}

