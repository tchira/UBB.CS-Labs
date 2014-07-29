// Client sample
#include <windows.h>
#include <stdio.h>
#include <string>

 
int main(int argc, char *argv[])
{
    HANDLE Mailslot;
	HANDLE Mailslotclient;
    DWORD BytesWritten;
	DWORD BytesRead;
    
	
	if ((Mailslotclient = CreateMailslot("\\\\.\\Mailslot\\Myslot2", 0, MAILSLOT_WAIT_FOREVER, NULL)) == INVALID_HANDLE_VALUE)
    {
        printf("Failed to create a mailslot in client %d\n", GetLastError());
        return 0;
    }
	
	
	
	
	char filename[] = "text.txt";
    if ((Mailslot = CreateFile("\\\\.\\Mailslot\\Myslot", GENERIC_WRITE,
        FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL)) == INVALID_HANDLE_VALUE)
    {
        printf("CreateFile failed with error %d\n", GetLastError());
        return 0;
    }
	//write stuff in mailslot
	
	WriteFile(Mailslot, &filename, strlen(filename)*sizeof(int), &BytesWritten, NULL);
	
    printf("Wrote %d bytes\n", BytesWritten);
	
	//read from mailslot after server wrote in it
	int res[26];
	ReadFile(Mailslotclient, &res, 26*sizeof(int), &BytesRead, NULL);
	for ( int i = 0; i < 26; i++)
		printf("%c appears %d times\n",i+97,res[i]);
	
	
    CloseHandle(Mailslot);
	return 0;
}