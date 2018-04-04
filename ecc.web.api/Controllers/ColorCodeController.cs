using System.Collections.Generic;
using System.Threading.Tasks;
using ecc.business.logic.Interfaces;
using ecc.common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecc.web.api.Controllers
{
    //[Route("api/[controller]")]
    public class ColorCodeController : Controller
    {
        private readonly IColorCodingComponents _colorCodingComponents;
        public ColorCodeController(IColorCodingComponents colorCodingComponents)
        {
            _colorCodingComponents = colorCodingComponents;
        }


        [Route(@"api/colorcodes/")]
        [HttpGet]
        public async Task<IEnumerable<string>> CalculateOhmValue()
        {
            return await _colorCodingComponents.GetColorBandsAsync();
        }

        [Route(@"api/multiplyercolors/")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetMultiplyerColors()
        {
            return await _colorCodingComponents.GetMultiplierColorCodesAsync();
        }

        [Route(@"api/tolarancecolors/")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetTolaranceColors()
        {
            return await _colorCodingComponents.GetToleranceColorCodesAsync();
        }
    }
}