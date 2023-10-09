//Почему всё в одном файле?

// можно использовать using namespace TestFigureArea;
namespace TestFigureArea {
    [TestClass] //Отсуп бы добавить 
    public class UnitTest1 { //Почему у класса такое всратое название? 
        [TestMethod] // Тут тоже отступ
        public void Create_Figure_Square_Radus_Less_Or_Zero () {

            // Я не уверен, что у MSTest такой метод есть, но лучше использовать Assert.Throw<ArgumentOutOfRangeException>(() => ...
            // вместо try/catch конструкции. Можно посмотреть в сторону NUnit (мой личный фаворит) или Fluent Assertions
            try { 
                Square square = new Square(-1);
            } catch (System.ArgumentOutOfRangeException e) {
                StringAssert.Contains(e.Message, FigureException.ArgumentLessOrEqualThanZeroMessage);
                return;
            }
            Assert.Fail("Îæèäàåìîå èñêëþ÷åíèå íå áûëî âûäàíî."); 
        }
        [TestMethod]
        public void Create_Figure_Tringle_Side_Less_Or_Zero () {

            try {
                Triangle triangle = new Triangle(10, -1, 2);
            } catch (System.ArgumentOutOfRangeException e) {
                StringAssert.Contains(e.Message, FigureException.ArgumentLessOrEqualThanZeroMessage);
                return;
            }
            Assert.Fail("Îæèäàåìîå èñêëþ÷åíèå íå áûëî âûäàíî.");
        }
        [TestMethod]
        public void Create_Figure_Tringle_Is_Existence () {
            try {
                Triangle triangle = new Triangle(10, 3, 2);
            } catch (System.ArgumentException e) {
                StringAssert.Contains(e.Message, Triangle.TriangleWithSidesNotExistMessage);
                return;
            }
            Assert.Fail("Îæèäàåìîå èñêëþ÷åíèå íå áûëî âûäàíî.");
        }
        [TestMethod]
        public void Create_Right_Tringle () {
            Triangle triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.GetRightTriangle(), "Òðåóãîëüíèê íå ïðàâèëüíûé");
        }
        // Этот тест совсем ничего не проверяет. Откуда ожидание, что констркутор может вернуть Null? 
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
