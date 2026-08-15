using Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void GameMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnCharacters_Click(object sender, EventArgs e)
        {
            Form nextForm = new CharactersSelection();
            nextForm.Dock = DockStyle.Fill;
            nextForm.TopLevel = false;

            Main.MainPanel.Controls.Clear();
            Main.MainPanel.Controls.Add(nextForm);
            nextForm.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form nextForm = new GamePlay();
            nextForm.Dock = DockStyle.Fill;
            nextForm.TopLevel = false;

            Main.MainPanel.Controls.Clear();
            Main.MainPanel.Controls.Add(nextForm);
            nextForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
