namespace WpfApp1Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WpfApp1.Models;

    [TestClass]
    public class CalcTests
    {
        private Calc calc;

        [TestInitialize]
        public void TestInitialize()
        {
            this.calc = new Calc();
        }

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(string.Empty, this.calc.Add(null, "1.1"));
            Assert.AreEqual(string.Empty, this.calc.Add("1.1", string.Empty));
            Assert.AreEqual(string.Empty, this.calc.Add("abc", "def"));
            Assert.AreEqual("3.3", this.calc.Add("1.1", "2.2"));
        }
    }
}