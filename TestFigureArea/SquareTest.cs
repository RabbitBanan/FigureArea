namespace TestFigureArea {
    [TestClass]

    public class SquareTest
    {
        [TestMethod]

        public void Create_Figure_Square_Radus_Less_Or_Zero () {

            try {
                Square square = new Square(-1);
            } catch (System.ArgumentOutOfRangeException e) {
                StringAssert.Contains(e.Message, FigureException.ArgumentLessOrEqualThanZeroMessage);
                return;
            }
            Assert.Fail("Ожидаемое исключение не было выдано.");
        }
    }
}