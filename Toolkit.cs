using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OldSpice
{
    public partial class Toolkit : Form
    {
        public Toolkit()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //used for inheriting methods from main form
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("");
            inherited.ProcessStart(d2kEditor);
        }
    }
}
