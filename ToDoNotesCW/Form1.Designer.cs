namespace ToDoNotesCW
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.taskInputLabel = new System.Windows.Forms.Label();
            this.taskInput = new System.Windows.Forms.TextBox();
            this.taskListLabel = new System.Windows.Forms.Label();
            this.taskDisplay = new System.Windows.Forms.ListBox();
            this.notesInputLabel = new System.Windows.Forms.Label();
            this.notesInput = new System.Windows.Forms.TextBox();
            this.allNotesLabel = new System.Windows.Forms.Label();
            this.allNotesDisplay = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.saveNotesButton = new System.Windows.Forms.Button();
            this.toggleStatusButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteMarkedButton = new System.Windows.Forms.Button();
            this.markCheckBox = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // taskInputLabel
            // 
            this.taskInputLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.taskInputLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.taskInputLabel.Location = new System.Drawing.Point(10, 9);
            this.taskInputLabel.Name = "taskInputLabel";
            this.taskInputLabel.Size = new System.Drawing.Size(80, 23);
            this.taskInputLabel.TabIndex = 13;
            this.taskInputLabel.Text = "Enter Task";
            // 
            // taskInput
            // 
            this.taskInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.taskInput.Location = new System.Drawing.Point(10, 37);
            this.taskInput.Name = "taskInput";
            this.taskInput.Size = new System.Drawing.Size(200, 27);
            this.taskInput.TabIndex = 3;
            // 
            // taskListLabel
            // 
            this.taskListLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.taskListLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.taskListLabel.Location = new System.Drawing.Point(10, 67);
            this.taskListLabel.Name = "taskListLabel";
            this.taskListLabel.Size = new System.Drawing.Size(50, 24);
            this.taskListLabel.TabIndex = 12;
            this.taskListLabel.Text = "Tasks";
            // 
            // taskDisplay
            // 
            this.taskDisplay.BackColor = System.Drawing.Color.White;
            this.taskDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskDisplay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.taskDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.taskDisplay.FormattingEnabled = true;
            this.taskDisplay.ItemHeight = 20;
            this.taskDisplay.Location = new System.Drawing.Point(10, 94);
            this.taskDisplay.Name = "taskDisplay";
            this.taskDisplay.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.taskDisplay.Size = new System.Drawing.Size(200, 142);
            this.taskDisplay.TabIndex = 5;
            this.taskDisplay.SelectedIndexChanged += new System.EventHandler(this.taskDisplay_SelectedIndexChanged);
            // 
            // notesInputLabel
            // 
            this.notesInputLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.notesInputLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.notesInputLabel.Location = new System.Drawing.Point(10, 239);
            this.notesInputLabel.Name = "notesInputLabel";
            this.notesInputLabel.Size = new System.Drawing.Size(178, 24);
            this.notesInputLabel.TabIndex = 11;
            this.notesInputLabel.Text = "Notes for Selected Task";
            // 
            // notesInput
            // 
            this.notesInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.notesInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.notesInput.Location = new System.Drawing.Point(10, 266);
            this.notesInput.Multiline = true;
            this.notesInput.Name = "notesInput";
            this.notesInput.Size = new System.Drawing.Size(200, 100);
            this.notesInput.TabIndex = 4;
            // 
            // allNotesLabel
            // 
            this.allNotesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.allNotesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.allNotesLabel.Location = new System.Drawing.Point(10, 369);
            this.allNotesLabel.Name = "allNotesLabel";
            this.allNotesLabel.Size = new System.Drawing.Size(140, 16);
            this.allNotesLabel.TabIndex = 16;
            this.allNotesLabel.Text = "All Notes";
            // 
            // allNotesDisplay
            // 
            this.allNotesDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.allNotesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allNotesDisplay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.allNotesDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.allNotesDisplay.Location = new System.Drawing.Point(10, 388);
            this.allNotesDisplay.Multiline = true;
            this.allNotesDisplay.Name = "allNotesDisplay";
            this.allNotesDisplay.ReadOnly = true;
            this.allNotesDisplay.Size = new System.Drawing.Size(360, 100);
            this.allNotesDisplay.TabIndex = 10;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(216, 37);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(110, 33);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Task";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.addButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.addButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // saveNotesButton
            // 
            this.saveNotesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.saveNotesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNotesButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.saveNotesButton.ForeColor = System.Drawing.Color.White;
            this.saveNotesButton.Location = new System.Drawing.Point(216, 75);
            this.saveNotesButton.Name = "saveNotesButton";
            this.saveNotesButton.Size = new System.Drawing.Size(110, 33);
            this.saveNotesButton.TabIndex = 2;
            this.saveNotesButton.Text = "Save Notes";
            this.saveNotesButton.UseVisualStyleBackColor = false;
            this.saveNotesButton.Click += new System.EventHandler(this.saveNotesButton_Click);
            this.saveNotesButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.saveNotesButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // toggleStatusButton
            // 
            this.toggleStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.toggleStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleStatusButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toggleStatusButton.ForeColor = System.Drawing.Color.White;
            this.toggleStatusButton.Location = new System.Drawing.Point(216, 115);
            this.toggleStatusButton.Name = "toggleStatusButton";
            this.toggleStatusButton.Size = new System.Drawing.Size(110, 33);
            this.toggleStatusButton.TabIndex = 1;
            this.toggleStatusButton.Text = "Toggle Status";
            this.toggleStatusButton.UseVisualStyleBackColor = false;
            this.toggleStatusButton.Click += new System.EventHandler(this.toggleStatusButton_Click);
            this.toggleStatusButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.toggleStatusButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(216, 154);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(110, 33);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete Task";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            this.deleteButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.deleteButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // deleteMarkedButton
            // 
            this.deleteMarkedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.deleteMarkedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteMarkedButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteMarkedButton.ForeColor = System.Drawing.Color.White;
            this.deleteMarkedButton.Location = new System.Drawing.Point(216, 193);
            this.deleteMarkedButton.Name = "deleteMarkedButton";
            this.deleteMarkedButton.Size = new System.Drawing.Size(110, 33);
            this.deleteMarkedButton.TabIndex = 9;
            this.deleteMarkedButton.Text = "Delete Marked Tasks";
            this.deleteMarkedButton.UseVisualStyleBackColor = false;
            this.deleteMarkedButton.Click += new System.EventHandler(this.deleteMarkedButton_Click);
            this.deleteMarkedButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.deleteMarkedButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // markCheckBox
            // 
            this.markCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.markCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.markCheckBox.Location = new System.Drawing.Point(216, 265);
            this.markCheckBox.Name = "markCheckBox";
            this.markCheckBox.Size = new System.Drawing.Size(148, 28);
            this.markCheckBox.TabIndex = 14;
            this.markCheckBox.Text = "Mark for Deletion";
            this.markCheckBox.UseVisualStyleBackColor = true;
            this.markCheckBox.CheckedChanged += new System.EventHandler(this.markCheckBox_CheckedChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.statusLabel.Location = new System.Drawing.Point(214, 296);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(150, 20);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.Text = "Status";
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.Location = new System.Drawing.Point(214, 319);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(149, 24);
            this.dateTimeLabel.TabIndex = 17;
            this.dateTimeLabel.Text = "label1";
            // 
            // userLabel
            // 
            this.userLabel.Location = new System.Drawing.Point(214, 343);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(148, 34);
            this.userLabel.TabIndex = 18;
            this.userLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.markCheckBox);
            this.Controls.Add(this.deleteMarkedButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.toggleStatusButton);
            this.Controls.Add(this.saveNotesButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.allNotesLabel);
            this.Controls.Add(this.allNotesDisplay);
            this.Controls.Add(this.notesInputLabel);
            this.Controls.Add(this.notesInput);
            this.Controls.Add(this.taskListLabel);
            this.Controls.Add(this.taskDisplay);
            this.Controls.Add(this.taskInputLabel);
            this.Controls.Add(this.taskInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Text = "To-Do and Notes";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label userLabel;

        #endregion

        private System.Windows.Forms.Label taskInputLabel;
        private System.Windows.Forms.TextBox taskInput;
        private System.Windows.Forms.Label taskListLabel;
        private System.Windows.Forms.ListBox taskDisplay;
        private System.Windows.Forms.Label notesInputLabel;
        private System.Windows.Forms.TextBox notesInput;
        private System.Windows.Forms.Label allNotesLabel;
        private System.Windows.Forms.TextBox allNotesDisplay;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveNotesButton;
        private System.Windows.Forms.Button toggleStatusButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteMarkedButton;
        private System.Windows.Forms.CheckBox markCheckBox;
        private System.Windows.Forms.Label statusLabel;
    }
}