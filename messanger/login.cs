using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.ApiClient;


namespace Messenger
{
    public partial class login : MetroFramework.Forms.MetroForm
    {
        MessengerApiClient apiClient;

        public login()
        {
            InitializeComponent();
            apiClient = MessengerApiClient.GetInstance();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register qwe = new Register();

            qwe.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = Log.Text;
            string password = Pass.Text;
            //apiClient.Register(username, "asd@asd.com", "", password).Wait();
            Task.Factory.StartNew(() => Login(username, password)).Wait();
            //apiClient.GetCurrentUser().Wait();
            //ClientForm ClientForm = new ClientForm();
            //ClientForm.Show();
            

        }

        private async Task Login(string username, string password)
        {
            var response = await apiClient.Login(username, password);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Darova petuh");
            }
            else 
            {
                ErrorMessageLable.Text = "Username or password are incorrect";
            }
        }
        
    }
}
