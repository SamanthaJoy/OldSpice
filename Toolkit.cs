using System;
using System.Linq;
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

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\D2K Editor (Map and Mis)\D2kEditor.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\Map Renderer\MapRenderer.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\Mission Editor\MissionEditorV0.3.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\Resource Editor\ResourceEditor.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\Sound Effect Tool\SoundEffectToolV0.1.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\Table Editor (UIB)\UITableEditorV0.3.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\Tileset Editor\TileSetEditorV0.1.exe");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var inherited = Application.OpenForms.OfType<OSL>().Single();

            string d2kEditor = inherited.getRegistryValue("D2K+");
            inherited.ProcessStart(d2kEditor + @"\User Interface Editor\UILEditorV0.1.exe");
        }
    }
}
