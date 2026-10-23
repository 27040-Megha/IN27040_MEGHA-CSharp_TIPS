## Assignment-17: Task 7 - Serialization API
 
Implement a simple serialization API using Reflection and then identify its limitations and rewrite it using Reflection.Emit.
 
---

```text
SerializationAPI
│
├── Printer.cs
|
├── ReflectionSerializer.cs
|
├── EmitSerializer.cs
│
└── Program.cs
```

### Printer.cs

- Contains a private field bool _isOn and a property string MachineName.

---

### ReflectionSerializer.cs

#### Method - string Serialize(object objectToSerialize)

- Gets the field, its current value and appends it to the StringBuilder.
- Similarly does for properties also.
- Returns the StringBuilder as string.

#### Limitations of using Reflections for Serialization

- Reflection has to check the security rules, permissions, and internal details of the class every single time it reads a field.
- This slows down the performance.
---

### EmitSerializer.cs

#### Method - Func<Printer, string> CreateSerializeMethod()

- Creates a Dynamic Method, and uses Machine IL code to serialize objects.
- Using string.Format, it takes the value of properties and fields and combine it as a string.
- Then it compiles the instructions and returns it as a delegate that accepts a Printer object and returns a string output.

#### Advantages of Reflections.Emit

- Reflection.Emit uses reflection only once (when compiling the serializer delegate initially).
- Once it translates the field paths into direct Intermediate Language (IL) instructions, it bypasses the reflection engine completely during subsequent executions.
- This makes the code to run at CPU's speed.

---

### Program.cs

- Using stopwatch, measures the time taken to serialize objects to strings in both the cases.

---