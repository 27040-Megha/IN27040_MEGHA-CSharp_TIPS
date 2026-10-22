## Assignment-17: Task 4 - Dynamic Type Builder
 
 
Create a dynamic type builder that can define a new class at runtime, with properties and methods defined by the user.
 
---

### Steps

1. Build assembly using AssemblyBuilder.
2. Build module using ModuleBuilder.
3. Create a class using TypeBuilder.
4. Add properties and methods to the class.
5. Create an instance by creating the type of class first using CreateType and then by using Activator.CreateInstance(type) to access properties and methods of the class.

---

#### 1. Build assembly using AssemblyBuilder.

- Using AssemblyBuilder.DefineDynamicAssembly(), build an assembly named "UserAssembly".
- AssemblyBuilderAccess - There are 2 types Run, RunAndCollect, 
- Run: The dynamic assembly can be executed, but not saved.
- RunAndCollect: The dynamic assembly will be automatically unloaded and its memory reclaimed, when it's no longer accessible.

---

#### 2. Build module using ModuleBuilder.

- Using DefineDynamicModule(), build a module named "UserModule".

---

#### 3. Create a class using TypeBuilder.

`module.DefineType("User", TypeAttributes.Public | TypeAttributes.Class);`

- A public class named User will be created.

---

#### 4. Add properties and methods to the class.

- For creating properties and methods, we directly write in the Intermediate Language code using Reflections.Emit as .NET engine does not understand C# code at run-time.
- But for Creating an assembly, a module, a class, a property definition, or a field definition , we don't use Reflections.Emit() because these are just setting up structural blueprints.
- While a method body or a property accessor (the get and set blocks) contains executable instructions.
- The .NET execution engine (CLR) can only execute raw Intermediate Language instructions. Therefore, you must open an ILGenerator and use Emit to physically write the step-by-step processor instructions.

##### Properties:

- Properties are just private fields with get and set methods.
- Using DefineField(), create a private backing field for the property (Example: _username)
- Using DefineProperty(), create a public property of any type (Example: public string UserName).
- Using DefineMethod(), create getters and setters methods for the property.
- We define methods by using the Intermediate code using GetILGenerator().
- Emit() pushes the specified instruction to the stream of instructions (.NET runtime uses to execute code directly).
- Getters: 
	- Define getter method with the name get_propertyName, with return type as the type of property using DefineMethod().
	- Only one argument that points to this (OpCodes.Ldarg_0) which is the current value of the property.
	- By using OpCodes.Ldfld, the current value in the stack will be loaded.
- Setters:
	- Define setter method with the name set_propertyName, with return type as void using DefineMethod().	
	- There will be two arguments OpCodes.Ldarg_0 (this), OpCodes.Ldarg_1 (new value to be stored).
	- By using OpCodes.Stfld, the value stored in the pointer will be replaced.
- Using property.SetGetMethod(getter) and property.SetSetMethod(setter), set these MethodBuilder objects to the properties.

##### Methods:

- Create a Intermediate Code object using GetILGenerator.
- Define method using DefineMethod() with method name and return type.
- In the code, I have created a method named CreateUser that returns a string "User account created successfully".
- OpCodes.Ret - Returns from the current method with the value returned from the method

---

#### 5. Create an instance by creating the type of class first using CreateType and then by using Activator.CreateInstance(type) to access properties and methods of the class.

- Create a the type of object using CreateType.
- Create an instance using Activator.CreateInstance(instanceType) at run-time.
- Using the property's name and method's name, access them.

---

#### Disadvantage of using Reflections for DynamicTypeBuilder

- We have to know the name of the property or method exactly to access them at run-time.
- Else, the application will crash.

---