using System.Threading.Tasks;
using ecc.business.logic.Interfaces;
using ecc.business.logic.tests.Mocks;
using ecc.common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ecc.business.logic.tests
{
    [TestClass]
    public class OhmValueCalculatorTest
    {
        private static Mock<IColorCodingComponents> _mockColorCodingComponents;

        [ClassInitialize()]
        public static void OhmValueCalculatorTestInit(TestContext context)
        {
            _mockColorCodingComponents = new Mock<IColorCodingComponents>();
        }

        [TestMethod]
        public async Task Validate_OhmValueCalculator_Success()
        {
            //arrange

            _mockColorCodingComponents.Setup(code => code.GetMultipliersAsync(It.IsAny<string>()))
                .ReturnsAsync(MockColorCodes.GetMockMultipliers("Red"));

            _mockColorCodingComponents.Setup(code => code.GetToleranceAsync(It.IsAny<string>()))
               .ReturnsAsync(MockColorCodes.GetMockTolerance("None"));

            _mockColorCodingComponents.Setup(code => code.GetColorBandValueAsync(It.IsAny<string>()))
               .ReturnsAsync((int)ColorSignificantFigureEnum.Red);

            //act
            var ohmValueCalculator = new OhmValueCalculator(_mockColorCodingComponents.Object);
            var response = await ohmValueCalculator.CalculateOhmValue("red", "green", "yellow", "red");

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.MaximumOhmValue, 2640);
            Assert.AreEqual(response.MinimumOhmValue, 1760);


        }

        [TestMethod]
        public async Task Validate_OhmValueCalculator_Failure()
        {
            //arrange

            _mockColorCodingComponents.Setup(code => code.GetMultipliersAsync(It.IsAny<string>()))
                  .ReturnsAsync(MockColorCodes.GetMockMultipliers(""));

            _mockColorCodingComponents.Setup(code => code.GetToleranceAsync(It.IsAny<string>()))
               .ReturnsAsync(MockColorCodes.GetMockTolerance(""));

            _mockColorCodingComponents.Setup(code => code.GetColorBandValueAsync(It.IsAny<string>()))
               .ReturnsAsync((int)ColorSignificantFigureEnum.Red);

            //act
            var ohmValueCalculator = new OhmValueCalculator(_mockColorCodingComponents.Object);
            var response = await ohmValueCalculator.CalculateOhmValue("red", "green", "yellow", "red");

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.MaximumOhmValue, 0);
            Assert.AreEqual(response.MinimumOhmValue, 0);
        }

        [TestMethod]
        public async Task Validate_OhmValueCalculator_Red_Red_Yellow_Green_Success()
        {
            //arrange

            _mockColorCodingComponents.Setup(code => code.GetMultipliersAsync(It.IsAny<string>()))
                   .ReturnsAsync(MockColorCodes.GetMockMultipliers("Yellow"));

            _mockColorCodingComponents.Setup(code => code.GetToleranceAsync(It.IsAny<string>()))
               .ReturnsAsync(MockColorCodes.GetMockTolerance("None"));

            _mockColorCodingComponents.Setup(code => code.GetColorBandValueAsync(It.IsAny<string>()))
               .ReturnsAsync((int)ColorSignificantFigureEnum.Red);

            //act
            var ohmValueCalculator = new OhmValueCalculator(_mockColorCodingComponents.Object);
            var response = await ohmValueCalculator.CalculateOhmValue("red", "red", "yellow", "none");

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.MaximumOhmValue, 264000);
            Assert.AreEqual(response.MinimumOhmValue, 176000);
        }

        [TestMethod]
        public async Task Validate_OhmValueCalculator_Yellow_Yellow_Yellow_None_Failure()
        {
            //arrange

            _mockColorCodingComponents.Setup(code => code.GetMultipliersAsync(It.IsAny<string>()))
                   .ReturnsAsync(MockColorCodes.GetMockMultipliers("None"));

            _mockColorCodingComponents.Setup(code => code.GetToleranceAsync(It.IsAny<string>()))
               .ReturnsAsync(MockColorCodes.GetMockTolerance("None"));

            _mockColorCodingComponents.Setup(code => code.GetColorBandValueAsync(It.IsAny<string>()))
               .ReturnsAsync((int)ColorSignificantFigureEnum.Yellow);

            //act
            var ohmValueCalculator = new OhmValueCalculator(_mockColorCodingComponents.Object);
            var response = await ohmValueCalculator.CalculateOhmValue("yellow", "yellow", "none", "none");

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.MaximumOhmValue, 0);
            Assert.AreEqual(response.MinimumOhmValue, 0);
        }
    }
}
