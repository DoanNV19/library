using LibApp.Application.Models.DTOs;

namespace LibApp.Application.Models.Responses
{
    public class GetAllActiveUsersRes
    {
        public IList<UserDTO> Data { get; set; }
    }
}
