namespace NSFW_ProxyGUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SystemProxyLockBtn = new System.Windows.Forms.Button();
            this.SystemProxyPortTxt = new System.Windows.Forms.TextBox();
            this.SystemProxyAddressTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BackendAPILockBtn = new System.Windows.Forms.Button();
            this.BackendAPITxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BlacklistBtn = new System.Windows.Forms.Button();
            this.StartStopBtn = new System.Windows.Forms.Button();
            this.LogBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.SensitivityLevel = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SystemProxyLockBtn);
            this.groupBox1.Controls.Add(this.SystemProxyPortTxt);
            this.groupBox1.Controls.Add(this.SystemProxyAddressTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System proxy";
            // 
            // SystemProxyLockBtn
            // 
            this.SystemProxyLockBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemProxyLockBtn.Location = new System.Drawing.Point(324, 21);
            this.SystemProxyLockBtn.Name = "SystemProxyLockBtn";
            this.SystemProxyLockBtn.Size = new System.Drawing.Size(112, 55);
            this.SystemProxyLockBtn.TabIndex = 4;
            this.SystemProxyLockBtn.Text = "Lock";
            this.SystemProxyLockBtn.UseVisualStyleBackColor = true;
            this.SystemProxyLockBtn.Click += new System.EventHandler(this.SystemProxyLockBtn_Click);
            // 
            // SystemProxyPortTxt
            // 
            this.SystemProxyPortTxt.Location = new System.Drawing.Point(57, 56);
            this.SystemProxyPortTxt.Name = "SystemProxyPortTxt";
            this.SystemProxyPortTxt.Size = new System.Drawing.Size(261, 20);
            this.SystemProxyPortTxt.TabIndex = 3;
            // 
            // SystemProxyAddressTxt
            // 
            this.SystemProxyAddressTxt.Location = new System.Drawing.Point(57, 24);
            this.SystemProxyAddressTxt.Name = "SystemProxyAddressTxt";
            this.SystemProxyAddressTxt.Size = new System.Drawing.Size(261, 20);
            this.SystemProxyAddressTxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BackendAPILockBtn);
            this.groupBox2.Controls.Add(this.BackendAPITxt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backend API";
            // 
            // BackendAPILockBtn
            // 
            this.BackendAPILockBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackendAPILockBtn.Location = new System.Drawing.Point(324, 12);
            this.BackendAPILockBtn.Name = "BackendAPILockBtn";
            this.BackendAPILockBtn.Size = new System.Drawing.Size(112, 34);
            this.BackendAPILockBtn.TabIndex = 2;
            this.BackendAPILockBtn.Text = "Lock";
            this.BackendAPILockBtn.UseVisualStyleBackColor = true;
            this.BackendAPILockBtn.Click += new System.EventHandler(this.BackendAPILockBtn_Click);
            // 
            // BackendAPITxt
            // 
            this.BackendAPITxt.Location = new System.Drawing.Point(57, 20);
            this.BackendAPITxt.Name = "BackendAPITxt";
            this.BackendAPITxt.Size = new System.Drawing.Size(261, 20);
            this.BackendAPITxt.TabIndex = 1;
            this.BackendAPITxt.Text = "http://192.168.93.128:3000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Address";
            // 
            // BlacklistBtn
            // 
            this.BlacklistBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlacklistBtn.Location = new System.Drawing.Point(12, 207);
            this.BlacklistBtn.Name = "BlacklistBtn";
            this.BlacklistBtn.Size = new System.Drawing.Size(75, 23);
            this.BlacklistBtn.TabIndex = 2;
            this.BlacklistBtn.Text = "Blacklist";
            this.BlacklistBtn.UseVisualStyleBackColor = true;
            this.BlacklistBtn.Click += new System.EventHandler(this.BlacklistBtn_Click);
            // 
            // StartStopBtn
            // 
            this.StartStopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartStopBtn.Location = new System.Drawing.Point(255, 258);
            this.StartStopBtn.Name = "StartStopBtn";
            this.StartStopBtn.Size = new System.Drawing.Size(75, 23);
            this.StartStopBtn.TabIndex = 3;
            this.StartStopBtn.Text = "Start";
            this.StartStopBtn.UseVisualStyleBackColor = true;
            this.StartStopBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // LogBtn
            // 
            this.LogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogBtn.Location = new System.Drawing.Point(12, 259);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(37, 23);
            this.LogBtn.TabIndex = 4;
            this.LogBtn.Text = "Log";
            this.LogBtn.UseVisualStyleBackColor = true;
            this.LogBtn.Click += new System.EventHandler(this.LogBtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "at port";
            // 
            // PortTxt
            // 
            this.PortTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PortTxt.Location = new System.Drawing.Point(379, 260);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(69, 20);
            this.PortTxt.TabIndex = 6;
            this.PortTxt.Text = "8000";
            // 
            // SensitivityLevel
            // 
            this.SensitivityLevel.Location = new System.Drawing.Point(336, 207);
            this.SensitivityLevel.Maximum = 5;
            this.SensitivityLevel.Name = "SensitivityLevel";
            this.SensitivityLevel.Size = new System.Drawing.Size(104, 45);
            this.SensitivityLevel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sensitivity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 294);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SensitivityLevel);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.StartStopBtn);
            this.Controls.Add(this.BlacklistBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "NSFW Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SystemProxyPortTxt;
        private System.Windows.Forms.TextBox SystemProxyAddressTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SystemProxyLockBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BackendAPITxt;
        private System.Windows.Forms.Button BackendAPILockBtn;
        private System.Windows.Forms.Button BlacklistBtn;
        private System.Windows.Forms.Button StartStopBtn;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.TrackBar SensitivityLevel;
        private System.Windows.Forms.Label label5;
    }
}

