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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.Chat = new System.Windows.Forms.TextBox();
            this.MessageTextInput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameLable = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SortBox = new System.Windows.Forms.GroupBox();
            this.radioButtonByContext = new System.Windows.Forms.RadioButton();
            this.radioButtonByName = new System.Windows.Forms.RadioButton();
            this.radioButtonByDate = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SendMesseges = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxActiveGroup = new System.Windows.Forms.ComboBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchForUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SortBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendMesseges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.Chat, "Chat");
            this.Chat.Name = "Chat";
            this.Chat.ReadOnly = true;
            this.Chat.TextChanged += new System.EventHandler(this.Chat_TextChanges);
            // 
            // MessageTextInput
            // 
            resources.ApplyResources(this.MessageTextInput, "MessageTextInput");
            this.MessageTextInput.Name = "MessageTextInput";
            this.MessageTextInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextInputOnKeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.LogoutButtonClick);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // UsernameLable
            // 
            resources.ApplyResources(this.UsernameLable, "UsernameLable");
            this.UsernameLable.Name = "UsernameLable";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseDowm);
            // 
            // SortBox
            // 
            this.SortBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.SortBox, "SortBox");
            this.SortBox.Controls.Add(this.radioButtonByContext);
            this.SortBox.Controls.Add(this.radioButtonByName);
            this.SortBox.Controls.Add(this.radioButtonByDate);
            this.SortBox.Name = "SortBox";
            this.SortBox.TabStop = false;
            this.SortBox.Leave += new System.EventHandler(this.SortBox_Leave);
            // 
            // radioButtonByContext
            // 
            resources.ApplyResources(this.radioButtonByContext, "radioButtonByContext");
            this.radioButtonByContext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonByContext.Name = "radioButtonByContext";
            this.radioButtonByContext.UseVisualStyleBackColor = true;
            this.radioButtonByContext.CheckedChanged += new System.EventHandler(this.ByContextCheckedChanged);
            // 
            // radioButtonByName
            // 
            resources.ApplyResources(this.radioButtonByName, "radioButtonByName");
            this.radioButtonByName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonByName.Name = "radioButtonByName";
            this.radioButtonByName.UseVisualStyleBackColor = true;
            this.radioButtonByName.CheckedChanged += new System.EventHandler(this.ByNameCheckedChanged);
            // 
            // radioButtonByDate
            // 
            resources.ApplyResources(this.radioButtonByDate, "radioButtonByDate");
            this.radioButtonByDate.Checked = true;
            this.radioButtonByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonByDate.Name = "radioButtonByDate";
            this.radioButtonByDate.TabStop = true;
            this.radioButtonByDate.UseVisualStyleBackColor = true;
            this.radioButtonByDate.CheckedChanged += new System.EventHandler(this.ByDateCheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // SendMesseges
            // 
            this.SendMesseges.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.SendMesseges, "SendMesseges");
            this.SendMesseges.Name = "SendMesseges";
            this.SendMesseges.TabStop = false;
            this.SendMesseges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SendMesseges_MouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ComboBoxActiveGroup
            // 
            resources.ApplyResources(this.ComboBoxActiveGroup, "ComboBoxActiveGroup");
            this.ComboBoxActiveGroup.FormattingEnabled = true;
            this.ComboBoxActiveGroup.Name = "ComboBoxActiveGroup";
            this.ComboBoxActiveGroup.SelectedIndexChanged += new System.EventHandler(this.ComboBoxActiveGroup_SelectedIndexChanged);
            // 
            // SearchTextBox
            // 
            resources.ApplyResources(this.SearchTextBox, "SearchTextBox");
            this.SearchTextBox.Name = "SearchTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // SearchForUserButton
            // 
            this.SearchForUserButton.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.SearchForUserButton, "SearchForUserButton");
            this.SearchForUserButton.Name = "SearchForUserButton";
            this.SearchForUserButton.UseVisualStyleBackColor = false;
            this.SearchForUserButton.Click += new System.EventHandler(this.SearchForUserButton_Click);
            // 
            // ClientForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SearchForUserButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ComboBoxActiveGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SendMesseges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SortBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UsernameLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MessageTextInput);
            this.Controls.Add(this.Chat);
            this.Name = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SortBox.ResumeLayout(false);
            this.SortBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendMesseges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Chat;
        private System.Windows.Forms.TextBox MessageTextInput;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UsernameLable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox SortBox;
        private System.Windows.Forms.RadioButton radioButtonByContext;
        private System.Windows.Forms.RadioButton radioButtonByName;
        private System.Windows.Forms.RadioButton radioButtonByDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox SendMesseges;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxActiveGroup;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SearchForUserButton;
    }
}