using System;
using RestWithAspNetGenerictValueObject.Model.Base;

namespace RestWithAspNetGenerictValueObject.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}