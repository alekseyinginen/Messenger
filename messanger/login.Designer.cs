namespace Messenger
{
    partial class login
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
            this.Log = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameInput = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ErrorMessageLable = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Log.Location = new System.Drawing.Point(98, 41);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(285, 28);
            this.Log.TabIndex = 3;
            this.Log.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Password.Location = new System.Drawing.Point(7, 105);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(81, 21);
            this.Password.TabIndex = 2;
            this.Password.Text = "Password";
            // 
            // Pass
            // 
            this.Pass.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass.Location = new System.Drawing.Point(98, 101);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(285, 28);
            this.Pass.TabIndex = 1;
            this.Pass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // UserNameInput
            // 
            this.UserNameInput.Font = new System.Drawing.Font("Tahoma", 9F);
            this.UserNameInput.Location = new System.Drawing.Point(294, 242);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.Size = new System.Drawing.Size(143, 40);
            this.UserNameInput.TabIndex = 2;
            this.UserNameInput.Text = "Sign In";
            this.UserNameInput.UseVisualStyleBackColor = true;
            this.UserNameInput.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.button3.Location = new System.Drawing.Point(145, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Sign Up";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Password);
            this.panel2.Controls.Add(this.Pass);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Log);
            this.panel2.Location = new System.Drawing.Point(54, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 139);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(344, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // ErrorMessageLable
            // 
            this.ErrorMessageLable.AutoSize = true;
            this.ErrorMessageLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ErrorMessageLable.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessageLable.Location = new System.Drawing.Point(88, 204);
            this.ErrorMessageLable.Name = "ErrorMessageLable";
            this.ErrorMessageLable.Size = new System.Drawing.Size(0, 20);
            this.ErrorMessageLable.TabIndex = 4;
            this.ErrorMessageLable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 311);
            this.Controls.Add(this.ErrorMessageLable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UserNameInput);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "login";
            this.TransparencyKey = System.Drawing.Color.LightSlateGray;
            this.Load += new System.EventHandler(this.login_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserNameInput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ErrorMessageLable;
    }
}