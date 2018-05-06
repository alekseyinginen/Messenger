namespace Messenger.Forms
{
    partial class ClientForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.TextBox();
            this.MessageTextInput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(540, 406);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // Chat
            // 
            this.Chat.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chat.Location = new System.Drawing.Point(176, 74);
            this.Chat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Chat.Multiline = true;
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(422, 328);
            this.Chat.TabIndex = 2;
            this.Chat.TextChanged += new System.EventHandler(this.Chat_TextChanged);
            // 
            // textMessage
            // 
            this.MessageTextInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTextInput.Location = new System.Drawing.Point(176, 406);
            this.MessageTextInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MessageTextInput.Name = "textMessage";
            this.MessageTextInput.Size = new System.Drawing.Size(360, 29);
            this.MessageTextInput.TabIndex = 3;
            this.MessageTextInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textMessage_KeyDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(17, 440);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.LogoutButtonClick);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 487);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MessageTextInput);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ClientForm";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Chat;
        private System.Windows.Forms.TextBox MessageTextInput;
        private System.Windows.Forms.Button button2;
    }
}