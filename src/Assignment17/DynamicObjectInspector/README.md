## Assignment-17: Task 3 - Dynamic Method Invoker

Implement a method invoker that can call methods on an object dynamically, based on the method name provided as a string.

---

##  Project Structure
```text
DynamicMethodInvoker
│
├── User.cs
|
├── MethodInvoker.cs
│
└── Program.cs
```
---

### User.cs

- Contains property - UserName
- Contains Method - GreetUser()

---

### MethodInvoker.cs

- Contains method to dynamically invoke methods at runtime.

#### InvokeMethod(object instance, string methodName)

- Get Object type using instance.GetType().
- Get the method using instance.GetMethod(methodName).
- Using method.invoke() invoke the method.
`
	method.invoke(instance, parameters)
`
- If the method to be invoked doesn't take any parameters, pass null.
- If there is no specified method with the name, we get Run-time Exception.

---

### Program.cs

- Create object for User and MethodInvoker classes and call InvokeMethod().
---
