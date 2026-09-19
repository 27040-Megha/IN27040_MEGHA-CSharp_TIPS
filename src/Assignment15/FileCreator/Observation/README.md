# Assignment-15: Working with Files And Streams

## Subtask in Task-1

## Create your own file of 1 GB using File Write techniques

Method - 1: (Using FileStreams)

- FileStreams open a connection to the file.
- Data will be taken as chunks encoded to byte array and written on files.
- Throughout, the connection will be open, and each chunk will be processed and written to the file.
- Takes less time.
- Best to write data in files as tiny chunks.

Method - 2: (Using Files)

- File write method open the file, writes data to it and then closes the file.
- To write each chunk, File opens the physical file and then writes data to it and again closes.
- Takes more time.
- Best when large data has to be written to file at once.
