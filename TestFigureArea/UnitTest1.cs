namespace TestFigureArea {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Create_Figure_Square_Radus_Less_Or_Zero () {

            try {
                Square square = new Square(-1);
            } catch (System.ArgumentOutOfRangeException e) {
                StringAssert.Contains(e.Message, FigureException.ArgumentLessOrEqualThanZeroMessage);
                return;
            }
            Assert.Fail("ќжидаемое исключение не было выдано.");
        }
        [TestMethod]
        public void Create_Figure_Tringle_Side_Less_Or_Zero () {

            try {
                Triangle triangle = new Triangle(10, -1, 2);
            } catch (System.ArgumentOutOfRangeException e) {
                StringAssert.Contains(e.Message, FigureException.ArgumentLessOrEqualThanZeroMessage);
                return;
            }
            Assert.Fail("ќжидаемое исключение не было выдано.");
        }
        [TestMethod]
        public void Create_Figure_Tringle_Is_Existence () {
            try {
                Triangle triangle = new Triangle(10, 3, 2);
            } catch (System.ArgumentException e) {
                StringAssert.Contains(e.Message, Triangle.TriangleWithSidesNotExistMessage);
                return;
            }
            Assert.Fail("ќжидаемое исключение не было выдано.");
        }
        [TestMethod]
        public void Create_Right_Tringle () {
            Triangle triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.GetRightTriangle(), "“реугольник не правильный");
        }
        [TestMethod]
        public void Create_Compile_Time_Figure () {
            Figure f;
            f = new Square(1);
            Assert.IsNotNull(f);

            f = new Triangle(4, 3, 5);
            Assert.IsNotNull(f);
        }
    }
}