using System.Net.NetworkInformation;

namespace Monitoring.UnitTests {
    [TestClass]
    public class TaskMonitoringTests {
        private TaskMonitoring taskTest;

        [TestMethod]
        public void PerformPing_NominalCase_True() {
            Machine machineTest = new("test", "127.0.0.1", 0);
            taskTest = new(machineTest);
            Assert.IsTrue(taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_IPNull_ArgumentNullException() {
            Machine machineTest = new("test", null, 0);
            taskTest = new(machineTest);
            Assert.Throws<ArgumentNullException>(() => taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_IPv4Invalid_PingException() {
            Machine machineTest = new("test", "256.0.0.0", 0);
            taskTest = new(machineTest);
            Assert.Throws<PingException>(() => taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_IPv4WithoutResponse_False() {
            Machine machineTest = new("test", "192.0.20.255", 0);
            taskTest = new(machineTest);
            Assert.IsFalse(taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_IPv6Valid_True() {
            Machine machineTest = new("test", "::1", 0);
            taskTest = new(machineTest);
            Assert.IsTrue(taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_IPv6Invalid_PingException() {
            Machine machineTest = new("test", "10000::", 0);
            taskTest = new(machineTest);
            Assert.Throws<PingException>(() => taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_DomainNameValid_True() {
            Machine machineTest = new("test", "www.google.com", 0);
            taskTest = new(machineTest);
            Assert.IsTrue(taskTest.PerformPing());
        }

        [TestMethod]
        public void PerformPing_DomainNameInvalid_PingException() {
            Machine machineTest = new("test", "test", 0);
            taskTest = new(machineTest);
            Assert.Throws<PingException>(() => taskTest.PerformPing());
        }
    }
}