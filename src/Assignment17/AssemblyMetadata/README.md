## Assignment-17: Task 1 - Inspect Assembly Metadata
 
 
Display information about the types defined in the assembly, their methods, properties, fields, and event
 
---

### Concepts 

#### Reflections in C#

- Enables developers to inspect and manipulate metadata about types at runtime.
- Inspect an object’s structure (methods, properties, fields, etc.).
- Invoke methods or access properties/fields dynamically.
- Create new instances of types at runtime.
- Work with attributes and metadata.

#### When to use reflection?

- Dynamic Application Behavior
- Testing and Mocking
- Serialization and Deserialization (Eg. JSON File Handling)
- Framework Development (Eg. Dependency Injection rely on reflections to create dynamic objects)

---

Library.dll

- Contains two classes - Book.cs and User.cs

---

AssemblyMetaData.exe

- Loads the Library.dll using Assembly.LoadFrom().
- Gets all types defined in the Library.dll using Assembly.GetTypes().
- Foreach type, gets the metadata using methods - GetFields(), GetProperties(), GetMethods() and GetEvents().

---