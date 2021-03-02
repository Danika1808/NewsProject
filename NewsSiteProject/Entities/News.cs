using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entities
{
    public class News
    {
        [Column("id")]
        public Guid Id { get; private set; }
        [Column("name")]
        public string Name { get; private set; }
        [Column("content")]
        public string Content { get; private set; }
        [Column("rating")]
        public int Rating { get; private set; }
        [Column("views")]
        public int Views { get; private set; }
        [Column("date")]
        public DateTime Date { get; private set; }
        [Column("type_of_news")]
        public Guid Type { get; private set; }
        protected News() { }

        public News(Guid id, string name, string content, int rating, int views, Guid type)
        {
            Id = id;
            Name = name;
            Content = content;
            Rating = rating;
            Views = views;
            Type = type;
        }

        public void UpdateRating()
        {

        }

        public void UpdateViews()
        {

        }

        public void AddComment()
        {

        }

        public void DeleteComment()
        {

        }

        public void UpdateComment()
        {

        }
    }
}
