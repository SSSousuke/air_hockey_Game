namespace air_hockey_Game
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.boostTimer = new System.Windows.Forms.Timer(this.components);
            this.cpuLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.cpuScoreLabel = new System.Windows.Forms.Label();
            this.playerScoreLabel = new System.Windows.Forms.Label();
            this.winloseLabel = new System.Windows.Forms.Label();
            this.startBackground = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.startLabel2 = new System.Windows.Forms.Label();
            this.easyButton = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.Button();
            this.difficultButton = new System.Windows.Forms.Button();
            this.gameResetTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // boostTimer
            // 
            this.boostTimer.Interval = 1;
            this.boostTimer.Tick += new System.EventHandler(this.boostTimer_Tick);
            // 
            // cpuLabel
            // 
            this.cpuLabel.BackColor = System.Drawing.Color.Transparent;
            this.cpuLabel.Font = new System.Drawing.Font("Bauhaus 93", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cpuLabel.Location = new System.Drawing.Point(115, 175);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(118, 54);
            this.cpuLabel.TabIndex = 1;
            this.cpuLabel.Text = "CPU";
            this.cpuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cpuLabel.Visible = false;
            this.cpuLabel.Click += new System.EventHandler(this.scoreLabel2_Click);
            // 
            // playerLabel
            // 
            this.playerLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerLabel.Font = new System.Drawing.Font("Bauhaus 93", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playerLabel.Location = new System.Drawing.Point(235, 328);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(178, 54);
            this.playerLabel.TabIndex = 2;
            this.playerLabel.Text = "PLAYER";
            this.playerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerLabel.Visible = false;
            // 
            // cpuScoreLabel
            // 
            this.cpuScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.cpuScoreLabel.Font = new System.Drawing.Font("Bauhaus 93", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cpuScoreLabel.Location = new System.Drawing.Point(127, 219);
            this.cpuScoreLabel.Name = "cpuScoreLabel";
            this.cpuScoreLabel.Size = new System.Drawing.Size(93, 119);
            this.cpuScoreLabel.TabIndex = 3;
            this.cpuScoreLabel.Text = "0";
            this.cpuScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cpuScoreLabel.Visible = false;
            // 
            // playerScoreLabel
            // 
            this.playerScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerScoreLabel.Font = new System.Drawing.Font("Bauhaus 93", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playerScoreLabel.Location = new System.Drawing.Point(270, 219);
            this.playerScoreLabel.Name = "playerScoreLabel";
            this.playerScoreLabel.Size = new System.Drawing.Size(93, 119);
            this.playerScoreLabel.TabIndex = 4;
            this.playerScoreLabel.Text = "0";
            this.playerScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playerScoreLabel.Visible = false;
            // 
            // winloseLabel
            // 
            this.winloseLabel.BackColor = System.Drawing.Color.Transparent;
            this.winloseLabel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winloseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.winloseLabel.Location = new System.Drawing.Point(134, 396);
            this.winloseLabel.Name = "winloseLabel";
            this.winloseLabel.Size = new System.Drawing.Size(232, 54);
            this.winloseLabel.TabIndex = 5;
            this.winloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winloseLabel.Visible = false;
            // 
            // startBackground
            // 
            this.startBackground.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.startBackground.Font = new System.Drawing.Font("Bauhaus 93", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBackground.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.startBackground.Location = new System.Drawing.Point(-7, -19);
            this.startBackground.Name = "startBackground";
            this.startBackground.Size = new System.Drawing.Size(538, 674);
            this.startBackground.TabIndex = 6;
            this.startBackground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLabel
            // 
            this.startLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.startLabel.Font = new System.Drawing.Font("Bauhaus 93", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.startLabel.Location = new System.Drawing.Point(52, 99);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(397, 58);
            this.startLabel.TabIndex = 7;
            this.startLabel.Text = "AIR HOCKEY";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLabel2
            // 
            this.startLabel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.startLabel2.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.startLabel2.Location = new System.Drawing.Point(52, 207);
            this.startLabel2.Name = "startLabel2";
            this.startLabel2.Size = new System.Drawing.Size(397, 58);
            this.startLabel2.TabIndex = 8;
            this.startLabel2.Text = "Choose the Level";
            this.startLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyButton.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(163, 303);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(175, 48);
            this.easyButton.TabIndex = 9;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // normalButton
            // 
            this.normalButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.normalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalButton.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalButton.Location = new System.Drawing.Point(163, 369);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(175, 48);
            this.normalButton.TabIndex = 10;
            this.normalButton.Text = "Normal";
            this.normalButton.UseVisualStyleBackColor = false;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // difficultButton
            // 
            this.difficultButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.difficultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficultButton.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultButton.Location = new System.Drawing.Point(163, 435);
            this.difficultButton.Name = "difficultButton";
            this.difficultButton.Size = new System.Drawing.Size(175, 48);
            this.difficultButton.TabIndex = 11;
            this.difficultButton.Text = "Difficult";
            this.difficultButton.UseVisualStyleBackColor = false;
            this.difficultButton.Click += new System.EventHandler(this.difficultButton_Click);
            // 
            // gameResetTimer
            // 
            this.gameResetTimer.Interval = 10;
            this.gameResetTimer.Tick += new System.EventHandler(this.gameResetTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::air_hockey_Game.Properties.Resources.icehockey_filed;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(500, 555);
            this.Controls.Add(this.difficultButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.startLabel2);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.startBackground);
            this.Controls.Add(this.winloseLabel);
            this.Controls.Add(this.playerScoreLabel);
            this.Controls.Add(this.cpuScoreLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.cpuLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer boostTimer;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label cpuScoreLabel;
        private System.Windows.Forms.Label playerScoreLabel;
        private System.Windows.Forms.Label winloseLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label startBackground;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label startLabel2;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button difficultButton;
        private System.Windows.Forms.Timer gameResetTimer;
    }
}

