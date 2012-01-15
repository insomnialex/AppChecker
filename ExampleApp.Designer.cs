namespace ExampleApp
{
    partial class ExampleApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleApp));
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.textBox_application = new System.Windows.Forms.TextBox();
            this.button_select = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_log
            // 
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.HorizontalScrollbar = true;
            this.listBox_log.Location = new System.Drawing.Point(1, 28);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new System.Drawing.Size(620, 95);
            this.listBox_log.TabIndex = 0;
            // 
            // textBox_application
            // 
            this.textBox_application.Location = new System.Drawing.Point(1, 2);
            this.textBox_application.Name = "textBox_application";
            this.textBox_application.ReadOnly = true;
            this.textBox_application.Size = new System.Drawing.Size(390, 20);
            this.textBox_application.TabIndex = 2;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(397, 2);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 3;
            this.button_select.Text = "select";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(471, 2);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(546, 2);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 5;
            this.button_stop.Text = "stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // ExampleApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 124);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.textBox_application);
            this.Controls.Add(this.listBox_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExampleApp";
            this.Text = " - App Checker • alexquintero.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_log;
        private System.Windows.Forms.TextBox textBox_application;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_stop;
    }
}

