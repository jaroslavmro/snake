using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake_Game
{
    class Snake
    {
        public Rectangle[] snakeRec;
        private SolidBrush brush, brush_kulka;
        private int x, y, width, height;
        int s = new Random().Next(729);
        public int score = 0;
        
        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Black);
            brush_kulka = new SolidBrush(Color.Green);

            x = 20;
            y = 0;
            width = 10;
            height = 10;
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }


        }
        public void drawSnake()
        {

            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];

            }
        }
        public void drawSnake2()
        {
            
                Rectangle[] so = new Rectangle[snakeRec.Length + 1];
                Rectangle ostatni = snakeRec[snakeRec.Length - 1];
                Rectangle pierwszy = snakeRec[0];
                for (int i = snakeRec.Length - 1; i > 0; i--)
                {
                    so[i] = snakeRec[i - 1];
                }
                so[0] = pierwszy;
                so[so.Length - 1] = ostatni;
                snakeRec = so;
                s = new Random().Next(729);
                score += 10;
               
           
        }
        public void drawSnake(Graphics paper)
        {
            foreach ( Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }
        }
       
        public void MoveDown()
        {
            if(!snakeRec[0].Equals(Kulka())){
            drawSnake();
            snakeRec[0].Y += 10;
        }
            else{
                drawSnake2();
            snakeRec[0].Y += 10;
            }
        }
        public void MoveUp()
        {
            if(!snakeRec[0].Equals(Kulka())){
            drawSnake();
            snakeRec[0].Y -= 10;}
             else{
                drawSnake2();
            snakeRec[0].Y -= 10;
            }
        }
        public void MoveLeft()
        {
            if(!snakeRec[0].Equals(Kulka())){
            drawSnake();
            snakeRec[0].X -= 10;
        }
         else{
                drawSnake2();
            snakeRec[0].X -= 10;
            }}
        public void MoveRight()
        {if(!snakeRec[0].Equals(Kulka())){
            drawSnake();
            snakeRec[0].X += 10;
        }
         else{
                drawSnake2();
            snakeRec[0].X += 10;
            }}
        public void Kulka(Graphics paper)
        {

            int r = s / 27;
            int n = s % 27;

            paper.FillRectangle(brush_kulka, r * 10, n * 10, 10, 10);

        }
        public Rectangle Kulka()
        {

            int r = s / 27;
            int n = s % 27;
            Rectangle nowy = new Rectangle(r * 10, n * 10, 10, 10);

            return  nowy;

        }
        
        


    }
}
