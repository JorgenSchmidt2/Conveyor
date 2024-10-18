using ConveyorUtility.Bunker.Service.ValidateService;

namespace ValidateServiceTests.OtherValidatorsTests
{
    [TestClass]
    public class CheckFilesConfigTests
    {
        [TestMethod]
        public void Test_1 ()
        {
            string Input = "0 0 0 1 2 2 1 1 2";
            var Result = OtherValidators.CheckFilesConfig(Input).Status;

            Assert.AreEqual(Result, true);
        }

        [TestMethod]
        public void Test_2()
        {
            string Input = "0 0 0 1 2 2 3 1 2";
            var Result = OtherValidators.CheckFilesConfig(Input).Status;

            Assert.AreEqual(Result, false);
        }

        [TestMethod]
        public void Test_3()
        {
            string Input = "0122122";
            var Result = OtherValidators.CheckFilesConfig(Input).Status;

            Assert.AreEqual(Result, false);
        }

        [TestMethod]
        public void Test_4()
        {
            string Input = "0 1 22 1 2 2";
            var Result = OtherValidators.CheckFilesConfig(Input).Status;

            Assert.AreEqual(Result, false);
        }
    }
}