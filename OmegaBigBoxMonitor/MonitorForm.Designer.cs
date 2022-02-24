
namespace OmegaBigBoxMonitor
{
    partial class MonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
            this.TextBox_Events = new System.Windows.Forms.TextBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hide_button = new System.Windows.Forms.Button();
            this.kill_button = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox_Events
            // 
            this.TextBox_Events.BackColor = System.Drawing.Color.White;
            this.TextBox_Events.Location = new System.Drawing.Point(12, 12);
            this.TextBox_Events.Multiline = true;
            this.TextBox_Events.Name = "TextBox_Events";
            this.TextBox_Events.ReadOnly = true;
            this.TextBox_Events.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Events.Size = new System.Drawing.Size(776, 426);
            this.TextBox_Events.TabIndex = 0;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Omega BigBox Monitor";
            this.trayIcon.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMonitorMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // ShowMonitorMenuItem
            // 
            this.ShowMonitorMenuItem.Name = "ShowMonitorMenuItem";
            this.ShowMonitorMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ShowMonitorMenuItem.Text = "Show Monitor";
            this.ShowMonitorMenuItem.Click += new System.EventHandler(this.ShowMonitorMenuItem_Click);
            // 
            // hide_button
            // 
            this.hide_button.BackColor = System.Drawing.Color.CornflowerBlue;
            this.hide_button.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hide_button.Location = new System.Drawing.Point(223, 466);
            this.hide_button.Name = "hide_button";
            this.hide_button.Size = new System.Drawing.Size(161, 42);
            this.hide_button.TabIndex = 2;
            this.hide_button.Text = "Hide Monitor";
            this.hide_button.UseVisualStyleBackColor = false;
            this.hide_button.Click += new System.EventHandler(this.hide_button_Click);
            // 
            // kill_button
            // 
            this.kill_button.BackColor = System.Drawing.Color.CornflowerBlue;
            this.kill_button.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kill_button.Location = new System.Drawing.Point(414, 466);
            this.kill_button.Name = "kill_button";
            this.kill_button.Size = new System.Drawing.Size(161, 42);
            this.kill_button.TabIndex = 3;
            this.kill_button.Text = "Kill Monitor";
            this.kill_button.UseVisualStyleBackColor = false;
            this.kill_button.Click += new System.EventHandler(this.kill_button_Click);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.ControlBox = false;
            this.Controls.Add(this.hide_button);
            this.Controls.Add(this.kill_button);
            this.Controls.Add(this.TextBox_Events);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonitorForm";
            this.Text = "BigBoxMonitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
            this.Load += new System.EventHandler(this.MonitorForm_Load);
            this.Shown += new System.EventHandler(this.MonitorForm_Shown);
            this.Resize += new System.EventHandler(this.MonitorForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Events;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowMonitorMenuItem;
        private System.Windows.Forms.Button hide_button;
        private System.Windows.Forms.Button kill_button;
    }
}

