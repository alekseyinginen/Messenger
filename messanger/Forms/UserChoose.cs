using Messenger.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger.Forms
{
    public partial class UserChoose : MetroFramework.Forms.MetroForm
    {
        public string name;
        private List<UserModel> users;
        public UserChoose(List<UserModel> users)
        {
            InitializeComponent();
            this.users = users;

            FillUsers();
        }

        private void FillUsers()
        {
            foreach(var user in users)
            {
                ComboBox.Items.Add(user.Username);
            }
        }

        public string GetUser()
        {
            var selectedUsername = ComboBox.SelectedItem as string;

            return selectedUsername;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = GetUser();
            this.Close();
        }
    }
}
