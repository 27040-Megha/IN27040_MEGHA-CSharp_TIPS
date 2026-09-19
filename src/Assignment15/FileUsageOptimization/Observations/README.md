# Assignment-15: Working with Files and Streams

## Task 3: Investigate issues in basic file usage

- Identify the issue in the code snippet.
- Modify the code to fix the memory issue.
- Explain how you identified and fixed the issue.

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