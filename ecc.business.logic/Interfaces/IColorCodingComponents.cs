using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecc.business.logic.Interfaces
{
    public interface IColorCodingComponents
    {
        Task<double?> GetMultipliersAsync(string color);

        Task<double?> GetToleranceAsync(string color);

        Task<IEnumerable<string>> GetColorBandsAsync();

        Task<int> GetColorBandValueAsync(string color);

        Task<IEnumerable<string>> GetMultiplierColorCodesAsync();

        Task<IEnumerable<string>> GetToleranceColorCodesAsync();
    }
}
