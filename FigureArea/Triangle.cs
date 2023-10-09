namespace FigureArea
{
    public class Triangle : IFigure
    {
        public const string TriangleWithSidesNotExistMessage = "Треугольник со сторонами не существует";
        private int _a, _b, _c; // Параметры лучше на разных строках
        private bool _isRightTriangle;

        public Triangle(int a, int b, int c)
        {
            if (FigureException.IsLessOrEqualThanZero(a) || FigureException.IsLessOrEqualThanZero(b) || FigureException.IsLessOrEqualThanZero(c))
            {
                throw new ArgumentOutOfRangeException("a || b || C", FigureException.ArgumentLessOrEqualThanZeroMessage);
            }
            if (!IsExistenceOfTriangle(a, b, c))
            {
                throw new ArgumentException("a && b && C ", TriangleWithSidesNotExistMessage); // Странный комментарий
            }
            _a = a;
            _b = b;
            _c = c;
            _isRightTriangle = IsRightTriangle();
        }

        private bool IsRightTriangle()
        {
            return Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2) ? true : false; // тоже самое, какой тип возвращает операция == 
        }

        private bool IsExistenceOfTriangle(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a) ? true : false;

        }

        public override double GetArea()
        {
            /// S = sqrt(p(p-a)(p-b)(p-c))
            /// p = (a+b+c)/2
            double p = (_a + _b + _c) / 2;
            return Math.Round(Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c)), 2);
        }

        public bool GetRightTriangle()
        {
            return _isRightTriangle;
        }
    }
}
