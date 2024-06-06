namespace ComplexStruct.UnitTests
{
    [TestFixture]
    public class ComplexTests
    {
        [Test]
        public void ConstructorTest()
        {
            var complex = new Complex(1, -2);
            Assert.That(complex.Re, Is.EqualTo(1));
            Assert.That(complex.Im, Is.EqualTo(-2));
        }
        [TestCase(-3, 4, 5)]
        [TestCase(0, 0, 0)]
        public void AbsTest(double re, double im, int result)
        {
            var complex = new Complex(re, im);
            Assert.That(complex.Abs, Is.EqualTo(result));
        }
        [TestCase(10, 15, "10 + 15i")]
        [TestCase(10, -15, "10 - 15i")]
        [TestCase(-10, -15, "-10 - 15i")]
        [TestCase(-10, -1, "-10 - i")]
        [TestCase(-10, 1, "-10 + i")]
        [TestCase(-10, 0, "-10")]
        [TestCase(0, -15, "-15i")]
        [TestCase(0, 0, "0")]
        public void ToStringTest(double re, double im, string result)
        {
            var complex = new Complex(re, im);
            Assert.That(complex.ToString(), Is.EqualTo(result));
        }
        [TestCase(30, 30, true)]
        [TestCase(30, 15, false)]
        public void Equals_TwoComplex_ExpectedResult(double re1, double re2, bool result)
        {
            var complex1 = new Complex(re1, 15);
            var complex2 = new Complex(re2, 15);
            Assert.That(complex1.Equals(complex2), Is.EqualTo(result));
        }
        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var complex = new Complex();
            var smth = new object();
            Assert.That(() => complex.Equals(smth), Throws.ArgumentException);
        }
        [Test]
        public static void GetHashCodeTest()
        {
            var x = new Complex(45, 18);
            var y = new Complex(45, 18);
            var z = new Complex(-30, 45);
            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }
        [Test]
        public static void ComparisonTest()
        {
            var x = new Complex(45, 18);
            var y = new Complex(45, 18);
            var z = new Complex(-30, 45);
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }
        [TestCase(30, 40, 50, 20, 80, 60)]
        [TestCase(30, 40, -20, 30, 10, 70)]
        [TestCase(30, 40, 0, 0, 30, 40)]
        public void AdditionTest(
        double re1, double im1,
        double re2, double im2, 
        double resultRe, double resultIm)
        {
            var complex1 = new Complex(re1, im1);
            var complex2 = new Complex(re2, im2);
            var result = new Complex(resultRe, resultIm);
            Assert.That(complex1 + complex2, Is.EqualTo(result));
        }
        [TestCase(30, 40, 50, 20, -20, 20)]
        [TestCase(30, 40, -20, 30, 50, 10)]
        [TestCase(30, 40, 0, 0, 30, 40)]
        public void SubstractTest(
        double re1, double im1,
        double re2, double im2,
        double resultRe, double resultIm)
        {
            var complex1 = new Complex(re1, im1);
            var complex2 = new Complex(re2, im2);
            var result = new Complex(resultRe, resultIm);
            Assert.That(complex1 - complex2, Is.EqualTo(result));
        }
    }
}
