namespace XI2DS
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.uiButtonConnectController1 = new System.Windows.Forms.Button();
            this.uiButtonConnectController2 = new System.Windows.Forms.Button();
            this.uiButtonConnectController3 = new System.Windows.Forms.Button();
            this.uiButtonConnectController4 = new System.Windows.Forms.Button();
            this.imageListBattery = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiImageBatteryInfoController4 = new System.Windows.Forms.PictureBox();
            this.uiImageBatteryInfoController3 = new System.Windows.Forms.PictureBox();
            this.uiImageBatteryInfoController2 = new System.Windows.Forms.PictureBox();
            this.uiImageConnectionController4 = new System.Windows.Forms.PictureBox();
            this.uiImageConnectionController3 = new System.Windows.Forms.PictureBox();
            this.uiImageConnectionController2 = new System.Windows.Forms.PictureBox();
            this.uiImageConnectionController1 = new System.Windows.Forms.PictureBox();
            this.uiImageBatteryInfoController1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiButtonConnectController1
            // 
            this.uiButtonConnectController1.Enabled = false;
            this.uiButtonConnectController1.Location = new System.Drawing.Point(159, 37);
            this.uiButtonConnectController1.Name = "uiButtonConnectController1";
            this.uiButtonConnectController1.Size = new System.Drawing.Size(124, 23);
            this.uiButtonConnectController1.TabIndex = 0;
            this.uiButtonConnectController1.Tag = "0";
            this.uiButtonConnectController1.Text = "DS4 Connect";
            this.uiButtonConnectController1.UseVisualStyleBackColor = true;
            this.uiButtonConnectController1.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // uiButtonConnectController2
            // 
            this.uiButtonConnectController2.Enabled = false;
            this.uiButtonConnectController2.Location = new System.Drawing.Point(159, 66);
            this.uiButtonConnectController2.Name = "uiButtonConnectController2";
            this.uiButtonConnectController2.Size = new System.Drawing.Size(124, 23);
            this.uiButtonConnectController2.TabIndex = 1;
            this.uiButtonConnectController2.Tag = "1";
            this.uiButtonConnectController2.Text = "DS4 Connect";
            this.uiButtonConnectController2.UseVisualStyleBackColor = true;
            this.uiButtonConnectController2.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // uiButtonConnectController3
            // 
            this.uiButtonConnectController3.Enabled = false;
            this.uiButtonConnectController3.Location = new System.Drawing.Point(159, 95);
            this.uiButtonConnectController3.Name = "uiButtonConnectController3";
            this.uiButtonConnectController3.Size = new System.Drawing.Size(124, 23);
            this.uiButtonConnectController3.TabIndex = 1;
            this.uiButtonConnectController3.Tag = "2";
            this.uiButtonConnectController3.Text = "DS4 Connect";
            this.uiButtonConnectController3.UseVisualStyleBackColor = true;
            this.uiButtonConnectController3.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // uiButtonConnectController4
            // 
            this.uiButtonConnectController4.Enabled = false;
            this.uiButtonConnectController4.Location = new System.Drawing.Point(159, 124);
            this.uiButtonConnectController4.Name = "uiButtonConnectController4";
            this.uiButtonConnectController4.Size = new System.Drawing.Size(124, 23);
            this.uiButtonConnectController4.TabIndex = 1;
            this.uiButtonConnectController4.Tag = "3";
            this.uiButtonConnectController4.Text = "DS4 Connect";
            this.uiButtonConnectController4.UseVisualStyleBackColor = true;
            this.uiButtonConnectController4.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // imageListBattery
            // 
            this.imageListBattery.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBattery.ImageStream")));
            this.imageListBattery.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBattery.Images.SetKeyName(0, "battery_empty.png");
            this.imageListBattery.Images.SetKeyName(1, "battery_full.png");
            this.imageListBattery.Images.SetKeyName(2, "battery_low.png");
            this.imageListBattery.Images.SetKeyName(3, "battery_mid.png");
            this.imageListBattery.Images.SetKeyName(4, "battery_unknown.png");
            this.imageListBattery.Images.SetKeyName(5, "wired.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Controller 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Controller 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Controller 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Controller 4";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip.Size = new System.Drawing.Size(295, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "uiMenuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputTestToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // inputTestToolStripMenuItem
            // 
            this.inputTestToolStripMenuItem.Name = "inputTestToolStripMenuItem";
            this.inputTestToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inputTestToolStripMenuItem.Text = "Input Test";
            this.inputTestToolStripMenuItem.Click += new System.EventHandler(this.InputTestToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // uiImageBatteryInfoController4
            // 
            this.uiImageBatteryInfoController4.Image = ((System.Drawing.Image)(resources.GetObject("uiImageBatteryInfoController4.Image")));
            this.uiImageBatteryInfoController4.InitialImage = null;
            this.uiImageBatteryInfoController4.Location = new System.Drawing.Point(120, 127);
            this.uiImageBatteryInfoController4.Name = "uiImageBatteryInfoController4";
            this.uiImageBatteryInfoController4.Size = new System.Drawing.Size(29, 16);
            this.uiImageBatteryInfoController4.TabIndex = 2;
            this.uiImageBatteryInfoController4.TabStop = false;
            // 
            // uiImageBatteryInfoController3
            // 
            this.uiImageBatteryInfoController3.Image = ((System.Drawing.Image)(resources.GetObject("uiImageBatteryInfoController3.Image")));
            this.uiImageBatteryInfoController3.InitialImage = null;
            this.uiImageBatteryInfoController3.Location = new System.Drawing.Point(120, 98);
            this.uiImageBatteryInfoController3.Name = "uiImageBatteryInfoController3";
            this.uiImageBatteryInfoController3.Size = new System.Drawing.Size(29, 16);
            this.uiImageBatteryInfoController3.TabIndex = 2;
            this.uiImageBatteryInfoController3.TabStop = false;
            // 
            // uiImageBatteryInfoController2
            // 
            this.uiImageBatteryInfoController2.Image = ((System.Drawing.Image)(resources.GetObject("uiImageBatteryInfoController2.Image")));
            this.uiImageBatteryInfoController2.InitialImage = null;
            this.uiImageBatteryInfoController2.Location = new System.Drawing.Point(120, 69);
            this.uiImageBatteryInfoController2.Name = "uiImageBatteryInfoController2";
            this.uiImageBatteryInfoController2.Size = new System.Drawing.Size(29, 16);
            this.uiImageBatteryInfoController2.TabIndex = 2;
            this.uiImageBatteryInfoController2.TabStop = false;
            // 
            // uiImageConnectionController4
            // 
            this.uiImageConnectionController4.Image = global::XI2DS.Properties.Resources.controller_not_connected;
            this.uiImageConnectionController4.InitialImage = ((System.Drawing.Image)(resources.GetObject("uiImageConnectionController4.InitialImage")));
            this.uiImageConnectionController4.Location = new System.Drawing.Point(14, 127);
            this.uiImageConnectionController4.Name = "uiImageConnectionController4";
            this.uiImageConnectionController4.Size = new System.Drawing.Size(16, 16);
            this.uiImageConnectionController4.TabIndex = 2;
            this.uiImageConnectionController4.TabStop = false;
            // 
            // uiImageConnectionController3
            // 
            this.uiImageConnectionController3.Image = global::XI2DS.Properties.Resources.controller_not_connected;
            this.uiImageConnectionController3.InitialImage = ((System.Drawing.Image)(resources.GetObject("uiImageConnectionController3.InitialImage")));
            this.uiImageConnectionController3.Location = new System.Drawing.Point(14, 98);
            this.uiImageConnectionController3.Name = "uiImageConnectionController3";
            this.uiImageConnectionController3.Size = new System.Drawing.Size(16, 16);
            this.uiImageConnectionController3.TabIndex = 2;
            this.uiImageConnectionController3.TabStop = false;
            // 
            // uiImageConnectionController2
            // 
            this.uiImageConnectionController2.Image = global::XI2DS.Properties.Resources.controller_not_connected;
            this.uiImageConnectionController2.InitialImage = ((System.Drawing.Image)(resources.GetObject("uiImageConnectionController2.InitialImage")));
            this.uiImageConnectionController2.Location = new System.Drawing.Point(14, 69);
            this.uiImageConnectionController2.Name = "uiImageConnectionController2";
            this.uiImageConnectionController2.Size = new System.Drawing.Size(16, 16);
            this.uiImageConnectionController2.TabIndex = 2;
            this.uiImageConnectionController2.TabStop = false;
            // 
            // uiImageConnectionController1
            // 
            this.uiImageConnectionController1.Image = global::XI2DS.Properties.Resources.controller_not_connected;
            this.uiImageConnectionController1.InitialImage = ((System.Drawing.Image)(resources.GetObject("uiImageConnectionController1.InitialImage")));
            this.uiImageConnectionController1.Location = new System.Drawing.Point(14, 40);
            this.uiImageConnectionController1.Name = "uiImageConnectionController1";
            this.uiImageConnectionController1.Size = new System.Drawing.Size(16, 16);
            this.uiImageConnectionController1.TabIndex = 2;
            this.uiImageConnectionController1.TabStop = false;
            // 
            // uiImageBatteryInfoController1
            // 
            this.uiImageBatteryInfoController1.ErrorImage = null;
            this.uiImageBatteryInfoController1.Image = global::XI2DS.Properties.Resources.battery_unknown;
            this.uiImageBatteryInfoController1.InitialImage = global::XI2DS.Properties.Resources.battery_unknown;
            this.uiImageBatteryInfoController1.Location = new System.Drawing.Point(120, 40);
            this.uiImageBatteryInfoController1.Name = "uiImageBatteryInfoController1";
            this.uiImageBatteryInfoController1.Size = new System.Drawing.Size(29, 16);
            this.uiImageBatteryInfoController1.TabIndex = 2;
            this.uiImageBatteryInfoController1.TabStop = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "XI2DS";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(295, 157);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiImageBatteryInfoController4);
            this.Controls.Add(this.uiImageBatteryInfoController3);
            this.Controls.Add(this.uiImageBatteryInfoController2);
            this.Controls.Add(this.uiImageConnectionController4);
            this.Controls.Add(this.uiImageConnectionController3);
            this.Controls.Add(this.uiImageConnectionController2);
            this.Controls.Add(this.uiImageConnectionController1);
            this.Controls.Add(this.uiImageBatteryInfoController1);
            this.Controls.Add(this.uiButtonConnectController4);
            this.Controls.Add(this.uiButtonConnectController3);
            this.Controls.Add(this.uiButtonConnectController2);
            this.Controls.Add(this.uiButtonConnectController1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "XI2DS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageConnectionController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageBatteryInfoController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiButtonConnectController1;
        private System.Windows.Forms.Button uiButtonConnectController2;
        private System.Windows.Forms.Button uiButtonConnectController3;
        private System.Windows.Forms.Button uiButtonConnectController4;
        private System.Windows.Forms.PictureBox uiImageBatteryInfoController1;
        private System.Windows.Forms.PictureBox uiImageBatteryInfoController2;
        private System.Windows.Forms.PictureBox uiImageBatteryInfoController3;
        private System.Windows.Forms.PictureBox uiImageBatteryInfoController4;
        private System.Windows.Forms.ImageList imageListBattery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox uiImageConnectionController1;
        private System.Windows.Forms.PictureBox uiImageConnectionController2;
        private System.Windows.Forms.PictureBox uiImageConnectionController3;
        private System.Windows.Forms.PictureBox uiImageConnectionController4;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

