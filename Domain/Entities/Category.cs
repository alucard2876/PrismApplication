using Prism.Mvvm;
using System;

namespace Domain.Entities
{
    [Serializable]
    public class Category : BindableBase
    {
        private int _id;
        private string _categoryTitle;
        public int Id 
        {
            get { return _id; } 
            set { SetProperty(ref _id, value); } 
        }
        public string CategoryTitle 
        {
            get { return _categoryTitle; } 
            set { SetProperty(ref _categoryTitle, value); } 
        }
        public Category()
        {

        }
        public Category(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
                throw new ArgumentNullException("category can`t be empty", nameof(categoryName));
        }
    }
}
