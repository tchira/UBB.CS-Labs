#include <stdio.h>
#include <windows.h>
int main(int argc, char *argv[])
{
    printf("Connecting to pipe...\n");
 
    // Open the named pipe
    HANDLE pipe1 = CreateFile("\\\\.\\PIPE\\my_pipe1", GENERIC_READ,FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, NULL );
	HANDLE pipe2 = CreateFile("\\\\.\\PIPE\\my_pipe2", GENERIC_WRITE,FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL );
    
	if (pipe1 == INVALID_HANDLE_VALUE || pipe2 == INVALID_HANDLE_VALUE ) 
	{
        printf("Failed to connect to pipe.\n");
        // look up error code here using GetLastError()
        return 1;
    }
	 
	
	
    // The read operation will block until there is data to read
    char buffer[128];
    DWORD numBytesRead1 = 0;
    BOOL result1 = ReadFile
	(
        pipe1,
        buffer, // the data from the pipe will be put here
        127 * sizeof(char), // number of bytes allocated
        &numBytesRead1, // this will store number of bytes actually read
        NULL 
    );
	
	FILE* f = fopen(buffer,"r");
	if ( f == NULL )
	{
		printf("The file doesn't exist!\n");
		return 1;
	}
	char c;
	int freq[26] = {0};
	
	while ( c != EOF )
	{
		c = fgetc(f);
		if ( c >= 'a' && c <= 'z' )
			freq[c-'a']++;
	}		
	
	BOOL result2 = ConnectNamedPipe(pipe2, NULL);
	
	DWORD numBytesWritten2 = 0;
    result2 = WriteFile(
        pipe2, // handle to our outbound pipe
        &freq, // data to send
        256*sizeof(int), // length of data to send (bytes)
        &numBytesWritten2, // will store actual amount of data sent
        NULL 
    );
 
    // Close our pipe handle
	CloseHandle(pipe1);
    CloseHandle(pipe2);

 
    return 0;
}