namespace TCPListenerApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            txtPort = new TextBox();
            txtAddress = new TextBox();
            groupBox1 = new GroupBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Gray;
            btnStart.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(334, 118);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(147, 53);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtPort
            // 
            txtPort.BorderStyle = BorderStyle.FixedSingle;
            txtPort.Location = new Point(116, 58);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(283, 31);
            txtPort.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Location = new Point(416, 58);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(274, 31);
            txtAddress.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(116, 203);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(574, 237);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 452);
            Controls.Add(groupBox1);
            Controls.Add(txtAddress);
            Controls.Add(txtPort);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox txtPort;
        private TextBox txtAddress;
        private GroupBox groupBox1;
    }
}