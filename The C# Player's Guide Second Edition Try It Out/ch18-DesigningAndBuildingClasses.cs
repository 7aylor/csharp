using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningAndBuildingClasses
{
    class Color
    {
        private int red, green, blue, alpha;

        public Color(int r, int g, int b, int a)
        {
            this.red = r;
            this.green = g;
            this.blue = b;
            this.alpha = a;
        }

        public Color(int r, int g, int b)
        {
            this.red = r;
            this.green = g;
            this.blue = b;
            this.alpha = 255;
        }

        public int getRed()
        {
            return this.red;
        }
        public int getGreen()
        {
            return this.green;
        }
        public int getBlue()
        {
            return this.blue;
        }
        public int getAlpha()
        {
            return this.alpha;
        }
        public void setRed(int r)
        {
            this.red = r;
        }
        public void setGreen(int g)
        {
            this.green = g;
        }
        public void setBlue(int b)
        {
            this.blue = b;
        }
        public void setAlpha(int a)
        {
            this.alpha = a;
        }
        public int getGrayScale()
        {
            return (getRed() + getBlue() + getGreen() / 3);
        }
    }

    class Ball
    {
        private int radius, throws;
        private Color ballColor;

        public Ball(int r = 1, int t = 0)
        {
            this.radius = r;
            this.throws = t;
            this.ballColor = new Color(0, 0, 0, 0);
        }

        public Ball(int r, int t, Color c)
        {
            this.radius = r;
            this.throws = t;
            this.ballColor = c;
        }

        public void Pop()
        {
            this.radius = 0;
        }
        public void Throw()
        {
            if(radius != 0)
                this.throws++;
        }
        public int getThrows()
        {
            return this.throws;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Color c = new Color(15, 50, 100);
            Color c1 = new Color(100, 50, 15);
            Ball b = new Ball();
            Ball b1 = new Ball(5, 12, c1);
            Ball b2 = new Ball(13);
            Ball b3 = new Ball(6, 2, c);

            b.Throw();
            b.Throw();
            b.Throw();
            b.Throw();

            b1.Throw();

            b2.Pop();
            b3.Throw();
            b3.Throw();
            b3.Throw();
            b3.Throw();
            b3.Throw();
            b3.Throw();
            b3.Pop();

            b2.Throw();
            b2.Throw();
            b3.Throw();

            Console.WriteLine("Number of Throws");
            Console.WriteLine($"Ball 1: {b.getThrows()}");
            Console.WriteLine($"Ball 2: {b1.getThrows()}");
            Console.WriteLine($"Ball 3: {b2.getThrows()}");
            Console.WriteLine($"Ball 4: {b3.getThrows()}");

            Console.ReadKey();
        }
    }
}
