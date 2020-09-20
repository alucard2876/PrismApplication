using Buisness.Events;
using Buisness.Extentions;
using Domain.Entities;
using DomainAccess.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CatalogModule.ViewModels
{
    public class CatalogViewModel : BindableBase
    {
        private ObservableCollection<Product> _products;
        private IEventAggregator _eventAgreagator;
        private Product _currentProduct;
        private Category _currentCategory;
        private int? _id;
        private bool? _isVisible = null;
        private IProductRepository _productRepository;

        public bool? IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }


        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }
        public Product CurrentProduct
        {
            get { return _currentProduct; }
            set { SetProperty(ref _currentProduct, value); }
        }

        public ICommand RemoveCommand { get;  set; }
        public ICommand ClosePopup { get; set; }

        public CatalogViewModel(IEventAggregator eventAggregator)
        {
            _eventAgreagator = eventAggregator;
            _productRepository = Config.Configuration.Resolve<IProductRepository>();
            var products = _productRepository.GetAllProduct();
            if(!products.IsCompleted)
            {

            }
            Products = products.Data.ToObservableCollection();
            CurrentProduct = Products.First();
            RemoveCommand = new DelegateCommand<int?>(Execute, CanExecute);
            ClosePopup = new DelegateCommand(Close, CanClose);
            _eventAgreagator.GetEvent<CategoryChangedEvent>().Subscribe(ChangeProducts);
            _eventAgreagator.GetEvent<ProductAddedEvent>().Subscribe(UpdateProducts);
        }
        
        private void UpdateProducts(Product product)
        {
            _productRepository.AddProduct(product);
            Products = _productRepository.GetAllProduct().Data.ToObservableCollection();
        }

        private void ChangeProducts(Category obj)
        {
            _currentCategory = obj;
            if (_currentCategory != null)
                Products = _productRepository.GetAllProduct().Data.Where(p => p.CategoryId == obj.Id).ToObservableCollection();
            else
                Products = _productRepository.GetAllProduct().Data.ToObservableCollection();
        }

        private void Close()
        {
            IsVisible = !IsVisible;
        }

        private bool CanClose()
        {
            return true;
        }

        private void Execute(int? id)
        {
            if (CurrentProduct!=null && CurrentProduct.Id == id.Value)
            {
                var products = _productRepository.DeleteProduct(CurrentProduct.Id).Data ;
                
                if (_currentCategory == null)
                    Products = products.ToObservableCollection();
                else Products = products.Where(p => p.CategoryId == _currentCategory.Id).ToObservableCollection();
            }
            else IsVisible = true;
        }

        private bool CanExecute(int? id)
        {
            return true;
        }
    }
}
