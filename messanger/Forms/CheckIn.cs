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
    public partial class CheckIn : MetroFramework.Forms.MetroForm
    {
        public static bool checkInOk { get; set; }
        public CheckIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RegisterForm.checkMail == textBox1.Text)
            {

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(RegisterForm.checkMail == textBox1.Text.Trim())
            {
                this.Hide();
                checkInOk = true;
            }
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {

        }
    }
}
