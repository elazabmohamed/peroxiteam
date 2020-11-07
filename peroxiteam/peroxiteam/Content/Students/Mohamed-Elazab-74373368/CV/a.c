#include<stdio.h>
#include<pthread.h>
#include<unistd.h>
#include<stdlib.h>

void *iplik1()
{
printf("Merhaba\n");
}

void *iplik2()
{
sleep(10);
printf("dunya\n");
}
int main()
{
pthread_t t1,t2;
pthread_create(&t1, NULL, iplik1, NULL);
pthread_create(&t2, NULL, iplik2, NULL);
pthread_join(&t1, NULL);
pthread_join(&t2, NULL);
pthread_exit(NULL);
return 0;
}
