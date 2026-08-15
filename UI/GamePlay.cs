using System;
using System.Drawing;
using System.Windows.Forms;
using Game.GamePlay;

namespace Game.UI
{
    public partial class GamePlay : Form
    {
        public GamePlay()
        {
            InitializeComponent();
        }

        private void GamePlay_Load(object sender, EventArgs e)
        {
            GameBL gamePlay = new GameBL(this);
            GameBL.pbHeroHealth    = pbHeroHealth;
            GameBL.pbVillainHealth = pbVillainHealth;
            GameBL.lblScore        = lblScore;
            GameBL.lblLevel        = lblLevel;

            gamePlay.Start();

            GameLoop.Interval = 16;
            GameLoop.Start();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            GameBL.Update();

            if (GameBL.CurrentHero != null && GameBL.CurrentHero.isDead())
            {
                GameLoop.Stop();
                lblStatus.Text = "You were defeated!";
                NavigateToMenu();

            }


            if (GameBL.CurrentVillain != null && GameBL.CurrentVillain.isDead())
            {
                GameLoop.Stop();

                lblStatus.Text = "Enemy defeated! Starting next level...";
                Timer statusTimer = new Timer();
                statusTimer.Interval = 2000; 
                statusTimer.Tick += (s, args) =>
                {
                    lblStatus.Text = "";
                    statusTimer.Stop();
                };
                statusTimer.Start();

                GameBL.StartNextLevel();

                GameLoop.Start();
            }
        }

        private void NavigateToMenu()
        {
            Form nextForm = new GameMenu();
            nextForm.Dock = DockStyle.Fill;
            nextForm.TopLevel = false;

            Main.MainPanel.Controls.Clear();
            Main.MainPanel.Controls.Add(nextForm);
            nextForm.Show();
        }

        private void btnBack_MouseClick(object sender, MouseEventArgs e)
        {
            NavigateToMenu();
        }
    }
}
