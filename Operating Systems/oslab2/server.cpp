// Server sample
#include <windows.h>
#include <stdio.h>
 
int main(void)
{
    HANDLE Mailslot;
	HANDLE Mailslotclient;
    char buffer[128];
	
    DWORD NumberOfBytesRead;
	DWORD BytesWritten;
 
    // Create the mailslot to read from
    if ((Mailslot = CreateMailslot("\\\\.\\Mailslot\\Myslot", 0, MAILSLOT_WAIT_FOREVER, NULL)) == INVALID_HANDLE_VALUE)
    {
        printf("Failed to create a mailslot %d\n", GetLastError());
        return 0;
    }
 
   ReadFile(Mailslot, &buffer, 127*sizeof(char), &NumberOfBytesRead, NULL);
   
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
	
	
	if ((Mailslotclient = CreateFile("\\\\.\\Mailslot\\Myslot2", GENERIC_WRITE,
        FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL)) == INVALID_HANDLE_VALUE)
	{
		printf("CreateFile failed with error %d\n", GetLastError());
		return 0;
	}

	WriteFile(Mailslotclient, &freq, 26*sizeof(int), &BytesWritten, NULL);
	CloseHandle(Mailslotclient);

	return 0;
}
 