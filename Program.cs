using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace Figures
{
    internal class Point
    {
        readonly int x_point;
        readonly int y_point;
        readonly string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int X_Point
        {
            get
            {
                return x_point;
            }
        }
        public int Y_Point
        {
            get
            {
                return y_point;
            }
        }
        public Point()
        { }
        public Point(int x, int y, string name)
        {
            x_point = x;
            y_point = y;
            this.name = name;
        }
    }
    internal class Figure
    {
        private List<Point> points = new List<Point>();
        private double perimetr;
        public double PerimetrFigure
        {
            get
            {
                return perimetr;
            }
        }
        public Figure(Point a_val, Point b_val, Point c_val)
        {
            points.Add(new Point(a_val.X_Point, a_val.Y_Point, a_val.Name));
            points.Add(new Point(b_val.X_Point, b_val.Y_Point, b_val.Name));
            points.Add(new Point(c_val.X_Point, c_val.Y_Point, c_val.Name));
            Perimetr();
        }
        public Figure(Point a_val, Point b_val, Point c_val, Point d_val)
        {
            points.Add(new Point(a_val.X_Point, a_val.Y_Point, a_val.Name));
            points.Add(new Point(b_val.X_Point, b_val.Y_Point, b_val.Name));
            points.Add(new Point(c_val.X_Point, c_val.Y_Point, c_val.Name));
            points.Add(new Point(d_val.X_Point, d_val.Y_Point, d_val.Name));
            Perimetr();
        }
        public Figure(Point a_val, Point b_val, Point c_val, Point d_val, Point e_val)
        {
            points.Add(new Point(a_val.X_Point, a_val.Y_Point, a_val.Name));
            points.Add(new Point(b_val.X_Point, b_val.Y_Point, b_val.Name));
            points.Add(new Point(c_val.X_Point, c_val.Y_Point, c_val.Name));
            points.Add(new Point(d_val.X_Point, d_val.Y_Point, d_val.Name));
            points.Add(new Point(e_val.X_Point, e_val.Y_Point, e_val.Name));
            Perimetr();
        }
        private void Perimetr()
        {
            switch (points.Count)
            {
                case 3:
                    perimetr = LenthSide(points[0], points[1]) + LenthSide(points[1], points[2]) +
                                        LenthSide(points[2], points[0]);

                    break;
                case 4:
                    perimetr = LenthSide(points[0], points[1]) + LenthSide(points[1], points[2]) +
                                        LenthSide(points[2], points[3]) + LenthSide(points[3], points[0]);
                    break;
                case 5:
                    perimetr = LenthSide(points[0], points[1]) + LenthSide(points[1], points[2]) +
                                        LenthSide(points[2], points[3]) + LenthSide(points[3], points[4]) +
                                        LenthSide(points[4], points[0]);
                    break;
            }
        }
        private double LenthSide(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow((point2.X_Point - point1.X_Point), 2) + Math.Pow((point2.Y_Point - point1.Y_Point), 2));
        }
    }

    class Program
    {
        private static int intParse;
        private static List<Point> points = new List<Point>();
        private static int xPoint, yPoint;
        private static string name;
        static void Main(string[] args)
        {
            Console.Write("Enter count of pairs points(min 3 | max 5)");
            try
            {
                if (Int32.TryParse(Console.ReadLine(), out intParse))
                {
                    int countOfPoints = intParse;
                    for (int i = 0; i < countOfPoints; i++)
                    {
                        Console.WriteLine("Pair {0}", i + 1);
                        Console.Write("\tX: ");
                        if (Int32.TryParse(Console.ReadLine(), out intParse))
                        {
                            xPoint = intParse;
                        }
                        else
                        {
                            throw new FormatException("Format error");
                        }
                        Console.Write("\tY: ");
                        if (Int32.TryParse(Console.ReadLine(), out intParse))
                        {
                            yPoint = intParse;
                        }
                        else
                        {
                            throw new FormatException("Format error");
                        }
                        Console.Write("\tName: ");
                        name = Console.ReadLine();

                        points.Add(new Point(xPoint, yPoint, name));
                    }
                    switch (countOfPoints)
                    {
                        case 3:
                            Figure threePoints = new Figure(points[0], points[1], points[2]);
                            Console.WriteLine("Perimetr of {0} is: {1}", points[0].Name+points[1].Name + points[2].Name,
                                                                        threePoints.PerimetrFigure);
                            break;
                        case 4:
                            Figure fourPoints = new Figure(points[0], points[1], points[2], points[3]);
                            Console.WriteLine("Perimetr of {0} is: {1}", points[0].Name + points[1].Name + points[2].Name+ points[3].Name,
                                fourPoints.PerimetrFigure);
                            break;
                        case 5:
                            Figure fivePoints = new Figure(points[0], points[1], points[2], points[3], points[4]);
                            Console.WriteLine("Perimetr of {0} is: {1}", points[0].Name + points[1].Name + points[2].Name + points[3].Name +
                                points[4].Name, fivePoints.PerimetrFigure);
                            break;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}



