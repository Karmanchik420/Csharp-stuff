namespace Lab1
{
    internal class Triangle
    {
        public void Run()
        {
            int a = 5;
            int b = 6;
            int c = 7;
            IsPositive(a, b, c);
            Console.WriteLine("-----");
            if (IsTriangle(a, b, c))
            {
                Console.WriteLine("Triangle exist.");
                Console.WriteLine("-----");
                Console.WriteLine("Perimeter is " + Perimeter(a, b, c) + ".");
                Console.WriteLine("-----");
                Console.WriteLine("Square is " + Square(a, b, c) + ".");
                Console.WriteLine("-----");
                TriangleType(a, b, c);
            }
            else
                Console.WriteLine("Triangle not exist.");

        }

        private void IsPositive(int a, int b, int c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                Console.WriteLine("All sides are positive numbers.");
            }
            else
            {
                Console.WriteLine("Not all sides are positive.");
            }
        }

        private bool IsTriangle(int a, int b, int c)
        {
            if ((a + b) > c || (b + c) > a || (a + c) > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int Perimeter(int a, int b, int c)
        {
            return a + b + c;
        }

        private double Square(int a, int b, int c)
        {
            double p = Perimeter(a, b, c) / 2;
            return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private int Max(int a, int b, int c)
        {
            int max = 0;
            if (a > max)
                max = a;
            else if (b > max)
                max = b;
            else
                max = c;
            return max;
        }

        private bool IsRight(int a, int b, int c)
        {
            int max = Max(a, b, c);
            if (a == max)
                return a * a == b * b + c * c;
            else if (b == max)
                return b * b == a * a + c * c;
            else if (c == max)
                return c * c == a * a + b * b;
            else
                return false;
        }

        private void TriangleType(int a, int b, int c)
        {
            if (a == b && b == c && a == c)
                Console.WriteLine("Triangle is equilateral.");
            else if (a == b || b == c || a == c)
                Console.WriteLine("Triangle is isosceles.");
            else if (IsRight(a,b,c))
                Console.WriteLine("Triangle is right.");
            else
                Console.WriteLine("Triangle is scalene.");
        }
    }
}
