using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Interfaces
{
    public interface ICountryService
    {
        /// <summary>
        /// Create country
        /// </summary>
        /// <param name="req">contry data</param>
        /// <returns></returns>
        Task<ResultDto<CountryDtoRes>> CreateCountry(CreateCountryReq req);
    }
}
