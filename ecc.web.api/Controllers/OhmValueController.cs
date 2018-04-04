using System.Collections.Generic;
using System.Threading.Tasks;
using ecc.business.logic.Interfaces;
using ecc.common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecc.web.api.Controllers
{
    [Route("api/[controller]")]
    public class OhmValueController : Controller
    {
        private readonly IOhmValueCalculator _ohmValueCalculator;
        public OhmValueController(IOhmValueCalculator ohmValueCalculator)
        {
            _ohmValueCalculator = ohmValueCalculator;
        }


        [HttpPost]
        public async Task<OhmValueResponse> CalculateOhmValue([FromBody]InputColorCodesModel inputColorCodes)
        {

            return await _ohmValueCalculator.CalculateOhmValue(inputColorCodes.BandAColor, inputColorCodes.BandBColor,
                        inputColorCodes.BandCColor, inputColorCodes.BandDColor);
        }


    }
}