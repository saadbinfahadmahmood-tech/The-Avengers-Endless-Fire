using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game.UI;

namespace Game
{
    public partial class Main : Form
    {
        public static Panel MainPanel;
        public Main()
        {
            InitializeComponent();
            MainPanel = PanelMain;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Form nextForm = new GameMenu();
            nextForm.Dock = DockStyle.Fill;
            nextForm.TopLevel = false;

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(nextForm);
            nextForm.Show();
        }

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
