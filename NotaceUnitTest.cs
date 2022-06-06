using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverzníPolskáNotace;
namespace UnitTestProject1
{
    [TestClass]
    public class NotaceUnitTest
    {
        [TestMethod]
        public void Normal()
        {
            string vstup = "3 7 + 4 * 9 17 - +";
            double expected = 32;
            double actual = Kalkulaèka.KalkulaèkaNotace(vstup);
            Assert.AreEqual(expected,actual,"KALKULAÈKA NEFUNGUJE!!!");
        }

        [TestMethod]
        public void NulováDélka()
        {
            string vstup = "";
            Assert.ThrowsException<System.ArgumentNullException>(() => Kalkulaèka.KalkulaèkaNotace(vstup), "POZOR NA VSTUP DÉLKY NULA");
        }

        [TestMethod]
        public void NedostateènýPoèetOperací()
        {
            string vstup = "1 2 3 - + 6";
            Assert.ThrowsException<System.ArgumentException>(() => Kalkulaèka.KalkulaèkaNotace(vstup), "POZOR NA NEDOSTATEÈNÝ POÈET OPERACÍ");
        }

        [TestMethod]
        public void NadbyteènýPoèetOperací()
        {
            string vstup = "1 2 3 - + 6 * +";
            Assert.ThrowsException<System.ArgumentException>(() => Kalkulaèka.KalkulaèkaNotace(vstup), "POZOR NA NADBYTEÈNÝ POÈET OPERACÍ");
        }

        [TestMethod]
        public void JinéZnaky()
        {
            string vstup = "1 = 3 - 1";
            Assert.ThrowsException<System.InvalidOperationException>(() => Kalkulaèka.KalkulaèkaNotace(vstup), "POZOR NA JINÉ ZNAKY");
        }
    }
}
