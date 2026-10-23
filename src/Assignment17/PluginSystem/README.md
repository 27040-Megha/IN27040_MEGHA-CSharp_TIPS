## Assignment-17: Task 5 - Plugin System
 
 
Implement a plugin system for a simple application. The main application should be able to discover and load plugins (assemblies) at runtime, and call methods on these plugins using Reflection. 
 
---

SecurityInterface.dll

- Contains ISecurity interface.

ISecurity.cs

- Properties: string AlgorithmName
- Methods: string Encrypt(string), string Decrypt(string)

---

CaeserCipherEncryption.dll, MirrorCipherEncryption.dll

- Add SecurityInterface.dll as project reference.
- Create a class CaeserCipherEncryption and MirrorCipher in the respective projects where both the classes implements the ISecurity interface.
- Define all members of the interface explicitly.

---

PluginSystem.exe

- Create a folder called Plugins, Paste the assemblies CaeserCipherEncryption.dll, MirrorCipherEncryption.dll.
- Add SecurityInterface.dll as project reference.
- In Program.cs, load the assemblies from the Plugins folder at Run-time, Create an object for its type.
- Typecast to ISecurity interface member and access its members.

---
