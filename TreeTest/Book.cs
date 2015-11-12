﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest
{
    public class Book : IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return String.Format("Автор - {0}, Название - {1}, Год публикации - {2}, Жанр - {3}", Author, Title, Year, Genre);
        }

        public bool Equals(Book other)
        {
            return Author.Equals(other.Author) && Title.Equals(other.Title);
        }

        public Book Clone()
        {
            return new Book() { Author = this.Author, Title = this.Title, Year = this.Year, Genre = this.Genre };
        }

        public int CompareTo(Book other)
        {
           return this.Title.CompareTo(other.Title);
        }
    }

}
