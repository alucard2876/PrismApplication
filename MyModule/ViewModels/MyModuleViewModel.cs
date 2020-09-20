using Buisness.Events;
using Domain.Entities;
using DomainAccess.Interfaces;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace MyModule.ViewModels
{
    public class MyModuleViewModel : BindableBase
    {
        private Visibility _isVisible;
        private IEventAggregator _eventAggregator;
        private IEnumerable<Category> _categories;
        private Category _currentCategory;
        private ICategoryRepository _categoryRepo;
        

        public Visibility IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public IEnumerable<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        } 

        public Category SelectedCategorie
        {
            get { return _currentCategory; }
            set 
            { 
                SetProperty(ref _currentCategory, value);
                _eventAggregator.GetEvent<CategoryChangedEvent>().Publish(SelectedCategorie);
            }
        }

        public ICommand ClearCategoryCommand { get; private set; }
        
        public MyModuleViewModel(IEventAggregator eventAgregator)
        {
            _eventAggregator = eventAgregator;
            ClearCategoryCommand = new DelegateCommand(ClearCategory);
            _categoryRepo = Config.Configuration.Resolve<ICategoryRepository>();
            var data = _categoryRepo.GetCategories();
            if(!data.IsCompleted)
            {
                //TODO : Implement message box logic
            }
            Categories = data.Data;

        }

        private void ClearCategory()
        {
            _eventAggregator.GetEvent<CategoryChangedEvent>().Publish(null);
        }
    }
}
