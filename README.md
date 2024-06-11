# TodoistNotifications

**TodoistNotifications** is a project for me to learn the basics about parsing and making API requests in C#. 

## Status

This project is a **work in progress**.

## Overview

Todoist has a push notification feature, but it's locked behind a subscription service. They offer [use of their API](https://developer.todoist.com/) for free, however. I thought this would be an exellent opportunity to learn some practical integration skills in C#.

My goal is to create a program that periodically checks my tasks and sends me an email via [SendGrid](https://sendgrid.com/en-us/solutions/email-api) if any tasks are approaching their due date.

## Learning objectives

I have a few learning objectives for this project:

| Learning objective                | What I've learned                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| --------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| How to make an API request in C#. | I learned how to use the `HttpClient` class and the `HttpRequestMessage` class to create API request messages. This was a matter of learning the syntax in C#, as I've created several integration scripts in Python.                                                                                                                                                                                                                                                                          |
| How to read an API request in C#. | I learned how to use the Newtonsoft.Json library to deserialize JSON and create multiple objects based on C# classes I write to match the structure of the JSON. I also learned how to use attributes to properly map class property names to the value names in the JSON from the API.                                                                                                                                                                                                        |
| Properly storing credentials.     | I learned best practices for storing sensitive credentials as environment variables using `Environment.GetEnvironmentVariable`. I initially had this set up as a private (added to .gitignore) directory containing methods with variables holding the sensitive information, but I learned that this was a bad practice. I considered using a JSON configuration file to store the data, but I decided to use environment variables given how little these values would be changed by anyone. |
| Handing string vs datetime dates  | I learned how to parse date strings to turn them into DateTime objects. The way I'm currently doing it isn't perfect, as it wouldn't be able to handle any date input, but it should be fine as long as the Todoist API doesn't change the formatting of its dates.                                                                                                                                                                                                                            |

## Accidental learning

I also learned a few things through trial and error along the way.

| Accidental learning                                      | What I've learned                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| -------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Learning to critically look at every part of the program | I was experiencing an issue where tasks weren't being slotted into their correct buckets. The program wasn't organizing tasks due within 24 hours correctly. After much trial and error and checking to make sure my logic was solid, I used some advice from the internet and changed my payload building from simple string concatenation to using the StringBuilder() class. This immediately fixed the problem. I suspect there was some sort of issue with threads in the string concatenation process that StringBuilder() solved. Valuable lesson is to check all aspects of code, even if something doesn't seem pertinent, because I didn't think at all that the string concatenation could be causing the problem. |
 
## Improvements (to do)

| Improvement (to do)          | Description                                                                                                                          |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| Error handling               | Right now, there is very little in the way of gracefully catching exceptions                                                         |
| Build out logic for checking | This script runs when it runs. My goal is to make it a program that continuously runs, giving me continuous access to notifications. |

## Documentation

This documentation goes through each directory containing code and provides a high-level description of its purpose.

### `Helpers`

The `Helpers` folder contains files that contain classes that interact and process various types of data. 

| File              | Description                                                                                                                                                                                                                                                    |
| ----------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Helpers/Json.cs` | Contains the class `Helpers.Json`. This class contains methods for processing JSON. The most important method here is `DeserializeJson()`, which deserializes a JSON string into a provided object using the Newtonsoft.Json library.                          |
| `Helpers/Time.cs` | Contains the class `Helpers.Time`. This class contains methods for processing and evaluating datetime values.  The most important method here is `ConvertDateStringToDateTime`, which uses `DateTime.Parse` to turn a string date time into a DateTime object. |

### `Models`

The `Models` folder contains files that define the data structures of the program.

| File                    | Description                                                                                                                                                                                                                                                                                                                                                                                                      |
| ----------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Models/Task.cs`        | Contains classes that define the data structure of a task, as defined by the [Todoist API](https://developer.todoist.com/rest/v2/#tasks). The contained class `Models.Task` represents the data structure of the overarching task. The class `Models.TaskDue` represents the data structure of the nested task due date. These classes are used when deserializing JSON from the Todoist API into objects in C#. |
| `Models/TaskList.cs`    | Contains a class used for creating a list of tasks. The list of tasks is inserted into the email as part of the message payload. A list of tasks is created for each level of urgency, defined in `TaskUrgency.cs`.                                                                                                                                                                                              |
| `Models/TaskUrgency.cs` | Contains static variables that defines levels of urgency of tasks based on how many hours away the due date is.                                                                                                                                                                                                                                                                                                  |

### `Private`

The `Private` folder contains methods that give access to sensitive connection strings stored as environment variables.

| File                     | Description                                                                                                                              |
| ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| `Private/Credentials.cs` | Contains methods that access the connection strings for the Todoist API and the SendGrid API. These are stored as environment variables. |
| `Private/Email.cs`       | Contains methods that access the defined sender and recipient of any emails sent via the SendGrid API.                                   |

### `Services`

The `Services` folder contains methods for interacting with the Todoist API and the SendGrid API.

| File                   | Description                                                  |
| ---------------------- | ------------------------------------------------------------ |
| `Services/SendGrid.cs` | Contains a method for sending an email via the SendGrid API. |
| `Services/Todoist.cs`  | Contains a method for retrieving tasks via the Todoist API.  |

### `Program.cs`

The entry point of the program. This file contains the class `Program`, which has two methods:

- `MainAsync()` - Runs the logic of the program.
- `Main()` - Runs the MainAsync() function and waits for it to complete.