using System.Linq;
using System.Threading.Tasks;
using ecc.business.logic.Interfaces;
using ecc.business.logic.tests.Mocks;
using ecc.common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ecc.business.logic.tests
{
    [TestClass]
    public class ColorCodingComponentsTest
    {

        [ClassInitialize()]
        public static void OhmValueCalculatorTestInit(TestContext context)
        {
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetColorBands_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetColorBandsAsync();

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
            Assert.IsTrue(response.Count() == 10);

        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetColorBands_Failure()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetColorBandValueAsync("");

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response == 0);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetColorBands_Red_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetColorBandValueAsync("red");

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response == 2);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetColorBands_White_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetColorBandValueAsync("white");

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response == 9);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetMultipliers_White_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetMultipliersAsync("white");

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response == 1000000000d);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetMultipliers_Empty_Failure()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetMultipliersAsync("");

            //assert
            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetTolerance_White_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetToleranceAsync("white");

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response == 20);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetTolerance_Empty_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetToleranceAsync("");

            //assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetMultipliersColorCodes_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetMultiplierColorCodesAsync();

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
            Assert.IsTrue(response.Count() == 13);

        }

        [TestMethod]
        public async Task Validate_ColorCodingComponents_GetToleranceColorCodes_Success()
        {
            //arrange


            //act
            var colorCodingComponents = new ColorCodingComponents();
            var response = await colorCodingComponents.GetToleranceColorCodesAsync();

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
            Assert.IsTrue(response.Count() == 10);

        }
    }
}
