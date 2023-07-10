namespace FigureArea {

    public class FigureException : Exception {
        public const string ArgumentLessOrEqualThanZeroMessage = "Аргумент меньше или равен 0";

        public static bool IsLessOrEqualThanZero(int a) {
            return a <=0 ? true : false;
        }
    }
    public class Figure {
        public virtual double GetArea() {
            return 0.0;
        }

    }
    public class Square : Figure {

        private int _r; // радиус круга

        public Square(int r) { 
            if (FigureException.IsLessOrEqualThanZero(r)) {
                throw new ArgumentOutOfRangeException("r", r, FigureException.ArgumentLessOrEqualThanZeroMessage);
            }
            _r = r; 
        }

        public override double GetArea() {
            // Площадь круга Пиr^2
            return Math.Round(Math.PI * Math.Pow(_r, 2), 2);
        }
    }
    public class Triangle : Figure {
        public const string TriangleWithSidesNotExistMessage = "Треугольник со сторонами не существует";
        private int _a, _b, _c;
        private bool _isRightTriangle;

        public Triangle(int a, int b, int c) {
            if (FigureException.IsLessOrEqualThanZero(a) || FigureException.IsLessOrEqualThanZero(b) || FigureException.IsLessOrEqualThanZero(c)) {
                throw new ArgumentOutOfRangeException("a || b || C", FigureException.ArgumentLessOrEqualThanZeroMessage);
            }
            if (!IsExistenceOfTriangle(a, b, c)) {
                throw new ArgumentException("a && b && C ", TriangleWithSidesNotExistMessage);
            }
            _a = a;
            _b = b;
            _c = c;
            _isRightTriangle = IsRightTriangle();
        }

        private bool IsRightTriangle() { 
            return Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2) ? true : false;
        }

        private bool IsExistenceOfTriangle(int a, int b, int c) {
            return (a+b > c) && (a + c > b) && (b + c > a ) ? true : false;  
                            
        }

        public override double GetArea () {
            /// S = sqrt(p(p-a)(p-b)(p-c))
            /// p = (a+b+c)/2
            double p = (_a + _b + _c)/2;
            return Math.Round(Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c)), 2);
        }

        public bool GetRightTriangle () {
            return _isRightTriangle;
        }
    }
}