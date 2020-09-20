using Buisness.Events;
using Domain.Entities;
using DomainAccess.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AddProductModule.ViewModels
{
    public class CreationProductViewModel : BindableBase
    {
        private string _productTitle;
        private string _productDescription;
        private decimal _coast;
        private int _categoryId;
        private bool _isVisible;
        private Category _selectedCategory;
        private IEnumerable<Category> _categories;

        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IEventAggregator _eventAggregator;

        public string ProductTitle
        {
            get { return _productTitle; }
            set { SetProperty(ref _productTitle, value); }
        }
        public string ProductDescription
        {
            get { return _productDescription; }
            set { SetProperty(ref _productDescription, value); }
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
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }
        public IEnumerable<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        public ICommand CreateProductCommand { get; private set; }
        public ICommand OpenDialogCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public CreationProductViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _categoryRepository = Config.Configuration.Resolve<ICategoryRepository>();
            _productRepository = Config.Configuration.Resolve<IProductRepository>();
            var categories = _categoryRepository.GetCategories();
            if(!categories.IsCompleted)
            {

            }
            Categories = categories.Data;
            CreateProductCommand = new DelegateCommand(CreateProduct, CanCreateProduct);
            OpenDialogCommand = new DelegateCommand(OpendDialog);
            CancelCommand = new DelegateCommand(Cancel);
           
        }

        private void Cancel()
        {
            IsVisible = false;
        }

        private void OpendDialog()
        {
            IsVisible = true;
        }

        private bool CanCreateProduct()
        {
            return true;
        }

        private void CreateProduct()
        {
            if (ProductTitle != null && ProductDescription != null && SelectedCategory != null && Coast>0)
            {
                var products = _productRepository.GetAllProduct().Data;
                var newProduct = new Product(products.Last().Id + 1,ProductTitle,ProductDescription,Coast,SelectedCategory.Id,SelectedCategory);
                
                _eventAggregator.GetEvent<ProductAddedEvent>().Publish(newProduct);
                IsVisible = false;
            }
        }
    }
}
