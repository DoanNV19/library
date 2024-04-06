using LibApp.Application.Models.Requests.Country;
using LibApp.Application.Models.Requests.User;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.CountryRes;
using LibApp.Application.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Interfaces
{
    public interface ICountryService
    {
        Task<ResultDto<CountryDtoRes>> CreateCountry(CreateCountryReq req);
    }
}
