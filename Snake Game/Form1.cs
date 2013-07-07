using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;




namespace Snake_Game
{
    public partial class Form1 : Form
    {
        Graphics paper;
        Snake snake = new Snake();
        bool left = false;
        bool right = true;
        bool up = false;
        bool down = false;
        SolidBrush brush_kulka = new SolidBrush(System.Drawing.Color.Green);
        bool highscorecontrol = false;
        GamePadState currentState;
        bool nono = true;
        
        
        

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            string[] can = new string[] {"ASFD", "FD", "DF"};
            can.ToList();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (timer1.Enabled == true)
            {
                paper = e.Graphics;
                snake.drawSnake(paper);
                snake.Kulka(paper);
                
                
             }
            
        }
        private void pad(bool nono)
        {
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);
            if (currentState.ThumbSticks.Left.Y <= -0.8 && up == false)
            {
                left = false;
                right = false;
                down = true;
                up = false;


            }
            if (currentState.ThumbSticks.Left.Y >= 0.8 && down == false)
            {
                left = false;
                right = false;
                up = true;
                down = false;

            }
            if ( currentState.ThumbSticks.Left.X >= 0.8 && left == false)
            {
                up = false;
                down = false;
                right = true;
                left = false;

            }
            if ( currentState.ThumbSticks.Left.X <= -0.8 && right == false)
            {
                left = true;
                up = false;
                down = false;
                right = false;

            }
            if (currentState.Buttons.Start == Microsoft.Xna.Framework.Input.ButtonState.Pressed && timer1.Enabled == false)
            {

                Snake snake1 = new Snake();
                snake = snake1;
                left = false;
                right = true;
                up = false;
                down = false;
                SolidBrush brush_kulka = new SolidBrush(System.Drawing.Color.Green);
                timer1.Enabled = true;
                snake.score = 0;
                label1.Text = "";
            }
            if (currentState.Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (timer1.Enabled == false)
                {
                    timer1.Enabled = true;
                }
                else
                {
                    timer1.Enabled = false;
                }

            }

           
            nono = false;
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if ((e.KeyData == System.Windows.Forms.Keys.Down || currentState.ThumbSticks.Left.Y <= -0.8) && up == false)
            {
                left = false;
                 right = false;
                 down = true;
                 up = false;

                
            }
            if ((e.KeyData == System.Windows.Forms.Keys.Up || currentState.ThumbSticks.Left.Y >= 0.8) && down == false)
            {
                left = false;
                right = false;
                 up = true;
                 down = false;

            }
            if ((e.KeyData == System.Windows.Forms.Keys.Right|| currentState.ThumbSticks.Left.X <= -0.8) && left == false)
            {
                 up = false;
                 down = false;
                 right = true;
                 left = false;

            }
             if ((e.KeyData == System.Windows.Forms.Keys.Left|| currentState.ThumbSticks.Left.X >= 0.8) && right == false)
            {
                 left = true;
                up = false;
                 down = false;
                 right = false;

            }
            if (e.KeyData == System.Windows.Forms.Keys.Space && timer1.Enabled == false)
            {
               
                Snake snake1 = new Snake();
                snake = snake1;
                left = false;
                right = true;
                up = false;
                down = false;
                SolidBrush brush_kulka = new SolidBrush(System.Drawing.Color.Green);
                timer1.Enabled = true;
                snake.score = 0;
                label1.Text = "";
            }
            if (e.KeyData == System.Windows.Forms.Keys.P)
            {
                if (timer1.Enabled == false)
                {
                    timer1.Enabled = true;
                }
                else
                {
                    timer1.Enabled = false;
                }
   
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {  
            if (down) { snake.MoveDown(); };
            if (up) { snake.MoveUp();};
            if (left) {snake.MoveLeft(); };
            if (right) { snake.MoveRight();};
            
            
            
            Gra();
            this.Invalidate();
        }
        public void Gra()
        {

           
            var score1 = Convert.ToString(snake.score);
            pasekwyniku.Text = score1;
            if (snake.snakeRec[0].X < 0 || snake.snakeRec[0].X > 260)
            {
                timer1.Enabled = false;
                highscorecontrol = true;
                MessageBox.Show("Przegrałeś, Twój wynik to " + score1);
                label1.Text = "Naciśnij spację aby rozpocząć!";
            }
            if (snake.snakeRec[0].Y < 0 || snake.snakeRec[0].Y > 260)
            {
                timer1.Enabled = false;
                highscorecontrol = true;
                MessageBox.Show("Przegrałeś, Twój wynik to "+ score1);
                label1.Text = "Naciśnij spację aby rozpocząć!";
            }
            foreach (var i in Enumerable.Range(1, snake.snakeRec.Count() -2))
            {
               
                    if (snake.snakeRec[0] == snake.snakeRec[i])
                    {
                        timer1.Enabled = false;
                        highscorecontrol = true;
                        MessageBox.Show("Przegrałeś, Twój wynik to " + score1);
                        label1.Text = "Naciśnij spację aby rozpocząć!";
                    }
               
            }


 if (label1.Text == "Naciśnij spację aby rozpocząć!" && highscorecontrol)
            {
                var file = File.ReadAllLines(@"C:\Users\Oni\Desktop\Pro\Snake's highscores.txt");
                var scores = new List<Int32> { };
                for (int i = 0; i < file.Length; i++)
                {
                    if (i != 0)
                    {
                        var half = file[i].Split(' ');
                        if (half[0] != "")
                        {
                            var score = Convert.ToInt32(half[1]);
                        scores.Add(score);
                        }
                        
                    }
                }
                scores.Add(snake.score);
                scores.Sort();
                scores.Reverse();
                var scoreses = new string[11];
                scoreses[0] = "Top 10 highest scores in Snake";
                for (int i = 0; i < 10; i++)
                {
                    if (i< scores.Count)
                    {
                        scoreses[i + 1] = (i + 1) + ". " + scores[i];
                    }
                    
                }
                File.WriteAllLines(@"C:\Users\Oni\Desktop\Pro\Snake's highscores.txt", scoreses);
 highscorecontrol = false;
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            var file = File.ReadAllLines(@"C:\Users\Oni\Desktop\Pro\Snake's highscores.txt");
            var scores = new List<Int32> { };
            for (int i = 0; i < file.Length; i++)
            {
                if (i!=0)
                {
                    var half = file[i].Split(' ');
                    if (half[0] != "")
                    {
                        var score = Convert.ToInt32(half[1]);
                        scores.Add(score);
                    }
                }
            }
            string b = "";
            foreach (var  i in file)
	{
        b += i + "\n";
    };
            MessageBox.Show(b);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            nono = true;
            pad(nono);

        }



    }
}
