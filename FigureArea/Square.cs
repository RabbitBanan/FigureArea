namespace FigureArea
{
    public class Square : IFigure
    {
        private int _r; // радиус круга

        public Square(int r)
        {
            if (FigureException.IsLessOrEqualThanZero(r))
            { // А почему бы сюда сразу же здесь не выкидывать эксепшен? 
                throw new ArgumentOutOfRangeException("r", r, FigureException.ArgumentLessOrEqualThanZeroMessage); // $"{nameof(r)} {r}"
            }
            _r = r;
        }

        public override double GetArea()
        {
            // Площадь круга Пиr^2
            return Math.Round(Math.PI * Math.Pow(_r, 2), 2); // А зачем округление? 
        }
    }
}
}
