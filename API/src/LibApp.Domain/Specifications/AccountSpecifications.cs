using LibApp.Domain.Entities;
using LibApp.Domain.Enums;
using LibApp.Domain.Core.Specifications;

namespace LibApp.Domain.Specifications
{
    public static class AccountSpecifications
    {
        public static BaseSpecification<Account> GetAllByUserName(string userName)
        {
            return new BaseSpecification<Account>(x => x.UserName == userName);
        }

        public static BaseSpecification<Account> GetAccountByUserName(string userName)
        {
            return new BaseSpecification<Account>(x => x.UserName == userName && x.IsDeleted == false);
        }

        public static BaseSpecification<Account> GetAccountByUserNameAndPass(string userName, string password)
        {
            return new BaseSpecification<Account>(x => x.UserName == userName && x.Password == password && x.IsDeleted == false);
        }

        public static BaseSpecification<Account> GetAccountInList(List<Guid> ids)
        {
            return new BaseSpecification<Account>(x => ids.Contains(x.Id) && x.IsDeleted == false);
        }
    }
}
