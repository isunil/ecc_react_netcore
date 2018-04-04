using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecc.business.logic.Interfaces;
using ecc.common.Enums;
using ecc.common.Extensions;

namespace ecc.business.logic
{
    public class ColorCodingComponents : IColorCodingComponents
    {

        private Dictionary<string, double> Multipliers => new Dictionary<string, double>
            {
                {"Pink", 0.001d},
                {"Silver", 0.01d},
                {"Gold", 0.1d},
                {"Black", 1d},
                {"Brown", 10d},
                {"Red", 100d},
                {"Orange", 1000d},
                {"Yellow", 10000d},
                {"Green", 100000d},
                {"Blue", 1000000d},
                {"Violet", 10000000d},
                {"Gray", 100000000d},
                {"White", 1000000000d}

            };

        private Dictionary<string, double> Tolerance => new Dictionary<string, double>
            {
                {"None", 20d},
                {"Silver", 20d},
                {"Gold", 5d},
                {"Brown", 1d},
                {"Red", 2d},
                {"Yellow", 5d},
                {"Green", 0.5d},
                {"Blue", 0.25d},
                {"Violet", 0.1d},
                {"Gray", 0.05d}
            };

        /// <summary>
        /// returns color codes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetColorBandsAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(ColorSignificantFigureEnum)).ToList());

        }


        /// <summary>
        /// returns color code values
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetColorBandValueAsync(string color)
        {
            return await Task.FromResult((int)color.TryParseEnum<ColorSignificantFigureEnum>());

        }
        /// <summary>
        /// returns multipliers
        /// </summary>
        /// <returns></returns>
        public async Task<double?> GetMultipliersAsync(string color)
        {
            var multiplier = Multipliers.FirstOrDefault(x => x.Key.Equals(color, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(multiplier.Equals(new KeyValuePair<string, double>()) ? (double?)null : multiplier.Value);
        }

        /// <summary>
        /// returns tolerance
        /// </summary>
        /// <returns></returns>
        public async Task<double?> GetToleranceAsync(string color)
        {
            var tolerance = Tolerance.FirstOrDefault(x => x.Key.Equals(color, StringComparison.OrdinalIgnoreCase));
            return await Task.FromResult(tolerance.Equals(new KeyValuePair<string, double>()) ? Tolerance.First().Value : tolerance.Value);

        }

        /// <summary>
        /// returns colors for multipler
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetMultiplierColorCodesAsync()
        {
            return await Task.FromResult(Multipliers.Select(x => x.Key).ToList());
        }

        /// <summary>
        /// returns colors for tolarance
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetToleranceColorCodesAsync()
        {
            return await Task.FromResult(Tolerance.Select(x => x.Key).ToList());
        }
    }
}
