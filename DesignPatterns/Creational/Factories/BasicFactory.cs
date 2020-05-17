using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.Factories
{
    public class Point
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        private double x, y;

        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(double a,
          double b, // names do not communicate intent
          CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augment CoordinateSystem
            // 2. change ctor
        }

        public override string ToString()
        {
            return $"{nameof(x)} : {x}, {nameof(y)}: {y}";
        }

        // factory property
        public static Point Origin => new Point(0, 0);

        // singleton field
        public static Point Origin2 = new Point(0, 0); //better

        public static PointFactory Factory => new PointFactory();

        public class PointFactory
        {
            public Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y); // needs to be public
            }

            public Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }



    class Demo
    {
        //static void Main(string[] args)
        //{
        //    var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);
        //    Console.WriteLine(p1);
        //    var origin = Point.Origin;
        //    Console.WriteLine(origin);
        //    var p2 = Point.Factory.NewPolarPoint(1, 2);
        //    Console.WriteLine(p2);
        //    var p3 = Point.Factory.NewCartesianPoint(1, 2.5);
        //    Console.WriteLine(p3);
        //}
    }
}
