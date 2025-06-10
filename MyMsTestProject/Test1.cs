using AdvancedCSharp.Samples.Class;
using AdvancedCSharp.Samples.Class.Inheritance;
using System.ComponentModel.DataAnnotations;

namespace MyMsTestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Car(50);
        }


        [TestMethod]
        public void TestMethod1a()
        {        
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => new Car(-50));
        }

        [DataTestMethod]
        [DataRow(1, 100)]
        [DataRow(2, 200)]
        [DataRow(3, 300)]
        //[DataRow(-1)]
        [DataRow(0,0)]
        public void TestMethod2(int dist, int expecteddistance)
        {
            var c = new Car(100);

            c.Drive(dist);

            Assert.AreEqual(expecteddistance, c.Distance);
        }


        [DataTestMethod]
        [DataRow(1, 200)]
        [DataRow(2, 400)]
        [DataRow(3, 600)]
        //[DataRow(-1)]
        [DataRow(0, 0)]
        public void TestMethod2a(int dist, int expecteddistance)
        {
            var c = new Car(100);

            c.Drive(dist);
            c.Drive(dist);


            var vehicle = NSubstitute.Substitute.For<IVehicle>();
            //vehicle.re;

            Assert.AreEqual(expecteddistance, c.Distance);
        }

        [TestMethod]
        public void TestMethod3()
        {
        }
    }
}
