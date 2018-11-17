using System.Collections.Generic;
using System.Linq;
using RestWithAspNetAuthentication.Data.Converter;
using RestWithAspNetAuthentication.Data.VO;
using RestWithAspNetAuthentication.Model;

namespace RestWithAspNetAuthentication.Data.Converters
{
    public class BookConverter : IParser<BookVO,Book>, IParser<Book,BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if(origin == null) return new Book();

            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null) return new List<Book>();

            return origin.Select(item => Parse(item)).ToList();
        }

        public BookVO Parse(Book origin)
        {
            if(origin == null) return new BookVO();

            return new BookVO
            {
                Id = origin.Id,
                Price = origin.Price,
                Author = origin.Author,
                Title = origin.Title,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null) return new List<BookVO>();

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}