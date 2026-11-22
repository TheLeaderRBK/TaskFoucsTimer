namespace TaskFocusTimer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitlePrompt;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnToggleComplete;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.GroupBox grpTimer;
        private System.Windows.Forms.Label lblActiveTask;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ProgressBar prgFocus;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ComboBox cmbDuration;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer focusTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitlePrompt = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnToggleComplete = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.grpTimer = new System.Windows.Forms.GroupBox();
            this.lblActiveTask = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.prgFocus = new System.Windows.Forms.ProgressBar();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.focusTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.grpTimer.SuspendLayout();
            this.SuspendLayout();

            // lblTitlePrompt
            this.lblTitlePrompt.AutoSize = true;
            this.lblTitlePrompt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTitlePrompt.Location = new System.Drawing.Point(20, 16);
            this.lblTitlePrompt.Name = "lblTitlePrompt";
            this.lblTitlePrompt.Size = new System.Drawing.Size(72, 17);
            this.lblTitlePrompt.Text = "New Task:";

            // txtTaskTitle
            this.txtTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskTitle.Location = new System.Drawing.Point(20, 38);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(360, 25);
            this.txtTaskTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaskTitle_KeyDown);

            // cmbPriority
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] { "High", "Medium", "Low" });
            this.cmbPriority.Location = new System.Drawing.Point(392, 38);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(110, 25);

            // btnAddTask
            this.btnAddTask.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Location = new System.Drawing.Point(514, 36);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(106, 29);
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            // dgvTasks
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AllowUserToResizeRows = false;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTasks.Location = new System.Drawing.Point(20, 78);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(600, 210);
            this.dgvTasks.SelectionChanged += new System.EventHandler(this.dgvTasks_SelectionChanged);

            // btnToggleComplete
            this.btnToggleComplete.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnToggleComplete.Location = new System.Drawing.Point(20, 298);
            this.btnToggleComplete.Name = "btnToggleComplete";
            this.btnToggleComplete.Size = new System.Drawing.Size(140, 30);
            this.btnToggleComplete.Text = "Mark Complete";
            this.btnToggleComplete.Click += new System.EventHandler(this.btnToggleComplete_Click);

            // btnDeleteTask
            this.btnDeleteTask.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteTask.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDeleteTask.Location = new System.Drawing.Point(514, 298);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(106, 30);
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);

            // grpTimer
            this.grpTimer.Controls.Add(this.btnReset);
            this.grpTimer.Controls.Add(this.btnPause);
            this.grpTimer.Controls.Add(this.btnStart);
            this.grpTimer.Controls.Add(this.cmbDuration);
            this.grpTimer.Controls.Add(this.lblDuration);
            this.grpTimer.Controls.Add(this.prgFocus);
            this.grpTimer.Controls.Add(this.lblTimer);
            this.grpTimer.Controls.Add(this.lblActiveTask);
            this.grpTimer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTimer.Location = new System.Drawing.Point(20, 342);
            this.grpTimer.Name = "grpTimer";
            this.grpTimer.Size = new System.Drawing.Size(600, 160);
            this.grpTimer.TabStop = false;
            this.grpTimer.Text = "Focus Session Timer";

            // lblActiveTask
            this.lblActiveTask.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblActiveTask.ForeColor = System.Drawing.Color.DimGray;
            this.lblActiveTask.Location = new System.Drawing.Point(16, 26);
            this.lblActiveTask.Name = "lblActiveTask";
            this.lblActiveTask.Size = new System.Drawing.Size(568, 20);
            this.lblActiveTask.Text = "Active Task: Select a task above to start focusing";

            // lblTimer
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTimer.Location = new System.Drawing.Point(16, 52);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(150, 48);
            this.lblTimer.Text = "25:00";

            // prgFocus
            this.prgFocus.Location = new System.Drawing.Point(176, 66);
            this.prgFocus.Maximum = 1500;
            this.prgFocus.Name = "prgFocus";
            this.prgFocus.Size = new System.Drawing.Size(408, 24);

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDuration.Location = new System.Drawing.Point(16, 117);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(62, 17);
            this.lblDuration.Text = "Duration:";

            // cmbDuration
            this.cmbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuration.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cmbDuration.FormattingEnabled = true;
            this.cmbDuration.Items.AddRange(new object[] { "15 Minutes", "25 Minutes", "45 Minutes" });
            this.cmbDuration.Location = new System.Drawing.Point(84, 114);
            this.cmbDuration.Name = "cmbDuration";
            this.cmbDuration.Size = new System.Drawing.Size(120, 25);
            this.cmbDuration.SelectedIndexChanged += new System.EventHandler(this.cmbDuration_SelectedIndexChanged);

            // btnStart
            this.btnStart.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(278, 111);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 30);
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnPause
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.btnPause.Location = new System.Drawing.Point(384, 111);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(96, 30);
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);

            // btnReset
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.btnReset.Location = new System.Drawing.Point(490, 111);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 30);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // focusTimer
            this.focusTimer.Interval = 1000;
            this.focusTimer.Tick += new System.EventHandler(this.focusTimer_Tick);

            // Form1
            this.ClientSize = new System.Drawing.Size(640, 520);
            this.Controls.Add(this.grpTimer);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnToggleComplete);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.lblTitlePrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task & Focus Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.grpTimer.ResumeLayout(false);
            this.grpTimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}