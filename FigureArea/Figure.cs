// Почему файл всего один? Почему не в разных?
namespace FigureArea { // Почему не стиль Олмана (https://ru.wikipedia.org/wiki/%D0%9E%D1%82%D1%81%D1%82%D1%83%D0%BF_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)#%D0%A1%D1%82%D0%B8%D0%BB%D1%8C_%D0%9E%D0%BB%D0%BC%D0%B0%D0%BD%D0%B0)

    public class FigureException : Exception {
        public const string ArgumentLessOrEqualThanZeroMessage = "Аргумент меньше или равен 0";

        public static bool IsLessOrEqualThanZero(int a) { 
            return a <=0 ? true : false; // a <= 0 - Это какой тип возвращает?)))
        }
    }
    public class Figure { //Почему это не абстрактный класс?
        public virtual double GetArea() {  //Почему здесь есть возвращаемое значение? 
            return 0.0;
        }

    }
    public class Square : Figure {

        private int _r; // радиус круга

        public Square(int r) { 
            if (FigureException.IsLessOrEqualThanZero(r)) { // А почему бы сюда сразу же здесь не выкидывать эксепшен? 
                throw new ArgumentOutOfRangeException("r", r, FigureException.ArgumentLessOrEqualThanZeroMessage); // $"{nameof(r)} {r}"
            }
            _r = r; 
        }

        public override double GetArea() {
            // Площадь круга Пиr^2
            return Math.Round(Math.PI * Math.Pow(_r, 2), 2); // А зачем округление? 
        }
    }
    public class Triangle : Figure {
        public const string TriangleWithSidesNotExistMessage = "Треугольник со сторонами не существует";
        private int _a, _b, _c; // Параметры лучше на разных строках
        private bool _isRightTriangle;

        public Triangle(int a, int b, int c) {
            if (FigureException.IsLessOrEqualThanZero(a) || FigureException.IsLessOrEqualThanZero(b) || FigureException.IsLessOrEqualThanZero(c)) {
                throw new ArgumentOutOfRangeException("a || b || C", FigureException.ArgumentLessOrEqualThanZeroMessage);
            }
            if (!IsExistenceOfTriangle(a, b, c)) {
                throw new ArgumentException("a && b && C ", TriangleWithSidesNotExistMessage); // Странный комментарий
            }
            _a = a;
            _b = b;
            _c = c;
            _isRightTriangle = IsRightTriangle();
        }

        private bool IsRightTriangle() { 
            return Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2) ? true : false; // тоже самое, какой тип возвращает операция == 
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
