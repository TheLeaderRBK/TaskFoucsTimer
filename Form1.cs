using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TaskFocusTimer
{
    public partial class Form1 : Form
    {
        private readonly BindingList<TaskItem> _tasks = new BindingList<TaskItem>();
        private readonly string _saveFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.xml");

        private int _totalSeconds = 25 * 60;
        private int _remainingSeconds = 25 * 60;

        public Form1()
        {
            InitializeComponent();
            cmbPriority.SelectedIndex = 1; // Default: Medium
            cmbDuration.SelectedIndex = 1; // Default: 25 Minutes
            dgvTasks.DataSource = _tasks;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTasks();
            FormatGridColumns();
            UpdateSelectionUI();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            focusTimer.Stop();
            SaveTasks();
        }

        private void FormatGridColumns()
        {
            if (dgvTasks.Columns.Count == 0) return;

            dgvTasks.Columns["Title"].HeaderText = "Task Description";
            dgvTasks.Columns["Title"].FillWeight = 50;

            dgvTasks.Columns["Priority"].HeaderText = "Priority";
            dgvTasks.Columns["Priority"].FillWeight = 18;

            dgvTasks.Columns["CompletedSessions"].HeaderText = "Focus Sessions";
            dgvTasks.Columns["CompletedSessions"].FillWeight = 18;

            dgvTasks.Columns["IsCompleted"].HeaderText = "Completed";
            dgvTasks.Columns["IsCompleted"].FillWeight = 14;
        }

        private TaskItem GetSelectedTask()
        {
            if (dgvTasks.CurrentRow != null && dgvTasks.CurrentRow.DataBoundItem is TaskItem task)
            {
                return task;
            }
            return null;
        }

        private void UpdateSelectionUI()
        {
            TaskItem selected = GetSelectedTask();

            if (selected == null)
            {
                lblActiveTask.Text = "Active Task: Select a task above to start focusing";
                btnStart.Enabled = false;
                btnToggleComplete.Enabled = false;
                btnDeleteTask.Enabled = false;
            }
            else
            {
                lblActiveTask.Text = string.Format("Active Task: {0} ({1} Priority)", selected.Title, selected.Priority);
                btnStart.Enabled = !focusTimer.Enabled;
                btnToggleComplete.Enabled = true;
                btnToggleComplete.Text = selected.IsCompleted ? "Mark Incomplete" : "Mark Complete";
                btnDeleteTask.Enabled = true;
            }
        }

        private void txtTaskTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddTask_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task description before adding.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaskTitle.Focus();
                return;
            }

            TaskItem newTask = new TaskItem
            {
                Title = title,
                Priority = cmbPriority.SelectedItem.ToString(),
                CompletedSessions = 0,
                IsCompleted = false
            };

            _tasks.Add(newTask);
            txtTaskTitle.Clear();
            txtTaskTitle.Focus();

            SaveTasks();
            UpdateSelectionUI();
        }

        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (!focusTimer.Enabled)
            {
                UpdateSelectionUI();
            }
        }

        private void btnToggleComplete_Click(object sender, EventArgs e)
        {
            TaskItem selected = GetSelectedTask();
            if (selected == null) return;

            selected.IsCompleted = !selected.IsCompleted;
            dgvTasks.Refresh();
            SaveTasks();
            UpdateSelectionUI();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            TaskItem selected = GetSelectedTask();
            if (selected == null) return;

            if (focusTimer.Enabled)
            {
                focusTimer.Stop();
                ResetTimerState();
            }

            _tasks.Remove(selected);
            SaveTasks();
            UpdateSelectionUI();
        }

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (focusTimer.Enabled) return;
            ResetTimerState();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (GetSelectedTask() == null)
            {
                MessageBox.Show("Select a task from the list first.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            focusTimer.Start();
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            cmbDuration.Enabled = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            focusTimer.Stop();
            btnStart.Enabled = GetSelectedTask() != null;
            btnPause.Enabled = false;
            cmbDuration.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            focusTimer.Stop();
            ResetTimerState();
            btnStart.Enabled = GetSelectedTask() != null;
            btnPause.Enabled = false;
            cmbDuration.Enabled = true;
        }

        private void ResetTimerState()
        {
            int minutes = 25;
            if (cmbDuration.SelectedIndex == 0) minutes = 15;
            else if (cmbDuration.SelectedIndex == 2) minutes = 45;

            _totalSeconds = minutes * 60;
            _remainingSeconds = _totalSeconds;

            lblTimer.Text = TimeSpan.FromSeconds(_remainingSeconds).ToString(@"mm\:ss");
            prgFocus.Maximum = _totalSeconds;
            prgFocus.Value = 0;
        }

        private void focusTimer_Tick(object sender, EventArgs e)
        {
            if (_remainingSeconds > 0)
            {
                _remainingSeconds--;
                lblTimer.Text = TimeSpan.FromSeconds(_remainingSeconds).ToString(@"mm\:ss");
                prgFocus.Value = Math.Min(prgFocus.Maximum, _totalSeconds - _remainingSeconds);
            }

            if (_remainingSeconds <= 0)
            {
                focusTimer.Stop();

                TaskItem selected = GetSelectedTask();
                if (selected != null)
                {
                    selected.CompletedSessions++;
                    dgvTasks.Refresh();
                    SaveTasks();
                }

                MessageBox.Show("Focus session complete! Your progress has been saved.", "Session Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetTimerState();
                btnStart.Enabled = GetSelectedTask() != null;
                btnPause.Enabled = false;
                cmbDuration.Enabled = true;
            }
        }

        private void SaveTasks()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<TaskItem>));
                using (StreamWriter writer = new StreamWriter(_saveFilePath))
                {
                    serializer.Serialize(writer, new List<TaskItem>(_tasks));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save tasks: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTasks()
        {
            if (!File.Exists(_saveFilePath)) return;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<TaskItem>));
                using (StreamReader reader = new StreamReader(_saveFilePath))
                {
                    List<TaskItem> loaded = (List<TaskItem>)serializer.Deserialize(reader);
                    _tasks.Clear();
                    foreach (TaskItem item in loaded)
                    {
                        _tasks.Add(item);
                    }
                }
            }
            catch
            {
                // Ignore corrupted file on startup and start fresh
            }
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public int CompletedSessions { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem() { }
    }
}