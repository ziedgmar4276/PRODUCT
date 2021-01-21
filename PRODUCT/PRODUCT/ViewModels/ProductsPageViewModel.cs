using PRODUCT.DB;
using PRODUCT.Models;
using PRODUCT.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRODUCT.ViewModels
{

    public class ProductsPageViewModel : BaseViewModel
    {
        private ProductViewModel _selectedProduct;
        private IProductStore _productStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<ProductViewModel> Products { get; private set; }
            = new ObservableCollection<ProductViewModel>();

        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetValue(ref _selectedProduct, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddProductCommand { get; private set; }
        public ICommand SelectProductCommand { get; private set; }
        public ICommand DeleteProductCommand { get; private set; }


        public ProductsPageViewModel(IProductStore productStore, IPageService pageService)
        {
            _productStore = productStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddProductCommand = new Command(async () => await AddProduct());
            SelectProductCommand = new Command<ProductViewModel>(async p => await SelectProduct(p));
            DeleteProductCommand = new Command<ProductViewModel>(async p => await DeleteProduct(p));

            MessagingCenter.Subscribe<ProductsDetailViewModel, Product>
                (this, Events.ProductAdded, OnProductAdded);

            MessagingCenter.Subscribe<ProductsDetailViewModel, Product>
            (this, Events.ProductUpdated, OnProductUpdated);
        }



        private void OnProductAdded(ProductsDetailViewModel source, Product product)
        {
            Products.Add(new ProductViewModel(product));
        }

        private void OnProductUpdated(ProductsDetailViewModel source, Product product)
        {
            var contactInList = Products.Single(c => c.Id == product.Id);

            contactInList.Id = product.Id;
            contactInList.ProductName = product.Product_Name;
            contactInList.ProductDescription = product.Product_Description;
            contactInList.Prix = product.Prix;
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var products = await _productStore.GetProductsAsync();
            foreach (var product in products)
                Products.Add(new ProductViewModel(product));
        }

        private async Task AddProduct()
        {
            await _pageService.PushAsync(new ProductsDetailPage(new ProductViewModel()));
        }

        private async Task SelectProduct(ProductViewModel product)
        {
            if (product == null)
                return;

            SelectedProduct = null;
            await _pageService.PushAsync(new ProductsDetailPage(product));
        }


        private async Task DeleteProduct(ProductViewModel productViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {productViewModel.ProductName}?", "Yes", "No"))
            {
                Products.Remove(productViewModel);

                var contact = await _productStore.GetProduct(productViewModel.Id);
                await _productStore.DeleteProduct(contact);
            }

        }
    }
}
