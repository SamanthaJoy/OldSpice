using System;
using System.Windows.Forms;

namespace OldSpice
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("If you need technical support or would like to report a bug, contact support@gruntmods.com");
        }
    }
}
