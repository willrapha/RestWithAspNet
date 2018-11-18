﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithAspNetDockers.Model.Base;

namespace RestWithAspNetDockers.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}