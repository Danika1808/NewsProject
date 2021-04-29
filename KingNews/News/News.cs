using System;

namespace News
{
    public class News
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Date { get; protected set; }
        public decimal Rating { get; protected set; }
        public Category Category { get; protected set; }
        public string Content { get; protected set; }
        public Image? Image { get; protected set; }

        protected News()
        {
        }

        public News(string name, DateTime data, decimal rating, Category category, string content, Image image)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Date = data;
            Rating = rating;
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Image = image;
        }

        public void Update(string name = "", DateTime date = new(), decimal rating = -1.0m, Category category = null, string content = "")
        {
            if (!string.IsNullOrEmpty(name))
            {
                ChangeName(name);
            }

            if (date != new DateTime())
            {
                ChangeDate(date);
            }

            if (rating != -1.0m)
            {
                ChangeRating(rating);
            }

            if (category != null)
            {
                ChangeCategory(category);
            }

            if (!string.IsNullOrEmpty(content))
            {
                ChangeContent(content);
            }
        }

        private void ChangeContent(string content) => Content = content;

        private void ChangeCategory(Category category) => Category = category;

        private void ChangeRating(decimal rating) => Rating = rating;

        private void ChangeDate(DateTime date) => Date = date;

        private void ChangeName(string name) => Name = name;
    }
}