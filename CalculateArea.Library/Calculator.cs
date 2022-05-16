namespace CalculateArea.Library
{
    public static class Calculator
    {
        public static double CalculateCircleAreaByRadius(double radius)
        {
            if (radius == 1)
            {
                return Math.PI;
            }
            else if (radius > 0)
            {
                return Math.Round(Math.PI * Math.Pow(radius, 2), 2);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static double CalculateTriangleAreaBySides(double a, double b, double c)
        {
            if (CheckSidesValuesIsPositive(a, b, c))
            {
                if (CheckRealTriangle(a, b, c))
                {
                    if (CheckTriangleIsRight(a, b, c))
                    {
                        Tuple<double, double[]> sideValues = DefineSideValues(a, b, c);
                        return CalculateRightTriangleArea(sideValues.Item2[0], sideValues.Item2[1]);
                    }
                    else
                    {
                        return CalculateTriangleAreaByHeronFormula(a, b, c);
                    }
                }
                else if (CheckDegenerateTriangle(a, b, c))
                {
                    return 0;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static bool CheckSidesValuesIsPositive(double a, double b, double c)
        {
            bool condition = (a > 0 && b > 0 && c > 0);
            return condition;
        }

        public static bool CheckRealTriangle(double a, double b, double c)
        {
            bool condition = ((a + b > c) && (a + c > b) && (b + c > b));
            return condition;
        }

        public static bool CheckDegenerateTriangle(double a, double b, double c)
        {
            bool condition = ((a == b + c) || (b == a + c) || (c == a + b));
            return condition;
        }

        public static bool CheckTriangleIsRight(double a, double b, double c)
        {
            Tuple<double, double[]> sideValues = DefineSideValues(a, b, c);
            bool triangleRightCondition = 
                Math.Pow(sideValues.Item2[0], 2) + Math.Pow(sideValues.Item2[1], 2) == Math.Pow(sideValues.Item1, 2);
            return triangleRightCondition;
        }

        public static Tuple<double, double[]> DefineSideValues(double a, double b, double c)
        {
            double maxSideValue = Math.Max(Math.Max(a, b), c);

            if (maxSideValue == a)
            {
                return new Tuple<double, double[]>(a, new double[2] { b, c });
            }
            else if (maxSideValue == b)
            {
                return new Tuple<double, double[]>(b, new double[2] { a, c });
            }
            else if (maxSideValue == c)
            {
                return new Tuple<double, double[]>(c, new double[2] { a, b });
            }
            else
            {
                return new Tuple<double, double[]>(c, new double[2] { a, b });
            }
        }

        public static double CalculateRightTriangleArea(double a, double b)
        {
            return (a * b) / 2;
        }

        public static double CalculateTriangleAreaByHeronFormula(double a, double b, double c)
        {
            double triangleSemiperimeter = CalculateTriangleSemiperimeter(a, b, c);

            return Math.Sqrt(triangleSemiperimeter * (triangleSemiperimeter - a) * (triangleSemiperimeter - b) * (triangleSemiperimeter - c)); 
        }

        public static double CalculateTriangleSemiperimeter(double a, double b, double c)
        {
            return (a + b + c) / 2;
        }
    }
}