using LibApp.Domain.Entities;
using LibApp.Domain.Enums;
using LibApp.Domain.Core.Specifications;

namespace LibApp.Domain.Specifications
{
    public static class BookSpecifications
    {
        public static BaseSpecification<Book> GetBookByKeyword(string? keyword)
        {
            return new BaseSpecification<Book>(x => string.IsNullOrEmpty(keyword) || x.Name == keyword || x.Description == keyword || x.Author.Name == keyword);
        }
    }
}
