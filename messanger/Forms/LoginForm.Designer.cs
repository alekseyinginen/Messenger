namespace Messenger.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ErrorMessageLable = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameInput
            // 
            this.UsernameInput.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameInput.Location = new System.Drawing.Point(98, 45);
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(285, 28);
            this.UsernameInput.TabIndex = 1;
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
            // PasswordInput
            // 
            this.PasswordInput.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordInput.Location = new System.Drawing.Point(98, 101);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(285, 28);
            this.PasswordInput.TabIndex = 2;
            this.PasswordInput.UseSystemPasswordChar = true;
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
            this.button3.Click += new System.EventHandler(this.RegisterClickEvent);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Password);
            this.panel2.Controls.Add(this.PasswordInput);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.UsernameInput);
            this.panel2.Location = new System.Drawing.Point(54, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 139);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(446, 271);
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
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Login.Location = new System.Drawing.Point(297, 242);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(143, 40);
            this.Login.TabIndex = 3;
            this.Login.Text = "Sign In";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.LoginClickEvent);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 311);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.ErrorMessageLable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.TransparencyKey = System.Drawing.Color.LightSlateGray;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserNameInput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ErrorMessageLable;
        private System.Windows.Forms.Button Login;
    }
}