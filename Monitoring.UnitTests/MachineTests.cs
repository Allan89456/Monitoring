namespace Monitoring.UnitTests {
    [TestClass]
    public class MachineTests {
        private const int MIN = 0;
        private const int MAX = 255;

        [TestMethod]
        public void IsIPValid_NominalCase_True() {
            Random rnd = new();
            Assert.IsTrue(Machine.IsIPValid($"{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}"));
        }

        [TestMethod]
        public void IsIPValid_IPMin_True() {
            Assert.IsTrue(Machine.IsIPValid($"{MIN}.{MIN}.{MIN}.{MIN}"));
        }

        [TestMethod]
        public void IsIPValid_IPMax_True() {
            Assert.IsTrue(Machine.IsIPValid($"{MAX}.{MAX}.{MAX}.{MAX}"));
        }

        [TestMethod]
        public void IsIPValid_BlockInvalid_False() {
            Assert.IsFalse(Machine.IsIPValid($"{MAX+1}.{MAX}.{MAX}.{MAX}"));
        }

        [TestMethod]
        public void IsIPValid_BlockMissing_False() {
            Random rnd = new();
            Assert.IsFalse(Machine.IsIPValid($"{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}"));
        }

        [TestMethod]
        public void IsIPValid_AdditionalBlock_False() {
            Random rnd = new();
            Assert.IsFalse(Machine.IsIPValid($"{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}.{rnd.Next(MIN + 1, MAX - 1)}"));
        }
    }
}