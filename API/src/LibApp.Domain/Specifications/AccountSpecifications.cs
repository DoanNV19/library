using LibApp.Domain.Entities;
using LibApp.Domain.Enums;
using LibApp.Domain.Core.Specifications;

namespace LibApp.Domain.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string emailId, string password)
        {
            return new BaseSpecification<User>(x => x.EmailId == emailId && x.IsDeleted == false);
        }

        public static BaseSpecification<User> GetAllActiveUsersSpec()
        {
            return new BaseSpecification<User>(x=>x.IsDeleted == false);
        }
    }
}
