using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reverzn�Polsk�Notace;
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
            double actual = Kalkula�ka.Kalkula�kaNotace(vstup);
            Assert.AreEqual(expected,actual,"KALKULA�KA NEFUNGUJE!!!");
        }

        [TestMethod]
        public void Nulov�D�lka()
        {
            string vstup = "";
            Assert.ThrowsException<System.ArgumentNullException>(() => Kalkula�ka.Kalkula�kaNotace(vstup), "POZOR NA VSTUP D�LKY NULA");
        }

        [TestMethod]
        public void Nedostate�n�Po�etOperac�()
        {
            string vstup = "1 2 3 - + 6";
            Assert.ThrowsException<System.ArgumentException>(() => Kalkula�ka.Kalkula�kaNotace(vstup), "POZOR NA NEDOSTATE�N� PO�ET OPERAC�");
        }

        [TestMethod]
        public void Nadbyte�n�Po�etOperac�()
        {
            string vstup = "1 2 3 - + 6 * +";
            Assert.ThrowsException<System.ArgumentException>(() => Kalkula�ka.Kalkula�kaNotace(vstup), "POZOR NA NADBYTE�N� PO�ET OPERAC�");
        }

        [TestMethod]
        public void Jin�Znaky()
        {
            string vstup = "1 = 3 - 1";
            Assert.ThrowsException<System.InvalidOperationException>(() => Kalkula�ka.Kalkula�kaNotace(vstup), "POZOR NA JIN� ZNAKY");
        }
    }
}
