#include <stdio.h>
#include <windows.h>

int main(int argc, char *argv[])
{
	printf("Creating an instance of a named pipe...\n");
 
    // Create a pipe to send data
    HANDLE pipe1 = CreateNamedPipe("\\\\.\\PIPE\\my_pipe1", PIPE_ACCESS_OUTBOUND, PIPE_TYPE_BYTE|PIPE_WAIT, 
									3, 0, 0, 0, NULL );
	 
	HANDLE pipe2 = CreateNamedPipe("\\\\.\\PIPE\\my_pipe2", PIPE_ACCESS_INBOUND, PIPE_TYPE_BYTE|PIPE_WAIT,
									3, 0, 0, 0, NULL );
	
    // This call blocks until a client process connects to the pipe
    BOOL result1 = ConnectNamedPipe(pipe1, NULL);
	BOOL result2 = ConnectNamedPipe(pipe2, NULL);
	
	char filename[] = "text.txt";

    DWORD numBytesWritten1 = 0;
    result1 = WriteFile(
        pipe1, // handle to our outbound pipe
        &filename, // data to send
        strlen(filename) * sizeof(int), // length of data to send (bytes)
        &numBytesWritten1, // will store actual amount of data sent
        NULL // not using overlapped IO
    );
	
	int res[26];
	DWORD numBytesWritten2 = 0;
	result2 = ReadFile(
		pipe2,
		&res,
		26*sizeof(int),
		&numBytesWritten2,
		NULL
	);
	
	for ( int i = 0; i < 26; i++)
		printf("%c appears %d times\n",i+97,res[i]);
	//printf("Sum even nr: %d, Sum odd nr: %d",mesaj.sumEven,mesaj.sumOdd);
    // Close the pipe (automatically disconnects client too)
    CloseHandle(pipe1);
	CloseHandle(pipe2);
 
    return 0;
}