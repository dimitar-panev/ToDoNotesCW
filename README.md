# ToDoNotesCW - Simple To-Do List Application

This C# code implements a basic to-do list application using Windows Forms. It allows users to add tasks, mark them as completed, save notes for tasks, mark tasks for deletion, and delete tasks.
This Application is part of a course work that I had to do on Data Structures and Algorithms.

## Overview

The application uses several data structures to manage tasks:

-   `_tasks`: A `Dictionary<string, TaskItem>` to store task details. The key is the task name (string), and the value is a `TaskItem` object containing the task's status and notes.
-   `_taskList`: A `List<string>` to maintain the order in which tasks were added.
-   `_markedTasks`: A `HashSet<string>` to keep track of tasks that the user has marked for deletion.
-   `_taskStack`: A `Stack<string>` to store task names in a Last-In, First-Out (LIFO) manner.
-   `_taskQueue`: A `Queue<string>` to store task names in a First-In, First-Out (FIFO) manner.

A `Timer` is used to update the displayed date and time.

## Code Structure

### `Form1` Class (inherits from `Form`)

This class contains the main logic and UI event handling for the application.

#### Member Variables:

-   `_tasks`: Stores task details (name, status, notes).
-   `_taskList`: Keeps track of the order tasks were added.
-   `_markedTasks`: Stores tasks marked for deletion.
-   `_timer`: Used to periodically update the date and time display.
-   `_isEventHandlersInitialized`: A boolean to track if event handlers have been initialized (currently not actively used).
-   `_taskStack`: Stores task names in a stack (LIFO).
-   `_taskQueue`: Stores task names in a queue (FIFO).

#### Constructor (`Form1()`):

-   Calls `InitializeComponent()`: Sets up the UI elements defined in the form designer.
-   Calls `InitializeEvents()`: Intended for initializing event handlers (currently empty).
-   Calls `InitializeTimer()`: Sets up and starts the timer for updating the date and time.
-   Calls `UpdateDateTimeAndUser()`: Updates the initial display of date, time, and user.

#### Methods:

-   `InitializeTimer()`: Creates a `Timer` that ticks every second and calls `UpdateDateTimeAndUser()`.
-   `UpdateDateTimeAndUser()`: Updates the `dateTimeLabel` and `userLabel` with the current UTC time and a hardcoded username.
-   `InitializeEvents()`: Currently an empty method for initializing event handlers.
-   `addButton_Click(object sender, EventArgs e)`: Handles the click event of the "Add" button.
    -   Gets the text from the `taskInput` textbox.
    -   Validates the input (not empty, not "Enter Task", not a duplicate).
    -   Creates a new `TaskItem` with "Pending" status and empty notes.
    -   Adds the task to `_tasks`, `_taskList`, `_taskStack`, and `_taskQueue`.
    -   Refreshes the task display and all notes display.
    -   Clears the `taskInput` textbox.
-   `saveNotesButton_Click(object sender, EventArgs e)`: Handles the click event of the "Save Notes" button.
    -   Gets the selected task name.
    -   If a task is selected, updates its notes in the `_tasks` dictionary with the text from `notesInput`.
    -   Refreshes the all notes display and shows a confirmation message.
    -   Clears the `notesInput` textbox.
-   `toggleStatusButton_Click(object sender, EventArgs e)`: Handles the click event of the "Toggle Status" button.
    -   Gets the selected task name.
    -   If a task is selected, toggles its status between "Pending" and "Completed" in the `_tasks` dictionary.
    -   Refreshes the task display and the selected task details.
-   `taskDisplay_SelectedIndexChanged(object sender, EventArgs e)`: Handles the event when the selected item in the `taskDisplay` listbox changes.
    -   Updates the displayed details for the newly selected task.
    -   Updates the `markCheckBox` state based on whether the selected task is in `_markedTasks`.
-   `deleteButton_Click(object sender, EventArgs e)`: Handles the click event of the "Delete" button.
    -   Gets the selected task name.
    -   If a task is selected, removes it from `_tasks`, `_taskList`, and `_markedTasks`.
    -   Creates new `_taskStack` and `_taskQueue` without the deleted task.
    -   Refreshes the task display, all notes display, and selected task details.
-   `markCheckBox_CheckedChanged(object sender, EventArgs e)`: Handles the checked state change of the `markCheckBox`.
    -   Gets the selected task name.
    -   Adds or removes the selected task from the `_markedTasks` hash set based on the checkbox state.
-   `deleteMarkedButton_Click(object sender, EventArgs e)`: Handles the click event of the "Delete Marked" button.
    -   Iterates through the `_markedTasks`.
    -   Removes each marked task from `_tasks` and `_taskList`.
    -   Creates new `_taskStack` and `_taskQueue` without the marked tasks.
    -   Clears `_markedTasks` and refreshes the displays.
-   `UpdateTaskDisplay()`: Clears and repopulates the `taskDisplay` listbox with the task names and their statuses from `_taskList` and `_tasks`.
-   `UpdateSelectedTaskDetails()`: Updates the `statusLabel` and `notesInput` with the details of the currently selected task.
-   `UpdateAllNotesDisplay()`: Clears and repopulates the `allNotesDisplay` textbox with the notes of all tasks.
-   `GetSelectedTask()`: Returns the name of the currently selected task from the `taskDisplay` listbox.
-   `Button_MouseEnter(object sender, EventArgs e)`: Handles the mouse enter event for buttons to change their background color for a hover effect.
-   `Button_MouseLeave(object sender, EventArgs e)`: Handles the mouse leave event for buttons to revert their background color.
-   `OnFormClosing(FormClosingEventArgs e)`: Overrides the form's closing event to stop and dispose of the `_timer`.

### `TaskItem` Class

Represents a single to-do task with the following properties:

-   `Status`: A string indicating the task's status (e.g., "Pending", "Completed").
-   `Notes`: A string containing any notes associated with the task.

The constructor `TaskItem(string status, string notes)` initializes these properties.

## Notes for Beginners

-   **Namespaces (`using System;`, etc.):** These lines import collections of pre-written code that provide various functionalities (e.g., handling text, collections, graphics, UI elements).
-   **Classes (`public partial class Form1 : Form`, `public class TaskItem`):** These are blueprints for creating objects. `Form1` defines the main window of the application, and `TaskItem` defines a single to-do task.
-   **Variables (`private readonly Dictionary<string, TaskItem> _tasks;`, etc.):** These are used to store data. `private` means they can only be accessed from within the `Form1` class. `readonly` means their value can only be set during initialization (in the constructor or declaration).
-   **Data Structures (`Dictionary`, `List`, `HashSet`, `Stack`, `Queue`):** These are ways to organize and store collections of data, each with different characteristics and uses.
    -   **Dictionary:** Stores key-value pairs (like a phonebook).
    -   **List:** An ordered collection that can grow or shrink.
    -   **HashSet:** A collection of unique items.
    -   **Stack:** Follows the Last-In, First-Out (LIFO) principle (like a stack of plates).
    -   **Queue:** Follows the First-In, First-Out (FIFO) principle (like a waiting line).
-   **Methods (`public Form1()`, `private void addButton_Click(...)`, etc.):** These are blocks of code that perform specific actions.
-   **Events (`addButton_Click`, `taskDisplay_SelectedIndexChanged`, etc.):** These are actions that occur in the application (e.g., a button click, a selection change). Event handlers (methods like `addButton_Click`) are executed when these events happen.
-   **Controls (`dateTimeLabel`, `userLabel`, `taskInput`, `addButton`, `taskDisplay`, `notesInput`, `saveNotesButton`, `toggleStatusButton`, `markCheckBox`, `deleteButton`, `deleteMarkedButton`, `allNotesDisplay`):** These are the visual elements of the user interface. Their properties (like `Text`, `Checked`, `BackColor`) can be manipulated in the code.
