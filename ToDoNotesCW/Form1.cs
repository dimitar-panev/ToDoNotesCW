﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// first in, first out, last-in
namespace ToDoNotesCW
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, TaskItem> _tasks = new Dictionary<string, TaskItem>(); // read-only dictionary - storing info(taskitem)
        private readonly List<string> _taskList = new List<string>(); // task added - ordered list of items
        private readonly HashSet<string> _markedTasks = new HashSet<string>(); // collection storing given items     ( mainly to keep track of marked for deletion)(efficient for checking if something is selected
        private Timer _timer;
        private Stack<string> _taskStack = new Stack<string>(); // task names in order they were added
        private Queue<string> _taskQueue = new Queue<string>(); // again to store in order, lifo not used(undo intended)

        public Form1() // calls methods
        {
            InitializeComponent();
            InitializeEvents();
            InitializeTimer();
            UpdateDateTimeAndUser();
        }
        
        private void InitializeTimer()
        {
            _timer = new Timer { Interval = 1000, Enabled = true };
            _timer.Tick += (s, e) => UpdateDateTimeAndUser();
        }
        
        private void UpdateDateTimeAndUser() 
        {
            dateTimeLabel.Text = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            userLabel.Text = "Current User: dimitar-panev";
        }

        private void InitializeEvents() { }
        private void addButton_Click(object sender, EventArgs e)
        {
            string task = taskInput.Text.Trim(); // gets text, removes whitespace
            if (string.IsNullOrWhiteSpace(task) || task == "Enter Task" || _tasks.ContainsKey(task)) // chehcks if task exists, whitespace or more
            {
                if (_tasks.ContainsKey(task)) MessageBox.Show("Task name cannot be duplicate!"); // if a dublicate found, display
                return;
            }
// creates Pending and empty notes string
            _tasks[task] = new TaskItem("Pending", "");
            _taskList.Add(task); 
            _taskStack.Push(task); 
            _taskQueue.Enqueue(task);
            UpdateTaskDisplay(); // call to refresh
            UpdateAllNotesDisplay(); // refresh display of task notes
            taskInput.Clear(); // clears text
        }

        // Saves notes for a task.
        private void saveNotesButton_Click(object sender, EventArgs e)
        {
            string selectedTask = GetSelectedTask();
            if (selectedTask != null && _tasks.TryGetValue(selectedTask, out var taskItem)) // Checks if a task is selected (selectedTask is not null) and if the selected task
                                                                                            // exists as a key in the _tasks dictionary. If exists - store in the 'taskItem' variable.
            {
                taskItem.Notes = notesInput.Text;
                UpdateAllNotesDisplay(); // refresh again
                MessageBox.Show($"Notes saved for {selectedTask}");
                notesInput.Clear(); // Clears the text in the notesInput control.
            }
        }

        // Toggles a task's status (Pending/Completed).
        private void toggleStatusButton_Click(object sender, EventArgs e)
        {
            if (taskDisplay.SelectedItem != null) // Checks if an item is currently selected in the taskDisplay list.
            {
                string selectedTask = GetSelectedTask(); // Gets the name of the selected task.
                if (_tasks.TryGetValue(selectedTask, out var taskItem)) // try get TaskItem from _tasks dict
                {
                    taskItem.Status = taskItem.Status == "Pending" ? "Completed" : "Pending"; // Toggles the Status property of the TaskItem. If it's "Pending", it's changed to "Completed", and vice versa.
                    UpdateTaskDisplay(); // refresh
                    UpdateSelectedTaskDetails(); // refresh
                }
            }
        }

        // Handles task selection changes.
        private void taskDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedTaskDetails(); // display details of newly selected task
            string selectedTask = GetSelectedTask(); // gets name of selected t
            markCheckBox.Checked = selectedTask != null && _markedTasks.Contains(selectedTask); // make checked if exists in hash set _markedTask
        }

        // Deletes the selected task.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            string selectedTask = GetSelectedTask();
            if (selectedTask != null) // check if selected
            {
                _tasks.Remove(selectedTask); // self-explanatory
                _taskList.Remove(selectedTask);
                _markedTasks.Remove(selectedTask);
                _taskStack = new Stack<string>(_taskStack.Where(t => t != selectedTask)); // Creates a new stack containing all tasks from the old stack except the deleted one.
                _taskQueue = new Queue<string>(_taskQueue.Where(t => t != selectedTask)); // Creates a new queue ...
                UpdateTaskDisplay(); // refresh
                UpdateAllNotesDisplay(); // refresh
                UpdateSelectedTaskDetails(); // clear cuz no task selected
            }
        }

        // Handles marking/unmarking tasks for deletion.
        private void markCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string selectedTask = GetSelectedTask(); // g name
            if (selectedTask != null) // selected?
            {
                if (markCheckBox.Checked) _markedTasks.Add(selectedTask); // if checked - add to _markedTasks
                else _markedTasks.Remove(selectedTask); // If the checkbox is unchecked, removes the selected task's name from the _markedTasks hash set.
            }
        }

        // Deletes all marked tasks.
        private void deleteMarkedButton_Click(object sender, EventArgs e)
        {
            foreach (string taskToDelete in _markedTasks.ToArray()) // Iterates over a copy of the _markedTasks hash set (converted to an array to avoid modification during enumeration).
            {
                _tasks.Remove(taskToDelete); // remove taskitem for the marked task in _tasks
                _taskList.Remove(taskToDelete); // removes name of marked task in _taskList
                _taskStack = new Stack<string>(_taskStack.Where(t => t != taskToDelete)); // Creates a new stack without the marked task.
                _taskQueue = new Queue<string>(_taskQueue.Where(t => t != taskToDelete)); // Creates a new queue without the marked task.
            }
            _markedTasks.Clear(); // clear _markedTasks hash set after deletion
            UpdateTaskDisplay();
            UpdateAllNotesDisplay();
            UpdateSelectedTaskDetails();
        }

        // Updates the displayed task list.
        private void UpdateTaskDisplay() // method for updating the tasks 
        {
            taskDisplay.Items.Clear(); // Clears all items from the taskDisplay list control.
            _taskList.ForEach(task => taskDisplay.Items.Add($"{task}: {_tasks[task].Status}"));
            // Iterates through the _taskList and retrieves taskitem from _task and adds a string containing the task name and its status
        }

        // Updates the display for the selected task's details.
        private void UpdateSelectedTaskDetails() //method
        {
            string selectedTask = GetSelectedTask(); // gets name
            if (selectedTask != null && _tasks.TryGetValue(selectedTask, out var taskItem)) // Checks if a task is selected and if it exists in the _tasks dictionary.
            {
                statusLabel.Text = $"Status: {taskItem.Status}"; // Sets the Text property of the statusLabel control to display the status of the selected task. // TODO: Localize
                notesInput.Text = taskItem.Notes; // Sets the Text property of the notesInput control to display the notes of the selected task.
            }
            else // If no task is selected or the selected task is not found in _tasks.
            {
                statusLabel.Text = "Status"; // Sets the statusLabel text to "Status". // TODO: Localize
                notesInput.Text = ""; // Clears the text in the notesInput control.
            }
        }

        // Updates the display of all task notes.
        private void UpdateAllNotesDisplay() // Declares a private method named UpdateAllNotesDisplay.
        {
            allNotesDisplay.Clear(); // Clears all text from the allNotesDisplay control.
            foreach (string task in _taskList) // minava through the _taskList.
            {
                if (_tasks.TryGetValue(task, out var taskItem) && !string.IsNullOrWhiteSpace(taskItem.Notes)) // Checks if the task exists in _tasks and if its notes are not null or whitespace.
                {
                    allNotesDisplay.AppendText($"Task: {task}\r\nNotes: {taskItem.Notes}\r\n\r\n"); // Appends the task name and its notes to the allNotesDisplay control
                }                                                                    // line brakes
            }
        }

        // Gets the name of the selected task.
        private string GetSelectedTask() => // private method that returns a string.
            taskDisplay.SelectedItem?.ToString().Split(':')[0].Trim(); // Gets the currently selected item from the taskDisplay list, converts to string, splits :, first part
                                                // ws
        // Handles mouse enter event for buttons.
        private void Button_MouseEnter(object sender, EventArgs e) // when mouse enters a button control
        {
            if (sender is Button button) // check if sender object is button
            {
                button.BackColor = Color.FromArgb(53, 122, 189); // change when mouse hover
            }
        }

        // Handles mouse leave event for buttons.
        private void Button_MouseLeave(object sender, EventArgs e) // Declares a private method named Button_MouseLeave, executed when the mouse cursor leaves a button control.
        {
            if (sender is Button button) // Checks if the 'sender' object is a Button control.
            {
                button.BackColor = Color.FromArgb(74, 144, 226); // Changes the background color of the button back to the original blue color when the mouse cursor leaves it.
            }
        }

        // Cleans up resources when the form closes.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _timer?.Stop();
            _timer?.Dispose();
        }
    }

    // Represents a task item.
    public class TaskItem // Declares a public class named TaskItem.
    {
        public string Status { get; set; } // public property for status of tasks
        public string Notes { get; set; } // gets notes assosiated with task

        public TaskItem(string status, string notes) // Declares a public constructor for the TaskItem class, which takes a status and notes as arguments.
        {
            Status = status; // Initializes the Status property with the provided 'status' argument.
            Notes = notes ?? ""; // Initializes the Notes property. If 'notes' is null, it defaults to an empty string.
        }
    }
}