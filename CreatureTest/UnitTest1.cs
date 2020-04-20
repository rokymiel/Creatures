using System;
using System.IO;
using System.Runtime.Serialization;
using CreaturesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatureTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToString()
        {
            Creature a = new Creature("Mambad", MovementType.Walking, 3.7689);
            Assert.AreEqual(a.ToString(), $"Walking creature Mambad: Health = {3.769}");
        }
        [TestMethod]
        public void TestOperator_1()
        {
            Creature am = new Creature("Amadeus", MovementType.Swimming, 7.3);
            Creature be = new Creature("Bethov", MovementType.Swimming, 8.7);
            Assert.AreEqual(am * be, new Creature("Amadhov", MovementType.Swimming, (7.3 + 8.7) / 2));
        }
        [TestMethod]
        public void TestOperator_2()
        {
            Creature am = new Creature("Amad", MovementType.Swimming, 7.3);
            Creature be = new Creature("Bethovs", MovementType.Swimming, 8.7);
            Assert.AreEqual(am * be, new Creature("Bethad", MovementType.Swimming, (7.3 + 8.7) / 2));
        }
        [TestMethod]
        public void TestObjectSerialaize()
        {
            string path = "test.xml";
            Creature am = new Creature("Amadeus", MovementType.Swimming, 7.3);
            using (FileStream writer = new FileStream(path, FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(am.GetType());
                ser.WriteObject(writer, am);
            }
            Creature newAm;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Creature));
                newAm = (Creature)ser.ReadObject(fs);
            }
            Assert.AreEqual(am,newAm);
        }

    }
}
