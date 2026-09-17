# Assignment-16: C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 

## Task 1: Understanding and Implementing Events and Delegates in C#

Create a simple console application that uses events and delegates to notify the user when an action is performed.  

- Define a delegate, Notify, in a class Notifier that accepts a string message and returns void. 

- Define an event, OnAction, in the same class using the Notify delegate. 

- In the Main method of your console application, create an instance of Notifier. 

- Subscribe to the OnAction event with a method that writes the message to the console. 

- Trigger the OnAction event with a string message and observe the console output. 

---

## Concept

- Delegates: Structure of a method (Like a pointer).
- Events: Allows a class to provide notification to other classes.
- Events use delegates to send notifications.
- Publisher class: Event will be defined in the publisher class and when event is invoked, all the subscribers will get notified.
- Subscriber class: Contains method that will be subscribed to the event.
- When publisher notifies, the subscribed methods will be executed automatically.

---

## Notifier.cs

- Publisher class that has event defined and publishes the notification to its subscribers
- Delegate: void Notify(string message)
- Event: Notify OnAction
- Method: Trigger(string message) - Publishes the notification to all its Subscribers

---

## Program.cs

## Methods: (Subscriber methods)

1. SendWhatsAppNotification(string message) 
2. SendEmailNotification(string message) 

## Main()

- Create Object for Notifier class
- Subscribe SendWhatsAppNotification and SendEmailNotification methods to the event OnAction
- Call Trigger() that publishes notification to its subscribers