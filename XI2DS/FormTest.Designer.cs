namespace XI2DS
{
    partial class FormTest
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
            this.components = new System.ComponentModel.Container();
            this.uiTextLog = new System.Windows.Forms.TextBox();
            this.dataGridViewState = new System.Windows.Forms.DataGridView();
            this.ColumnController = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPollingFPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDPadUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDPadDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDPadLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDPadRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftStick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRightStick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftBumper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRightBumper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftTrigger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRightTrigger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftAnalogX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftAnalogY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRightAnalogX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRightAnalogY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerFPS = new System.Windows.Forms.Timer(this.components);
            this.timerStateUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewState)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTextLog
            // 
            this.uiTextLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiTextLog.Location = new System.Drawing.Point(9, 198);
            this.uiTextLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiTextLog.Multiline = true;
            this.uiTextLog.Name = "uiTextLog";
            this.uiTextLog.ReadOnly = true;
            this.uiTextLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uiTextLog.Size = new System.Drawing.Size(1109, 302);
            this.uiTextLog.TabIndex = 0;
            this.uiTextLog.Text = "* Connect with DualShock to test *";
            // 
            // dataGridViewState
            // 
            this.dataGridViewState.AllowUserToAddRows = false;
            this.dataGridViewState.AllowUserToDeleteRows = false;
            this.dataGridViewState.AllowUserToResizeColumns = false;
            this.dataGridViewState.AllowUserToResizeRows = false;
            this.dataGridViewState.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewState.ColumnHeadersHeight = 40;
            this.dataGridViewState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnController,
            this.ColumnPollingFPS,
            this.ColumnDPadUp,
            this.ColumnDPadDown,
            this.ColumnDPadLeft,
            this.ColumnDPadRight,
            this.ColumnStart,
            this.ColumnBack,
            this.ColumnLeftStick,
            this.ColumnRightStick,
            this.ColumnLeftBumper,
            this.ColumnRightBumper,
            this.ColumnA,
            this.ColumnB,
            this.ColumnX,
            this.ColumnY,
            this.ColumnLeftTrigger,
            this.ColumnRightTrigger,
            this.ColumnLeftAnalogX,
            this.ColumnLeftAnalogY,
            this.ColumnRightAnalogX,
            this.ColumnRightAnalogY});
            this.dataGridViewState.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewState.Location = new System.Drawing.Point(9, 15);
            this.dataGridViewState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewState.MultiSelect = false;
            this.dataGridViewState.Name = "dataGridViewState";
            this.dataGridViewState.ReadOnly = true;
            this.dataGridViewState.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewState.RowHeadersVisible = false;
            this.dataGridViewState.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewState.RowTemplate.Height = 23;
            this.dataGridViewState.RowTemplate.ReadOnly = true;
            this.dataGridViewState.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewState.Size = new System.Drawing.Size(1109, 168);
            this.dataGridViewState.TabIndex = 1;
            this.dataGridViewState.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // ColumnController
            // 
            this.ColumnController.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnController.HeaderText = "Controller Number";
            this.ColumnController.Name = "ColumnController";
            this.ColumnController.ReadOnly = true;
            this.ColumnController.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnController.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnController.Width = 71;
            // 
            // ColumnPollingFPS
            // 
            this.ColumnPollingFPS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPollingFPS.HeaderText = "Polling FPS";
            this.ColumnPollingFPS.Name = "ColumnPollingFPS";
            this.ColumnPollingFPS.ReadOnly = true;
            this.ColumnPollingFPS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPollingFPS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPollingFPS.Width = 71;
            // 
            // ColumnDPadUp
            // 
            this.ColumnDPadUp.HeaderText = "Up";
            this.ColumnDPadUp.Name = "ColumnDPadUp";
            this.ColumnDPadUp.ReadOnly = true;
            this.ColumnDPadUp.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDPadUp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDPadUp.Width = 43;
            // 
            // ColumnDPadDown
            // 
            this.ColumnDPadDown.HeaderText = "Down";
            this.ColumnDPadDown.Name = "ColumnDPadDown";
            this.ColumnDPadDown.ReadOnly = true;
            this.ColumnDPadDown.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDPadDown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDPadDown.Width = 43;
            // 
            // ColumnDPadLeft
            // 
            this.ColumnDPadLeft.HeaderText = "Left";
            this.ColumnDPadLeft.Name = "ColumnDPadLeft";
            this.ColumnDPadLeft.ReadOnly = true;
            this.ColumnDPadLeft.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDPadLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDPadLeft.Width = 43;
            // 
            // ColumnDPadRight
            // 
            this.ColumnDPadRight.HeaderText = "Right";
            this.ColumnDPadRight.Name = "ColumnDPadRight";
            this.ColumnDPadRight.ReadOnly = true;
            this.ColumnDPadRight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDPadRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDPadRight.Width = 43;
            // 
            // ColumnStart
            // 
            this.ColumnStart.HeaderText = "Start";
            this.ColumnStart.Name = "ColumnStart";
            this.ColumnStart.ReadOnly = true;
            this.ColumnStart.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnStart.Width = 43;
            // 
            // ColumnBack
            // 
            this.ColumnBack.HeaderText = "Back";
            this.ColumnBack.Name = "ColumnBack";
            this.ColumnBack.ReadOnly = true;
            this.ColumnBack.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnBack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnBack.Width = 43;
            // 
            // ColumnLeftStick
            // 
            this.ColumnLeftStick.HeaderText = "LS";
            this.ColumnLeftStick.Name = "ColumnLeftStick";
            this.ColumnLeftStick.ReadOnly = true;
            this.ColumnLeftStick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnLeftStick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLeftStick.Width = 43;
            // 
            // ColumnRightStick
            // 
            this.ColumnRightStick.HeaderText = "RS";
            this.ColumnRightStick.Name = "ColumnRightStick";
            this.ColumnRightStick.ReadOnly = true;
            this.ColumnRightStick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRightStick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRightStick.Width = 43;
            // 
            // ColumnLeftBumper
            // 
            this.ColumnLeftBumper.HeaderText = "LB";
            this.ColumnLeftBumper.Name = "ColumnLeftBumper";
            this.ColumnLeftBumper.ReadOnly = true;
            this.ColumnLeftBumper.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnLeftBumper.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLeftBumper.Width = 43;
            // 
            // ColumnRightBumper
            // 
            this.ColumnRightBumper.HeaderText = "RB";
            this.ColumnRightBumper.Name = "ColumnRightBumper";
            this.ColumnRightBumper.ReadOnly = true;
            this.ColumnRightBumper.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRightBumper.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRightBumper.Width = 43;
            // 
            // ColumnA
            // 
            this.ColumnA.HeaderText = "A";
            this.ColumnA.Name = "ColumnA";
            this.ColumnA.ReadOnly = true;
            this.ColumnA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnA.Width = 43;
            // 
            // ColumnB
            // 
            this.ColumnB.HeaderText = "B";
            this.ColumnB.Name = "ColumnB";
            this.ColumnB.ReadOnly = true;
            this.ColumnB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnB.Width = 43;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.ReadOnly = true;
            this.ColumnX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnX.Width = 43;
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            this.ColumnY.ReadOnly = true;
            this.ColumnY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnY.Width = 43;
            // 
            // ColumnLeftTrigger
            // 
            this.ColumnLeftTrigger.HeaderText = "LT";
            this.ColumnLeftTrigger.Name = "ColumnLeftTrigger";
            this.ColumnLeftTrigger.ReadOnly = true;
            this.ColumnLeftTrigger.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnLeftTrigger.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLeftTrigger.Width = 60;
            // 
            // ColumnRightTrigger
            // 
            this.ColumnRightTrigger.HeaderText = "RT";
            this.ColumnRightTrigger.Name = "ColumnRightTrigger";
            this.ColumnRightTrigger.ReadOnly = true;
            this.ColumnRightTrigger.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRightTrigger.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRightTrigger.Width = 60;
            // 
            // ColumnLeftAnalogX
            // 
            this.ColumnLeftAnalogX.HeaderText = "LTX";
            this.ColumnLeftAnalogX.Name = "ColumnLeftAnalogX";
            this.ColumnLeftAnalogX.ReadOnly = true;
            this.ColumnLeftAnalogX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnLeftAnalogX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLeftAnalogX.Width = 60;
            // 
            // ColumnLeftAnalogY
            // 
            this.ColumnLeftAnalogY.HeaderText = "LTY";
            this.ColumnLeftAnalogY.Name = "ColumnLeftAnalogY";
            this.ColumnLeftAnalogY.ReadOnly = true;
            this.ColumnLeftAnalogY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnLeftAnalogY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLeftAnalogY.Width = 60;
            // 
            // ColumnRightAnalogX
            // 
            this.ColumnRightAnalogX.HeaderText = "RTX";
            this.ColumnRightAnalogX.Name = "ColumnRightAnalogX";
            this.ColumnRightAnalogX.ReadOnly = true;
            this.ColumnRightAnalogX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRightAnalogX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRightAnalogX.Width = 60;
            // 
            // ColumnRightAnalogY
            // 
            this.ColumnRightAnalogY.HeaderText = "RTY";
            this.ColumnRightAnalogY.Name = "ColumnRightAnalogY";
            this.ColumnRightAnalogY.ReadOnly = true;
            this.ColumnRightAnalogY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRightAnalogY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRightAnalogY.Width = 60;
            // 
            // timerFPS
            // 
            this.timerFPS.Interval = 1000;
            this.timerFPS.Tick += new System.EventHandler(this.timerFPS_Tick);
            // 
            // timerStateUpdate
            // 
            this.timerStateUpdate.Interval = 50;
            this.timerStateUpdate.Tick += new System.EventHandler(this.timerStateUpdate_Tick);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 515);
            this.Controls.Add(this.dataGridViewState);
            this.Controls.Add(this.uiTextLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Input Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLog_FormClosing);
            this.Load += new System.EventHandler(this.FormLog_Load);
            this.VisibleChanged += new System.EventHandler(this.FormTest_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiTextLog;
        private System.Windows.Forms.DataGridView dataGridViewState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnController;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDPadUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDPadDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDPadLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDPadRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftStick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRightStick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftBumper;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRightBumper;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftTrigger;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRightTrigger;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftAnalogX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftAnalogY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRightAnalogX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRightAnalogY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPollingFPS;
        private System.Windows.Forms.Timer timerFPS;
        private System.Windows.Forms.Timer timerStateUpdate;
    }
}