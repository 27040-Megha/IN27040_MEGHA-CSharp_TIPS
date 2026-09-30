# Assignment-15: Working with Files And Streams

## Task-1:  Implement a File Data Processor

## 1. Compare the difference between using FileStream and BufferedStream

Using FileStream

- Data is read as a chunk of size 4096 bytes from 1GB file.
- The Chunk data will be stored in a byte[] buffer each time until End Of File is reached.
- So, to completely read file as chunk using FileStream, the disk has to be hitted each time.
- To read 1GB data as a chunks of 4096 bytes, number of times the disk is hitted will be 262145.

Using BufferedStream

- First we have to open a FileStream.
- Using BufferedStream, we fetch 1MB of Data from file and have it in the BufferedStream.
- From the BufferedStream, we can fetch data as tiny chunks of 4096 bytes.
- But this time, the chunk data will be fetched from BufferedStream and not from the file.
- In this way, To read 1GB data as a chunks of 4096 bytes with a BufferedStream (holding 1 MB of data), number of times the disk is hitted will be 1025.

---

## Takeaway

- To read data of large chunk size, FileStreams is a better choice.
- To read data of tiny chunk size, BufferedStream is a better choic.

Execution time difference:

Time taken to read files using FileStreams: 00:00:03.7615073

Time taken to read files using BufferedStreams: 00:00:00.4650206

---

## 2. Implement a method to convert data read from file to UpperCase

- Takes byte array, encode to string.
- Convert to Uppercase.
- Return the processed data as byte array.

---

## 3. Use MemoryStream to buffer the data before writing it to the file

- MemoryStream reads and writes data directly to system's RAM.
- It is temporary, virtual file that lives in memory and disappears as program ends.
- Here, 
	i.   Open MemoryStream
	ii.  Open FileStream - opens connection to the file in Open mode, with Read access.
	iii. Open BufferedStream and read 1 MB of data from FileStream.
	iv.  Read data as chunks of 4096 bytes and store in byte[] buffer.
	v.   Process the data - Convert it to UpperCase.
	vii. Write it to the MemoryStream (System's RAM).
- The above process is done until EOF is reached (Processes and writes 1 GB of data to memory).
- Once all 1 GB data is written to memory.
- Close FileStream and BufferedStream.
- Again open a FileStream with Create Mode and write Access.
- From MemoryStream, copy the complete data to a new file.

---