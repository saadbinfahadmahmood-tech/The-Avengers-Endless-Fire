using Game.GamePlay;
using System;
using System.Windows.Forms;

namespace Game.UI
{
    public partial class CharactersSelection : Form
    {

        public CharactersSelection()
        {
            InitializeComponent();
        }

        private void NavigateToMenu(enums.Characters selectedHero)
        {
            GameBL.ChangePlayer(selectedHero);

            Form nextForm = new GameMenu();
            nextForm.Dock = DockStyle.Fill;
            nextForm.TopLevel = false;

            Main.MainPanel.Controls.Clear();
            Main.MainPanel.Controls.Add(nextForm);
            nextForm.Show();
        }

        private void btnIronMan_Click(object sender, EventArgs e)
        {
            NavigateToMenu(enums.Characters.IronMan);
        }

        private void btnThor_Click(object sender, EventArgs e)
        {
            NavigateToMenu(enums.Characters.Thor);
        }

        private void btnCaptionAmerica_Click(object sender, EventArgs e)
        {
            NavigateToMenu(enums.Characters.CaptionAmerica);
        }

        private void btnHulk_Click(object sender, EventArgs e)
        {
            NavigateToMenu(enums.Characters.Hulk);
        }

        private void btnSpiderMan_Click(object sender, EventArgs e)
        {
            NavigateToMenu(enums.Characters.SpiderMan);
        }
    }
}
