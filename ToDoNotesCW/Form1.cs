using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// first in, first out
namespace ToDoNotesCW
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, TaskItem> _tasks = new Dictionary<string, TaskItem>(); // read-only dictionary - task name task detail
        private readonly List<string> _taskList = new List<string>(); // task added
        private readonly HashSet<string> _markedTasks = new HashSet<string>();
        private Timer _timer;
        private bool _isEventHandlersInitialized = false;
        private Stack<string> _taskStack = new Stack<string>(); // In LIFO manner
        private Queue<string> _taskQueue = new Queue<string>(); // In FIFO manner

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
            _tasks[task] = new TaskItem("Pending", ""); // adds to _tasks dictionary
            _taskList.Add(task); // Adds the 'task' variable (the task name) to the _taskList.
            _taskStack.Push(task); // Adds the 'task' variable to the top of the _taskStack.
            _taskQueue.Enqueue(task); // Adds the 'task' variable to the end of the _taskQueue.
            UpdateTaskDisplay(); // Calls the UpdateTaskDisplay method to refresh the list of tasks displayed on the form.
            UpdateAllNotesDisplay(); // Calls the UpdateAllNotesDisplay method to refresh the display of all task notes.
            taskInput.Clear(); // Clears the text in the taskInput control.
        }

        // Saves notes for a task.
        private void saveNotesButton_Click(object sender, EventArgs e) // Declares a private method named saveNotesButton_Click, executed when the saveNotesButton is clicked.
        {
            string selectedTask = GetSelectedTask(); // Calls the GetSelectedTask method to get the name of the currently selected task in the taskDisplay list.
            if (selectedTask != null && _tasks.TryGetValue(selectedTask, out var taskItem)) // Checks if a task is selected (selectedTask is not null) and if the selected task exists as a key in the _tasks dictionary. If it exists, the corresponding TaskItem object is stored in the 'taskItem' variable.
            {
                taskItem.Notes = notesInput.Text; // Sets the Notes property of the retrieved TaskItem object to the text in the notesInput control.
                UpdateAllNotesDisplay(); // Calls the UpdateAllNotesDisplay method to refresh the display of all task notes.
                MessageBox.Show($"Notes saved for {selectedTask}"); // Displays a message box confirming that the notes have been saved for the selected task. // TODO: Localize
                notesInput.Clear(); // Clears the text in the notesInput control.
            }
        }

        // Toggles a task's status (Pending/Completed).
        private void toggleStatusButton_Click(object sender, EventArgs e) // Declares a private method named toggleStatusButton_Click, executed when the toggleStatusButton is clicked.
        {
            if (taskDisplay.SelectedItem != null) // Checks if an item is currently selected in the taskDisplay list.
            {
                string selectedTask = GetSelectedTask(); // Gets the name of the selected task.
                if (_tasks.TryGetValue(selectedTask, out var taskItem)) // Tries to get the TaskItem object for the selected task from the _tasks dictionary.
                {
                    taskItem.Status = taskItem.Status == "Pending" ? "Completed" : "Pending"; // Toggles the Status property of the TaskItem. If it's "Pending", it's changed to "Completed", and vice versa.
                    UpdateTaskDisplay(); // Refreshes the displayed task list to show the updated status.
                    UpdateSelectedTaskDetails(); // Refreshes the details area to show the updated status.
                }
            }
        }

        // Handles task selection changes.
        private void taskDisplay_SelectedIndexChanged(object sender, EventArgs e) // Declares a private method named taskDisplay_SelectedIndexChanged, executed when the selected item in the taskDisplay list changes.
        {
            UpdateSelectedTaskDetails(); // Calls the UpdateSelectedTaskDetails method to display the details (status and notes) of the newly selected task.
            string selectedTask = GetSelectedTask(); // Gets the name of the currently selected task.
            markCheckBox.Checked = selectedTask != null && _markedTasks.Contains(selectedTask); // Sets the Checked property of the markCheckBox based on whether the selected task's name exists in the _markedTasks hash set.
        }

        // Deletes the selected task.
        private void deleteButton_Click(object sender, EventArgs e) // Declares a private method named deleteButton_Click, executed when the deleteButton is clicked.
        {
            string selectedTask = GetSelectedTask(); // Gets the name of the selected task.
            if (selectedTask != null) // Checks if a task is currently selected.
            {
                _tasks.Remove(selectedTask); // Removes the TaskItem associated with the selected task from the _tasks dictionary.
                _taskList.Remove(selectedTask); // Removes the name of the selected task from the _taskList.
                _markedTasks.Remove(selectedTask); // Removes the name of the selected task from the _markedTasks hash set, if it was marked.
                _taskStack = new Stack<string>(_taskStack.Where(t => t != selectedTask)); // Creates a new stack containing all tasks from the old stack except the deleted one.
                _taskQueue = new Queue<string>(_taskQueue.Where(t => t != selectedTask)); // Creates a new queue containing all tasks from the old queue except the deleted one.
                UpdateTaskDisplay(); // Refreshes the displayed task list.
                UpdateAllNotesDisplay(); // Refreshes the display of all task notes.
                UpdateSelectedTaskDetails(); // Clears the details area since no task is selected anymore (implicitly after deletion).
            }
        }

        // Handles marking/unmarking tasks for deletion.
        private void markCheckBox_CheckedChanged(object sender, EventArgs e) // Declares a private method named markCheckBox_CheckedChanged, executed when the Checked state of the markCheckBox changes.
        {
            string selectedTask = GetSelectedTask(); // Gets the name of the selected task.
            if (selectedTask != null) // Checks if a task is currently selected.
            {
                if (markCheckBox.Checked) _markedTasks.Add(selectedTask); // If the checkbox is checked, adds the selected task's name to the _markedTasks hash set.
                else _markedTasks.Remove(selectedTask); // If the checkbox is unchecked, removes the selected task's name from the _markedTasks hash set.
            }
        }

        // Deletes all marked tasks.
        private void deleteMarkedButton_Click(object sender, EventArgs e) // Declares a private method named deleteMarkedButton_Click, executed when the deleteMarkedButton is clicked.
        {
            foreach (string taskToDelete in _markedTasks.ToArray()) // Iterates over a copy of the _markedTasks hash set (converted to an array to avoid modification during enumeration).
            {
                _tasks.Remove(taskToDelete); // Removes the TaskItem for the marked task from the _tasks dictionary.
                _taskList.Remove(taskToDelete); // Removes the name of the marked task from the _taskList.
                _taskStack = new Stack<string>(_taskStack.Where(t => t != taskToDelete)); // Creates a new stack without the marked task.
                _taskQueue = new Queue<string>(_taskQueue.Where(t => t != taskToDelete)); // Creates a new queue without the marked task.
            }
            _markedTasks.Clear(); // Clears the _markedTasks hash set after deleting all marked tasks.
            UpdateTaskDisplay(); // Refreshes the displayed task list.
            UpdateAllNotesDisplay(); // Refreshes the display of all task notes.
            UpdateSelectedTaskDetails(); // Clears the details area.
        }

        // Updates the displayed task list.
        private void UpdateTaskDisplay() // Declares a private method named UpdateTaskDisplay.
        {
            taskDisplay.Items.Clear(); // Clears all items from the taskDisplay list control.
            _taskList.ForEach(task => taskDisplay.Items.Add($"{task}: {_tasks[task].Status}")); // Iterates through the _taskList, and for each task name, it retrieves the corresponding TaskItem from _tasks and adds a string containing the task name and its status to the taskDisplay list control.
        }

        // Updates the display for the selected task's details.
        private void UpdateSelectedTaskDetails() // Declares a private method named UpdateSelectedTaskDetails.
        {
            string selectedTask = GetSelectedTask(); // Gets the name of the currently selected task.
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
            foreach (string task in _taskList) // Iterates through the _taskList.
            {
                if (_tasks.TryGetValue(task, out var taskItem) && !string.IsNullOrWhiteSpace(taskItem.Notes)) // Checks if the task exists in _tasks and if its notes are not null or whitespace.
                {
                    allNotesDisplay.AppendText($"Task: {task}\r\nNotes: {taskItem.Notes}\r\n\r\n"); // Appends the task name and its notes to the allNotesDisplay control, with line breaks for formatting.
                }
            }
        }

        // Gets the name of the selected task.
        private string GetSelectedTask() => // Declares a private method named GetSelectedTask that returns a string.
            taskDisplay.SelectedItem?.ToString().Split(':')[0].Trim(); // Gets the currently selected item from the taskDisplay list, converts it to a string (if it's not null), splits the string at the ':' character, takes the first part (the task name), removes any leading or trailing whitespace, and returns the result.

        // Handles mouse enter event for buttons.
        private void Button_MouseEnter(object sender, EventArgs e) // Declares a private method named Button_MouseEnter, executed when the mouse cursor enters a button control.
        {
            if (sender is Button button) // Checks if the 'sender' object is a Button control.
            {
                button.BackColor = Color.FromArgb(53, 122, 189); // Changes the background color of the button to a darker blue when the mouse cursor hovers over it.
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
        protected override void OnFormClosing(FormClosingEventArgs e) // Overrides the OnFormClosing method, which is called when the form is closing. 'e' contains event-specific data.
        {
            base.OnFormClosing(e); // Calls the base class's OnFormClosing method.
            _timer?.Stop(); // Stops the timer if it's not null.
            _timer?.Dispose(); // Releases the resources used by the timer if it's not null.
        }
    }

    // Represents a task item.
    public class TaskItem // Declares a public class named TaskItem.
    {
        public string Status { get; set; } // Declares a public property named Status of type string, which gets or sets the status of the task.
        public string Notes { get; set; } // Declares a public property named Notes of type string, which gets or sets the notes associated with the task.

        public TaskItem(string status, string notes) // Declares a public constructor for the TaskItem class, which takes a status and notes as arguments.
        {
            Status = status; // Initializes the Status property with the provided 'status' argument.
            Notes = notes ?? ""; // Initializes the Notes property with the provided 'notes' argument. If 'notes' is null, it defaults to an empty string.
        }
    }
}