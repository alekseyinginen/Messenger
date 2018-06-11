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
    public partial class SearchForm : MetroFramework.Forms.MetroForm
    {
        private readonly Action<string> action;

        public SearchForm(Action<string> action)
        {
            InitializeComponent();

            this.action = action;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            action(string.Empty);
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            action(searchInput.Text);
            Close();
        }
    }
}
