using LibApp.Domain.Entities;
using LibApp.Domain.Enums;
using LibApp.Domain.Core.Specifications;

namespace LibApp.Domain.Specifications
{
    public static class BorrowSpecifications
    {
        public static BaseSpecification<Borrow> GetBorrowByFilter(string? keyword,Guid? bookId,Guid? customerId)
        {
            return new BaseSpecification<Borrow>(x => (string.IsNullOrEmpty(keyword) || x.Book!.Name == keyword
            || x.Customer!.FirstName == keyword
            || x.Customer.LastName == keyword)
            && ( bookId == null || x.BookId == bookId)
            && ( customerId == null || x.CustomerId == customerId)
            );
        }
    }
}
