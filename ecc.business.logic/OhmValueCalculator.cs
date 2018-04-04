using System;
using System.Linq;
using System.Threading.Tasks;
using ecc.business.logic.Interfaces;
using ecc.common.Models;

namespace ecc.business.logic
{
    public class OhmValueCalculator : IOhmValueCalculator

    {
        private readonly IColorCodingComponents _colorCodingComponents;
        public OhmValueCalculator(IColorCodingComponents colorCodingComponents)
        {
            _colorCodingComponents = colorCodingComponents;
        }

        /// <summary>

        /// Calculates the Ohm value of a resistor based on the band colors.

        /// </summary>

        /// <param name="bandAColor">The color of the first figure of component value band.</param>

        /// <param name="bandBColor">The color of the second significant figure band.</param>

        /// <param name="bandCColor">The color of the decimal multiplier band.</param>

        /// <param name="bandDColor">The color of the tolerance value band.</param>

        public async Task<OhmValueResponse> CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var firstSignificantFigureTask = _colorCodingComponents.GetColorBandValueAsync(bandAColor);
            var secondSignificantFigureTask = _colorCodingComponents.GetColorBandValueAsync(bandBColor);
            var multiplierTask = _colorCodingComponents.GetMultipliersAsync(bandCColor);
            var toleranceTask = _colorCodingComponents.GetToleranceAsync(bandDColor);

            await Task.WhenAll(firstSignificantFigureTask, secondSignificantFigureTask, multiplierTask, toleranceTask);
            var tolerance = toleranceTask.Result ?? 0;
            var multiplier = multiplierTask.Result ?? 0;

            var baseOhmValue = ((firstSignificantFigureTask.Result * 10) + secondSignificantFigureTask.Result) * multiplier;
            var toleranceOffset = baseOhmValue * (tolerance / 100);
            var minimumOhmValue = baseOhmValue - toleranceOffset;
            var maximumOhmValue = baseOhmValue + toleranceOffset;

            return await Task.FromResult(new OhmValueResponse { MinimumOhmValue = minimumOhmValue, MaximumOhmValue = maximumOhmValue });
        }

    }
}