
using Prism.Mvvm;
using System;

namespace Domain.Entities
{
    [Serializable]
    public class Product : BindableBase
    {
        private int _id;
        private string _title;
        private string _description;
        private decimal _coast;
        private int _categoryId;
        private Category _category;

        public int Id 
        { 
            get { return _id; } 
            set { SetProperty(ref _id, value); }
        }
        public string Title 
        {
            get { return _title; } 
            set { SetProperty(ref _title, value); }
        }
        
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public decimal Coast
        {
            get { return _coast; }
            set { SetProperty(ref _coast, value); }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set { SetProperty(ref _categoryId, value); }
        }

        public Category Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }
        public Product()
        {

        }
        public Product(int id, string title, string description,decimal coast,int categoryId, Category category)
        {
            #region Check parametrs
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
            if (description.Length > 40)
                throw new ArgumentOutOfRangeException(nameof(description));
            if (coast <= 0)
                throw new ArgumentOutOfRangeException(nameof(coast));

            if(categoryId<0)
                throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (category == null)
                throw new ArgumentOutOfRangeException(nameof(category));
            #endregion
            Id = id;
            Title = title;
            Description = description;
            Coast = coast;
            CategoryId = categoryId;
            Category = category;
        }
    }
}
