namespace Game.UI
{
    partial class GamePlay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.pbHeroHealth = new System.Windows.Forms.ProgressBar();
            this.pbVillainHealth = new System.Windows.Forms.ProgressBar();
            this.lblHeroName = new System.Windows.Forms.Label();
            this.lblVillainName = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // pbHeroHealth
            // 
            this.pbHeroHealth.ForeColor = System.Drawing.Color.LimeGreen;
            this.pbHeroHealth.Location = new System.Drawing.Point(97, 38);
            this.pbHeroHealth.Name = "pbHeroHealth";
            this.pbHeroHealth.Size = new System.Drawing.Size(220, 22);
            this.pbHeroHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbHeroHealth.TabIndex = 10;
            this.pbHeroHealth.Value = 100;
            // 
            // pbVillainHealth
            // 
            this.pbVillainHealth.ForeColor = System.Drawing.Color.OrangeRed;
            this.pbVillainHealth.Location = new System.Drawing.Point(1030, 32);
            this.pbVillainHealth.Maximum = 200;
            this.pbVillainHealth.Name = "pbVillainHealth";
            this.pbVillainHealth.Size = new System.Drawing.Size(220, 22);
            this.pbVillainHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbVillainHealth.TabIndex = 11;
            this.pbVillainHealth.Value = 200;
            // 
            // lblHeroName
            // 
            this.lblHeroName.AutoSize = true;
            this.lblHeroName.BackColor = System.Drawing.Color.Transparent;
            this.lblHeroName.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeroName.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblHeroName.Location = new System.Drawing.Point(97, 16);
            this.lblHeroName.Name = "lblHeroName";
            this.lblHeroName.Size = new System.Drawing.Size(73, 19);
            this.lblHeroName.TabIndex = 13;
            this.lblHeroName.Text = "HERO HP";
            // 
            // lblVillainName
            // 
            this.lblVillainName.AutoSize = true;
            this.lblVillainName.BackColor = System.Drawing.Color.Transparent;
            this.lblVillainName.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.lblVillainName.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblVillainName.Location = new System.Drawing.Point(1030, 10);
            this.lblVillainName.Name = "lblVillainName";
            this.lblVillainName.Size = new System.Drawing.Size(83, 19);
            this.lblVillainName.TabIndex = 14;
            this.lblVillainName.Text = "ENEMY HP";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(540, 10);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(82, 25);
            this.lblScore.TabIndex = 12;
            this.lblScore.Text = "Score: 0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.lblLevel.ForeColor = System.Drawing.Color.Gold;
            this.lblLevel.Location = new System.Drawing.Point(556, 40);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(63, 20);
            this.lblLevel.TabIndex = 15;
            this.lblLevel.Text = "Level: 1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(496, 311);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 45);
            this.lblStatus.TabIndex = 12;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Navy;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(79, 41);
            this.btnBack.TabIndex = 16;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            //this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseClick);
            // 
            // GamePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game.Properties.Resources.GameBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblVillainName);
            this.Controls.Add(this.pbVillainHealth);
            this.Controls.Add(this.lblHeroName);
            this.Controls.Add(this.pbHeroHealth);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GamePlay";
            this.Text = "GamePlay";
            this.Load += new System.EventHandler(this.GamePlay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.ProgressBar pbHeroHealth;
        private System.Windows.Forms.ProgressBar pbVillainHealth;
        private System.Windows.Forms.Label lblHeroName;
        private System.Windows.Forms.Label lblVillainName;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnBack;
    }
}
