using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace air_hockey_Game
{
    public partial class Form1 : Form
    {
        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        SolidBrush darkblueBrush = new SolidBrush(Color.FromArgb(35, 52, 87));
        SolidBrush blueBrush = new SolidBrush(Color.FromArgb(56, 83, 138));
        SolidBrush orangeBrush = new SolidBrush(Color.FromArgb(241, 107, 23));
        SolidBrush darkorangeBrush = new SolidBrush(Color.FromArgb(130, 54, 8));
        SolidBrush lightblackBrush = new SolidBrush(Color.FromArgb(64, 64, 64));
        SolidBrush brownBrush = new SolidBrush(Color.FromArgb(65, 52, 39));
        SolidBrush transparentBrush = new SolidBrush(Color.Transparent);

        //Cpu
        Rectangle cpuhighlight = new Rectangle(118, 38, 39, 39);
        Rectangle cpu = new Rectangle(115, 35, 45, 45);
        Rectangle bottomcpu = new Rectangle(125, 35, 25, 10);
        Rectangle topcpu = new Rectangle(125, 70, 25, 10);
        Rectangle rightcpu = new Rectangle(150, 45, 10, 25);
        Rectangle leftcpu = new Rectangle(115, 45, 10, 25);
        Rectangle bottomleftcpu = new Rectangle(115, 35, 10, 10);
        Rectangle bottomrightcpu = new Rectangle(150, 35, 10, 10);
        Rectangle topleftcpu = new Rectangle(115, 70, 10, 10);
        Rectangle toprightcpu = new Rectangle(150, 70, 10, 10);

        //Player
        Rectangle playerhighlight = new Rectangle(228, 368, 39, 39);
        Rectangle player = new Rectangle(225, 365, 45, 45);
        Rectangle topplayer = new Rectangle(235, 365, 25, 10);
        Rectangle bottomplayer = new Rectangle(235, 400, 25, 10);
        Rectangle rightplayer = new Rectangle(260, 375, 10, 25);
        Rectangle leftplayer = new Rectangle(225, 375, 10, 25);
        Rectangle topleftplayer = new Rectangle(225, 365, 10, 10);
        Rectangle toprightplayer = new Rectangle(260, 365, 10, 10);
        Rectangle bottomleftplayer = new Rectangle(225, 400, 10, 10);
        Rectangle bottomrightplayer = new Rectangle(260, 400, 10, 10);

        //Ball
        Rectangle ball = new Rectangle(175, 210, 20, 20);

        //Wall
        Rectangle topwall1 = new Rectangle(0, 0, 125, 10);
        Rectangle topwall2 = new Rectangle(250, 0, 150, 10);
        Rectangle leftwall = new Rectangle(0, 0, 10, 560);
        Rectangle rightwall = new Rectangle(365, 0, 10, 560);
        Rectangle bottomwall1 = new Rectangle(0, 435, 125, 10);
        Rectangle bottomwall2 = new Rectangle(250, 435, 150, 10);

        //Sound
        SoundPlayer win = new SoundPlayer(Properties.Resources.winSound);
        SoundPlayer lose = new SoundPlayer(Properties.Resources.loseSound);
        SoundPlayer hit = new SoundPlayer(Properties.Resources.hitSound);

        int ballXSpeed = 0;
        int ballYSpeed = 2;
        int playerSpeed = 6;

        int boostsystem = 0;
        int count = 0;
        int resetcount = 0;

        int cpunormalsystem = 1;
        string cpusystem = "";
        string game = "";

        int playerscore = 0;
        int cpuscore = 0;
        public Form1()
        {
            InitializeComponent();
            gameTimer.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Cpu
            e.Graphics.FillEllipse(darkorangeBrush, cpu);
            e.Graphics.FillEllipse(orangeBrush, cpuhighlight);
            //Player
            e.Graphics.FillEllipse(darkblueBrush, player);
            e.Graphics.FillEllipse(blueBrush, playerhighlight);
            //Ball
            e.Graphics.FillEllipse(lightblackBrush, ball);
            //Wall
            e.Graphics.FillRectangle(brownBrush, topwall1);
            e.Graphics.FillRectangle(brownBrush, topwall2);
            e.Graphics.FillRectangle(brownBrush, leftwall);
            e.Graphics.FillRectangle(brownBrush, rightwall);
            e.Graphics.FillRectangle(brownBrush, bottomwall1);
            e.Graphics.FillRectangle(brownBrush, bottomwall2);
            //Player sensor
            e.Graphics.FillRectangle(transparentBrush, topplayer);
            e.Graphics.FillRectangle(transparentBrush, bottomplayer);
            e.Graphics.FillRectangle(transparentBrush, rightplayer);
            e.Graphics.FillRectangle(transparentBrush, leftplayer);
            e.Graphics.FillRectangle(transparentBrush, topleftplayer);
            e.Graphics.FillRectangle(transparentBrush, toprightplayer);
            e.Graphics.FillRectangle(transparentBrush, bottomleftplayer);
            e.Graphics.FillRectangle(transparentBrush, bottomrightplayer);
            //Cpu sensor
            e.Graphics.FillRectangle(transparentBrush, topcpu);
            e.Graphics.FillRectangle(transparentBrush, bottomcpu);
            e.Graphics.FillRectangle(transparentBrush, leftcpu);
            e.Graphics.FillRectangle(transparentBrush, rightcpu);
            e.Graphics.FillRectangle(transparentBrush, topleftcpu);
            e.Graphics.FillRectangle(transparentBrush, toprightcpu);
            e.Graphics.FillRectangle(transparentBrush, bottomleftcpu);
            e.Graphics.FillRectangle(transparentBrush, bottomrightcpu);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move ball 
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move player
            if (wDown == true && player.Y > 10)
            {
                player.Y -= playerSpeed;
                playerhighlight.Y -= playerSpeed;
                rightplayer.Y -= playerSpeed;
                leftplayer.Y -= playerSpeed;
                topplayer.Y -= playerSpeed;
                bottomplayer.Y -= playerSpeed;
                topleftplayer.Y -= playerSpeed;
                toprightplayer.Y -= playerSpeed;
                bottomleftplayer.Y -= playerSpeed;
                bottomrightplayer.Y -= playerSpeed;
            }

            if (sDown == true && player.Y < this.Height - player.Height - 10)
            {
                player.Y += playerSpeed;
                playerhighlight.Y += playerSpeed;
                rightplayer.Y += playerSpeed;
                leftplayer.Y += playerSpeed;
                topplayer.Y += playerSpeed;
                bottomplayer.Y += playerSpeed;
                topleftplayer.Y += playerSpeed;
                toprightplayer.Y += playerSpeed;
                bottomleftplayer.Y += playerSpeed;
                bottomrightplayer.Y += playerSpeed;
            }

            if (aDown == true && player.X > 10)
            {
                player.X -= playerSpeed;
                playerhighlight.X -= playerSpeed;
                rightplayer.X -= playerSpeed;
                leftplayer.X -= playerSpeed;
                topplayer.X -= playerSpeed;
                bottomplayer.X -= playerSpeed;
                topleftplayer.X -= playerSpeed;
                toprightplayer.X -= playerSpeed;
                bottomleftplayer.X -= playerSpeed;
                bottomrightplayer.X -= playerSpeed;
            }

            if (dDown == true && player.X < this.Width - player.Width - 10)
            {
                player.X += playerSpeed;
                playerhighlight.X += playerSpeed;
                rightplayer.X += playerSpeed;
                leftplayer.X += playerSpeed;
                topplayer.X += playerSpeed;
                bottomplayer.X += playerSpeed;
                topleftplayer.X += playerSpeed;
                toprightplayer.X += playerSpeed;
                bottomleftplayer.X += playerSpeed;
                bottomrightplayer.X += playerSpeed;
            }

            //move cpu
            if (cpusystem == "easy")
            {
                cpu.X = 170;
                cpuhighlight.X = 173;
                topcpu.X = 180;
                bottomcpu.X = 180;
                rightcpu.X = 205;
                leftcpu.X = 170;
                topleftcpu.X = 170;
                toprightcpu.X = 205;
                bottomleftcpu.X = 170;
                bottomrightcpu.X = 205;
            }

            else if (cpusystem == "normal")
            {
                if (cpunormalsystem == 1)
                {
                    cpu.X++;
                    cpuhighlight.X++;
                    topcpu.X++;
                    bottomcpu.X++;
                    rightcpu.X++;
                    leftcpu.X++;
                    topleftcpu.X++;
                    toprightcpu.X++;
                    bottomleftcpu.X++;
                    bottomrightcpu.X++;
                    if (cpu.X == 225)
                    {
                        cpunormalsystem = 2;
                    }
                }

                else if (cpunormalsystem == 2)
                {
                    cpu.X--;
                    cpuhighlight.X--;
                    topcpu.X--;
                    bottomcpu.X--;
                    rightcpu.X--;
                    leftcpu.X--;
                    topleftcpu.X--;
                    toprightcpu.X--;
                    bottomleftcpu.X--;
                    bottomrightcpu.X--;
                    if (cpu.X == 115)
                    {
                        cpunormalsystem = 1;
                    }
                }
            }

            else if (cpusystem == "difficult")
            {
                if (ball.X >= 115 && ball.X <= 225)
                {
                    cpu.X = ball.X;
                    cpuhighlight.X = ball.X + 3;
                    topcpu.X = ball.X + 10;
                    bottomcpu.X = ball.X + 10;
                    rightcpu.X = ball.X + 35;
                    leftcpu.X = ball.X;
                    topleftcpu.X = ball.X;
                    toprightcpu.X = ball.X + 35;
                    bottomleftcpu.X = ball.X;
                    bottomrightcpu.X = ball.X + 35;
                }

                else if (ball.X < 115)
                {
                    cpu.X = 115;
                    cpuhighlight.X = 118;
                    topcpu.X = 125;
                    bottomcpu.X = 125;
                    rightcpu.X = 150;
                    leftcpu.X = 115;
                    topleftcpu.X = 115;
                    toprightcpu.X = 150;
                    bottomleftcpu.X = 115;
                    bottomrightcpu.X = 150;
                }

                else if (ball.X > 225)
                {
                    cpu.X = 225;
                    cpuhighlight.X = 228;
                    topcpu.X = 235;
                    bottomcpu.X = 235;
                    rightcpu.X = 260;
                    leftcpu.X = 225;
                    topleftcpu.X = 225;
                    toprightcpu.X = 260;
                    bottomleftcpu.X = 225;
                    bottomrightcpu.X = 260;
                }
            }
            //Check if the ball hit to the topwall
            if (ball.Y < 10 && ball.X > 10 && ball.X < 120)
            {
                //Change direction
                boostTimer.Enabled = false;
                ballYSpeed *= -1;
                ball.Y = 10;

                //Check the ball ballYspeed = 2
                if (ballYSpeed == 2 && ballXSpeed == Math.Abs(2) || ballYSpeed == 2 && ballXSpeed == 0) { }
                else if (ballYSpeed > 2 && ballXSpeed == Math.Abs(2))
                {
                    boostsystem = 2;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed > 2 && ballXSpeed == 0)
                {
                    boostsystem = 2;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == 2 && ballXSpeed > 2)
                {
                    boostsystem = 3;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == 2 && ballXSpeed < -2)
                {
                    boostsystem = 4;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed > 2 && ballXSpeed > 2)
                {
                    boostsystem = 5;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed > 2 && ballXSpeed < -2)
                {
                    boostsystem = 6;
                    boostTimer.Enabled = true;
                }
            }

            //Check if the ball hit to the topwall
            if (ball.Y < 10 && ball.X > 240 && ball.X < this.Width - 10)
            {
                //Change direction
                hit.Play();
                boostTimer.Enabled = false;
                ballYSpeed *= -1;
                ball.Y = 10;

                //Check the ball ballYspeed = 2
                if (ballYSpeed == 2 && ballXSpeed == Math.Abs(2) || ballYSpeed == 2 && ballXSpeed == 0) { }
                else if (ballYSpeed > 2 && ballXSpeed == Math.Abs(2))
                {
                    boostsystem = 2;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed > 2 && ballXSpeed == 0)
                {
                    boostsystem = 2;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == 2 && ballXSpeed > 2)
                {
                    boostsystem = 3;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == 2 && ballXSpeed < -2)
                {
                    boostsystem = 4;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed > 2 && ballXSpeed > 2)
                {
                    boostsystem = 5;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed > 2 && ballXSpeed < -2)
                {
                    boostsystem = 6;
                    boostTimer.Enabled = true;
                }
            }

            //Check if the ball hit to the bottomwall
            if (ball.Y > this.Height - ball.Height - 10 && ball.X > 10 && ball.X < 120)
            {
                //Change direction
                hit.Play();
                boostTimer.Enabled = false;
                ballYSpeed *= -1;
                ball.Y = this.Height - ball.Height - 10;

                //Check the ball ballYspeed = -2
                if (ballYSpeed == -2 && ballXSpeed == Math.Abs(2) || ballYSpeed == -2 && ballXSpeed == 0) { }
                else if (ballYSpeed < -2 && ballXSpeed == Math.Abs(2))
                {
                    boostsystem = 1;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed < -2 && ballXSpeed == 0)
                {
                    boostsystem = 1;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == -2 && ballXSpeed > 2)
                {
                    boostsystem = 3;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == -2 && ballXSpeed < -2)
                {
                    boostsystem = 4;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed < -2 && ballXSpeed < -2)
                {
                    boostsystem = 7;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed < -2 && ballXSpeed > 2)
                {
                    boostsystem = 8;
                    boostTimer.Enabled = true;
                }
            }

            if (ball.Y > this.Height - ball.Height - 10 && ball.X > 240 && ball.X < this.Width - 10)
            {
                //Change direction
                hit.Play();
                boostTimer.Enabled = false;
                ballYSpeed *= -1;
                ball.Y = this.Height - ball.Height - 10;

                //Check the ball ballYspeed = -2
                if (ballYSpeed == -2 && ballXSpeed == Math.Abs(2) || ballYSpeed == -2 && ballXSpeed == 0) { }
                else if (ballYSpeed < -2 && ballXSpeed == Math.Abs(2))
                {
                    boostsystem = 1;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed < -2 && ballXSpeed == 0)
                {
                    boostsystem = 1;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == -2 && ballXSpeed > 2)
                {
                    boostsystem = 3;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed == -2 && ballXSpeed < -2)
                {
                    boostsystem = 4;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed < -2 && ballXSpeed < -2)
                {
                    boostsystem = 7;
                    boostTimer.Enabled = true;
                }

                else if (ballYSpeed < -2 && ballXSpeed > 2)
                {
                    boostsystem = 8;
                    boostTimer.Enabled = true;
                }
            }

            //Check if the ball hit to the leftwall
            if (ball.X < 10)
            {
                //Change direction
                hit.Play();
                boostTimer.Enabled = false;
                ballXSpeed *= -1;
                ball.X = 10;

                //Check the ball ballXspeed = 2
                if (ballXSpeed == 2 && ballYSpeed == Math.Abs(2) || ballXSpeed == 2 && ballYSpeed == 0) { }
                else if (ballXSpeed > 2 && ballXSpeed == Math.Abs(2))
                {
                    boostsystem = 3;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed > 2 && ballYSpeed == 0)
                {
                    boostsystem = 3;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed == 2 && ballYSpeed > 2)
                {
                    boostsystem = 2;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed == 2 && ballYSpeed < -2)
                {
                    boostsystem = 1;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed > 2 && ballYSpeed > 2)
                {
                    boostsystem = 5;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed > 2 && ballYSpeed < -2)
                {
                    boostsystem = 8;
                    boostTimer.Enabled = true;
                }
            }

            //Check if the ball hit to the rightwall
            if (ball.X > this.Width - ball.Width - 10)
            {
                //Change direction
                hit.Play();
                boostTimer.Enabled = false;
                ballXSpeed *= -1;
                ball.X = this.Width - ball.Width - 10;

                if (ballXSpeed == -2 && ballYSpeed == Math.Abs(2) || ballXSpeed == 2 && ballYSpeed == 0) { }
                else if (ballXSpeed < -2 && ballXSpeed == Math.Abs(2))
                {
                    boostsystem = 4;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed < -2 && ballYSpeed == 0)
                {
                    boostsystem = 4;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed == -2 && ballYSpeed > 2)
                {
                    boostsystem = 2;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed == -2 && ballYSpeed < -2)
                {
                    boostsystem = 1;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed < -2 && ballYSpeed < -2)
                {
                    boostsystem = 7;
                    boostTimer.Enabled = true;
                }

                else if (ballXSpeed < -2 && ballYSpeed > 2)
                {
                    boostsystem = 6;
                    boostTimer.Enabled = true;
                }
            }

            //check  if  balll hits  player. 
            if (topplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.Y = player.Y + 5;
                playerhighlight.Y = playerhighlight.Y + 5;
                rightplayer.Y = rightplayer.Y + 5;
                leftplayer.Y = leftplayer.Y + 5;
                topplayer.Y = topplayer.Y + 5;
                bottomplayer.Y = bottomplayer.Y + 5;
                topleftplayer.Y = topleftplayer.Y + 5;
                toprightplayer.Y = toprightplayer.Y + 5;
                bottomleftplayer.Y = bottomleftplayer.Y + 5;
                bottomrightplayer.Y = bottomrightplayer.Y + 5;
                ballYSpeed = -20;
                ballXSpeed = 0;
                boostsystem = 1;
                boostTimer.Enabled = true;
            }

            if (bottomplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.Y = player.Y - 5;
                playerhighlight.Y = playerhighlight.Y - 5;
                rightplayer.Y = rightplayer.Y - 5;
                leftplayer.Y = leftplayer.Y - 5;
                topplayer.Y = topplayer.Y - 5;
                bottomplayer.Y = bottomplayer.Y - 5;
                topleftplayer.Y = topleftplayer.Y - 5;
                toprightplayer.Y = toprightplayer.Y - 5;
                bottomleftplayer.Y = bottomleftplayer.Y - 5;
                bottomrightplayer.Y = bottomrightplayer.Y - 5;
                ballYSpeed = 20;
                ballXSpeed = 0;
                boostsystem = 2;
                boostTimer.Enabled = true;
            }

            if (rightplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.X = player.X - 5;
                playerhighlight.X = playerhighlight.X - 5;
                rightplayer.X = rightplayer.X - 5;
                leftplayer.X = leftplayer.X - 5;
                topplayer.X = topplayer.X - 5;
                bottomplayer.X = bottomplayer.X - 5;
                topleftplayer.X = topleftplayer.X - 5;
                toprightplayer.X = toprightplayer.X - 5;
                bottomleftplayer.X = bottomleftplayer.X - 5;
                bottomrightplayer.X = bottomrightplayer.X - 5;
                ballXSpeed = 20;
                ballYSpeed = 0;
                boostsystem = 3;
                boostTimer.Enabled = true;
            }

            if (leftplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.X = player.X + 5;
                playerhighlight.X = playerhighlight.X + 5;
                rightplayer.X = rightplayer.X + 5;
                leftplayer.X = leftplayer.X + 5;
                topplayer.X = topplayer.X + 5;
                bottomplayer.X = bottomplayer.X + 5;
                topleftplayer.X = topleftplayer.X + 5;
                toprightplayer.X = toprightplayer.X + 5;
                bottomleftplayer.X = bottomleftplayer.X + 5;
                bottomrightplayer.X = bottomrightplayer.X + 5;
                ballXSpeed = -20;
                ballYSpeed = 0;
                boostsystem = 4;
                boostTimer.Enabled = true;
            }

            if (topleftplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.Y = player.Y + 5;
                playerhighlight.Y = playerhighlight.Y + 5;
                rightplayer.Y = rightplayer.Y + 5;
                leftplayer.Y = leftplayer.Y + 5;
                topplayer.Y = topplayer.Y + 5;
                bottomplayer.Y = bottomplayer.Y + 5;
                topleftplayer.Y = topleftplayer.Y + 5;
                toprightplayer.Y = toprightplayer.Y + 5;
                bottomleftplayer.Y = bottomleftplayer.Y + 5;
                bottomrightplayer.Y = bottomrightplayer.Y + 5;
                player.X = player.X + 5;
                playerhighlight.X = playerhighlight.X + 5;
                rightplayer.X = rightplayer.X + 5;
                leftplayer.X = leftplayer.X + 5;
                topplayer.X = topplayer.X + 5;
                bottomplayer.X = bottomplayer.X + 5;
                topleftplayer.X = topleftplayer.X + 5;
                toprightplayer.X = toprightplayer.X + 5;
                bottomleftplayer.X = bottomleftplayer.X + 5;
                bottomrightplayer.X = bottomrightplayer.X + 5;
                ballXSpeed = -20;
                ballYSpeed = -20;
                boostsystem = 7;
                boostTimer.Enabled = true;
            }

            if (toprightplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.Y = player.Y + 5;
                playerhighlight.Y = playerhighlight.Y + 5;
                rightplayer.Y = rightplayer.Y + 5;
                leftplayer.Y = leftplayer.Y + 5;
                topplayer.Y = topplayer.Y + 5;
                bottomplayer.Y = bottomplayer.Y + 5;
                topleftplayer.Y = topleftplayer.Y + 5;
                toprightplayer.Y = toprightplayer.Y + 5;
                bottomleftplayer.Y = bottomleftplayer.Y + 5;
                bottomrightplayer.Y = bottomrightplayer.Y + 5;
                player.X = player.X - 5;
                playerhighlight.X = playerhighlight.X - 5;
                rightplayer.X = rightplayer.X - 5;
                leftplayer.X = leftplayer.X - 5;
                topplayer.X = topplayer.X - 5;
                bottomplayer.X = bottomplayer.X - 5;
                topleftplayer.X = topleftplayer.X - 5;
                toprightplayer.X = toprightplayer.X - 5;
                bottomleftplayer.X = bottomleftplayer.X - 5;
                bottomrightplayer.X = bottomrightplayer.X - 5;
                ballXSpeed = 20;
                ballYSpeed = -20;
                boostsystem = 8;
                boostTimer.Enabled = true;
            }

            if (bottomleftplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.Y = player.Y - 5;
                playerhighlight.Y = playerhighlight.Y - 5;
                rightplayer.Y = rightplayer.Y - 5;
                leftplayer.Y = leftplayer.Y - 5;
                topplayer.Y = topplayer.Y - 5;
                bottomplayer.Y = bottomplayer.Y - 5;
                topleftplayer.Y = topleftplayer.Y - 5;
                toprightplayer.Y = toprightplayer.Y - 5;
                bottomleftplayer.Y = bottomleftplayer.Y - 5;
                bottomrightplayer.Y = bottomrightplayer.Y - 5;
                player.X = player.X + 5;
                playerhighlight.X = playerhighlight.X + 5;
                rightplayer.X = rightplayer.X + 5;
                leftplayer.X = leftplayer.X + 5;
                topplayer.X = topplayer.X + 5;
                bottomplayer.X = bottomplayer.X + 5;
                topleftplayer.X = topleftplayer.X + 5;
                toprightplayer.X = toprightplayer.X + 5;
                bottomleftplayer.X = bottomleftplayer.X + 5;
                bottomrightplayer.X = bottomrightplayer.X + 5;
                ballXSpeed = -20;
                ballYSpeed = 20;
                boostsystem = 6;
                boostTimer.Enabled = true;
            }

            if (bottomrightplayer.IntersectsWith(ball))
            {
                hit.Play();
                player.Y = player.Y - 5;
                playerhighlight.Y = playerhighlight.Y - 5;
                rightplayer.Y = rightplayer.Y - 5;
                leftplayer.Y = leftplayer.Y - 5;
                topplayer.Y = topplayer.Y - 5;
                bottomplayer.Y = bottomplayer.Y - 5;
                topleftplayer.Y = topleftplayer.Y - 5;
                toprightplayer.Y = toprightplayer.Y - 5;
                bottomleftplayer.Y = bottomleftplayer.Y - 5;
                bottomrightplayer.Y = bottomrightplayer.Y - 5;
                player.X = player.X - 5;
                playerhighlight.X = playerhighlight.X - 5;
                rightplayer.X = rightplayer.X - 5;
                leftplayer.X = leftplayer.X - 5;
                topplayer.X = topplayer.X - 5;
                bottomplayer.X = bottomplayer.X - 5;
                topleftplayer.X = topleftplayer.X - 5;
                toprightplayer.X = toprightplayer.X - 5;
                bottomleftplayer.X = bottomleftplayer.X - 5;
                bottomrightplayer.X = bottomrightplayer.X - 5;
                ballXSpeed = 20;
                ballYSpeed = 20;
                boostsystem = 5;
                boostTimer.Enabled = true;
            }

            //check  if  balll hits  cpu.
            if (topcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = 0;
                ballYSpeed = 20;
                boostsystem = 2;
                boostTimer.Enabled = true;
            }

            if (bottomcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = 0;
                ballYSpeed = -20;
                boostsystem = 1;
                boostTimer.Enabled = true;
            }

            if (leftcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = -20;
                ballYSpeed = 0;
                boostsystem = 4;
                boostTimer.Enabled = true;
            }

            if (rightcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = 20;
                ballYSpeed = 0;
                boostsystem = 3;
                boostTimer.Enabled = true;
            }

            if (topleftcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = -20;
                ballYSpeed = 20;
                boostsystem = 6;
                boostTimer.Enabled = true;
            }

            if (toprightcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = 20;
                ballYSpeed = 20;
                boostsystem = 5;
                boostTimer.Enabled = true;
            }

            if (bottomleftcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = -20;
                ballYSpeed = -20;
                boostsystem = 7;
                boostTimer.Enabled = true;
            }

            if (bottomrightcpu.IntersectsWith(ball))
            {
                hit.Play();
                ballXSpeed = 20;
                ballYSpeed = -20;
                boostsystem = 8;
                boostTimer.Enabled = true;
            }

            //check if a player missed the ball and if true add 1 to score of other player 
            if (ball.Y < 0)
            {
                playerscore++;
                playerScoreLabel.Text = $"{playerscore}";

                cpuhighlight.X = 118;
                cpuhighlight.Y = 38;
                cpu.X = 115;
                cpu.Y = 35;
                bottomcpu.X = 125;
                bottomcpu.Y = 35;
                topcpu.X = 125;
                topcpu.Y = 70;
                rightcpu.X = 150;
                rightcpu.Y = 45;
                leftcpu.X = 115;
                leftcpu.Y = 45;
                bottomleftcpu.X = 115;
                bottomleftcpu.Y = 35;
                topleftcpu.X = 115;
                topleftcpu.Y = 70;
                toprightcpu.X = 150;
                toprightcpu.Y = 70;

                playerhighlight.X = 228;
                playerhighlight.Y = 368;
                player.X = 225;
                player.Y = 365;
                topplayer.X = 235;
                topplayer.Y = 365;
                bottomplayer.X = 235;
                bottomplayer.Y = 400;
                rightplayer.X = 260;
                rightplayer.Y = 375;
                leftplayer.X = 225;
                leftplayer.Y = 375;
                topleftplayer.X = 225;
                topleftplayer.Y = 365;
                toprightplayer.X = 260;
                toprightplayer.Y = 365;
                bottomleftplayer.X = 225;
                bottomleftplayer.Y = 400;
                bottomrightplayer.X = 260;
                bottomrightplayer.Y = 400;

                ball.X = 175;
                ball.Y = 210;
                boostTimer.Enabled = false;
                ballXSpeed = 2;
                ballYSpeed = 2;
                win.Play();
                playerScoreLabel.Show();
                cpuScoreLabel.Show();
                playerLabel.Show();
                cpuLabel.Show();
                gameTimer.Enabled = false;
                gameResetTimer.Enabled = true;
            }

            if (ball.Y > this.Height - ball.Height)
            {
                cpuscore++;
                cpuScoreLabel.Text = $"{cpuscore}";

                cpuhighlight.X = 118;
                cpuhighlight.Y = 38;
                cpu.X = 115;
                cpu.Y = 35;
                bottomcpu.X = 125;
                bottomcpu.Y = 35;
                topcpu.X = 125;
                topcpu.Y = 70;
                rightcpu.X = 150;
                rightcpu.Y = 45;
                leftcpu.X = 115;
                leftcpu.Y = 45;
                bottomleftcpu.X = 115;
                bottomleftcpu.Y = 35;
                topleftcpu.X = 115;
                topleftcpu.Y = 70;
                toprightcpu.X = 150;
                toprightcpu.Y = 70;

                playerhighlight.X = 228;
                playerhighlight.Y = 368;
                player.X = 225;
                player.Y = 365;
                topplayer.X = 235;
                topplayer.Y = 365;
                bottomplayer.X = 235;
                bottomplayer.Y = 400;
                rightplayer.X = 260;
                rightplayer.Y = 375;
                leftplayer.X = 225;
                leftplayer.Y = 375;
                topleftplayer.X = 225;
                topleftplayer.Y = 365;
                toprightplayer.X = 260;
                toprightplayer.Y = 365;
                bottomleftplayer.X = 225;
                bottomleftplayer.Y = 400;
                bottomrightplayer.X = 260;
                bottomrightplayer.Y = 400;

                ball.X = 175;
                ball.Y = 210;
                boostTimer.Enabled = false;
                ballXSpeed = 2;
                ballYSpeed = 2;
                lose.Play();
                playerScoreLabel.Show();
                cpuScoreLabel.Show();
                playerLabel.Show();
                cpuLabel.Show();
                gameTimer.Enabled= false;
                gameResetTimer.Start();
            }

            //Check score and end the game if either score is at 5
            if (playerscore == 5)
            {
                gameTimer.Enabled = false;
                winloseLabel.Show();
                winloseLabel.Text = "Player   Wins!!!";
                game = "end";
            }
            else if (cpuscore == 5)
            {
                gameTimer.Enabled = false;
                winloseLabel.Show();
                winloseLabel.Text = "CPU  Wins...";
                game = "end";
            }

            Refresh();
        }

        private void boostTimer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 8 == 0)
            {
                switch (boostsystem)
                {
                    //Change the ballYSpeed = -2
                    case 1:
                        if (ballYSpeed == -2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballYSpeed++;
                        }
                        break;

                    //Change the ballYSpeed = 2
                    case 2:
                        if (ballYSpeed == 2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballYSpeed--;
                        }
                        break;

                    //Change the ballXSpeed = 2
                    case 3:
                        if (ballXSpeed == 2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballXSpeed--;
                        }
                        break;

                    //Change the ballXSpeed = -2
                    case 4:
                        if (ballXSpeed == -2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballXSpeed++;
                        }
                        break;

                    //Change the ballX & ballY Speed = 2
                    case 5:
                        if (ballXSpeed == 2 && ballYSpeed == 2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballXSpeed--;
                            ballYSpeed--;
                        }
                        break;

                    //Change the ballXSpeed = -2 & ballY Speed = 2
                    case 6:
                        if (ballXSpeed == -2 && ballYSpeed == 2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballXSpeed++;
                            ballYSpeed--;
                        }
                        break;


                    //Change the ballX & ballY Speed = -2
                    case 7:
                        if (ballXSpeed == -2 && ballYSpeed == -2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballXSpeed++;
                            ballYSpeed++;
                        }
                        break;

                    //Change the ballXSpeed = 2 & ballYSpeed = -2
                    case 8:
                        if (ballXSpeed == 2 && ballYSpeed == -2)
                        {
                            boostTimer.Enabled = false;
                            count = 0;
                        }
                        else
                        {
                            ballXSpeed--;
                            ballYSpeed++;
                        }
                        break;
                }
            }
            Refresh();
        }

        private void scoreLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            cpusystem = "easy";
            game = "playing";
            startBackground.Visible = false;
            startLabel.Visible = false;
            startLabel2.Visible = false;
            easyButton.Visible = false;
            easyButton.Enabled= false;
            normalButton.Visible = false;
            normalButton.Enabled = false;
            difficultButton.Visible = false;
            difficultButton.Enabled = false;
            gameTimer.Start();
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            cpusystem = "normal";
            game = "playing";
            startBackground.Visible = false;
            startLabel.Visible = false;
            startLabel2.Visible = false;
            easyButton.Visible = false;
            easyButton.Enabled = false;
            normalButton.Visible = false;
            normalButton.Enabled = false;
            difficultButton.Visible = false;
            difficultButton.Enabled = false;
            gameTimer.Start();
        }

        private void difficultButton_Click(object sender, EventArgs e)
        {
            cpusystem = "difficult";
            game = "playing";
            startBackground.Visible = false;
            startLabel.Visible = false;
            startLabel2.Visible = false;
            easyButton.Visible = false;
            easyButton.Enabled = false;
            normalButton.Visible = false;
            normalButton.Enabled = false;
            difficultButton.Visible = false;
            difficultButton.Enabled = false;
            gameTimer.Start();
        }

        private void gameResetTimer_Tick(object sender, EventArgs e)
        {
            if (game == "end") { }

            else
            {
                resetcount++;
                if (resetcount == 200)
                {
                    resetcount = 0;
                    cpuLabel.Hide();
                    playerLabel.Hide();
                    cpuScoreLabel.Hide();
                    playerScoreLabel.Hide();
                    if (cpusystem == "normal")
                    {
                        cpunormalsystem = 1;
                    }
                    gameTimer.Enabled = true;
                    gameResetTimer.Enabled = false;
                }
            }
        }
    }
}
