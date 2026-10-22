## Assignment-17: Task 2 - Dynamic Object Inspector

Take an object as input, display its properties and their current value and also allow users to change values at run-time.

---

##  Project Structure
```text
DynamicObjectInspector
│
├── Product.cs
|
├── ObjectInspector.cs
│
└── Program.cs
```
---

### Product.cs

- Contains properties- ProductId, ProductName, Price

---

### ObjectInspector.cs

- Contains method to dynamically handle objects at runtime.

#### DisplayProperties(object instance)

- Gets the type of instance using GetType().
- Gets the properties of the instance using type.GetProperties().
- Displays each property and their value using property.GetValue(instance).

#### UpdateProperties(object instance, string propertyName, object newValue)

- Get the type of instance and the specific PropertyInfo to update using type.GetProperty(propertyName).
- Using property.setvalue(instance, newValue), update the value of property at run-time.

---

### Program.cs

- Create object for Product and ObjectInspector classes.
- Call DisplayProperties() to display the current value of the product object.
- Get a valid price value to update project object at run-time from the user and call UpdateProperties().

---
