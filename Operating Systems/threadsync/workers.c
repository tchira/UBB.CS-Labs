#include <stdio.h>
#include <pthread.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <unistd.h>
#include <semaphore.h>

typedef struct {
    float value;
    int worker;
    struct lem* next;
} elem;

//global variables
elem* head;
pthread_mutex_t mutex;
pthread_cond_t cond;
pthread_rwlock_t rwlock;
int counter;
int listLength;
sem_t sem;

void* worker(void* arg){
    pthread_t id = pthread_self();
    int orderNo = *(int*)arg;
    elem* current = head;

    do {
        //usleep(200);
        sem_wait(&sem);
        pthread_rwlock_rdlock(&rwlock);
        if (current->worker == orderNo){
            if (current->value >= 2) {
                current->value = sqrt(current->value);
                printf("In thread %lu: value: %4.3f, worker: %d\n",
                        id, current->value, current->worker);
            } else {
                //go to the next element if the current one is < 2
                pthread_rwlock_unlock(&rwlock);
                sem_post(&sem);
                current = (elem*) current->next;
                continue;
            }
            //count the current position as eligible for deletion
            if (current->value < 2){
                pthread_mutex_lock(&mutex);
                counter++;
                //signal the main
                if (counter == 5 ||
                        (listLength < 5 && counter == listLength)){
                    pthread_cond_signal(&cond);
                    counter = 0;
                }
                pthread_mutex_unlock(&mutex);
            }
        }
        current = (elem*) current->next;
        pthread_rwlock_unlock(&rwlock);
        sem_post(&sem);
    } while(listLength != 0);

    return NULL;
}


void printList(){
    printf("\nList after deletion:\n");
    elem* current = head;
    int i = 0;
    do {
        printf("Element: value: %4.3f, worker: %d\n", current->value,
                current->worker);
        i++;
        current = (elem*) current->next;
    } while(current != head);
    printf("\n");
}


int main(int argc, char* argv[]){
    if (argc != 3){
        perror("Invalid number of args");
        exit(1);
    }
    //get arguments
    int elements = atoi(argv[1]);
    int workers = atoi(argv[2]);

    //initialize sync vars
    pthread_rwlockattr_t attr;
    pthread_rwlockattr_setkind_np(&attr,
            PTHREAD_RWLOCK_PREFER_WRITER_NONRECURSIVE_NP);
    pthread_mutex_init(&mutex, NULL);
    pthread_cond_init(&cond, NULL);
    sem_init(&sem, 0, 3);
    pthread_rwlock_init(&rwlock, &attr);
    counter = 0;
    listLength = elements;
    srand(time(NULL));

    printf("Elements: %d, workers: %d\n", elements, workers);

    //init first element of the list
    head = (elem*) malloc(sizeof(elem));
    head->value = rand() % 100;
    head->worker = 0;

    //create the list
    elem* prev;
    prev = head;
    for (int i = 1; i < elements; i++){
        elem* e = (elem*) malloc(sizeof(elem));
        e->value = rand() % 100;
        e->worker = i % workers;
        prev->next = (void*) e;
        prev = e;
        if (i == elements - 1){
            e->next = (void*) head;
        }
    }

    //display the list
    elem* current = head;
    do {
        printf("Elemement: value: %4.3f, worker: %d\n", current->value, current->worker);
        current = (elem*) current->next;
    } while(current != head);

    //create threads
    pthread_t threadArray[workers];
    int threadOrder[workers];
    for (int i = 0; i < workers; i++){
        threadOrder[i] = i;
        if (pthread_create(&threadArray[i], NULL,
                    worker, &threadOrder[i]) != 0){
            perror("Cannot create thread");
            exit(1);
        }
    }

    while(listLength != 0) {
        //wait for signal and lock the list
        pthread_mutex_lock(&mutex);
        while (pthread_cond_wait(&cond, &mutex) != 0);
        pthread_mutex_unlock(&mutex);
        pthread_rwlock_wrlock(&rwlock);
        //printf("Here 2\n");
        //delete all elements smaller than 2
        elem* current = head;
        elem* lastEl;
        while(current->next != (void*) head) {
            elem* prev = current;
            current = (elem*) current->next;
            if (current->value < 2) {
                prev->next = current->next;
                free(current);
                current = prev;
                listLength--;
            }

            if (current->next == (void*) head){
                lastEl = current;
            }
        }
        if (head->value < 2){
            if (listLength > 1){
                lastEl->next = head->next;
                free(head);
                head = (elem*) lastEl->next;
                listLength--;
            } else {
                free(head);
                listLength--;
            }
        }

        //display the list and unlock
        printList();
        pthread_rwlock_unlock(&rwlock);
    }

    //join the threads
    for (int i = 0; i < workers; i++){
        if (pthread_join(threadArray[i], NULL) !=0){
            perror("Cannot join thread");
            exit(1);
        }
    }

    //release resources
    pthread_mutex_destroy(&mutex);
    pthread_cond_destroy(&cond);
    pthread_rwlock_destroy(&rwlock);
    pthread_rwlockattr_destroy(&attr);
    sem_destroy(&sem);

    return 0;
}
