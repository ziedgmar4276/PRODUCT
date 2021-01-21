using PRODUCT.DB;
using PRODUCT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRODUCT.ViewModels
{
    public class ProductsDetailViewModel
    {
        private readonly IProductStore _productStore;
        private readonly IPageService _pageService;
        public Product product { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ProductsDetailViewModel(ProductViewModel viewModel, IProductStore productStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _productStore = productStore;
            SaveCommand = new Command(async () => await Save());
            product = new Product
            {
                Id = viewModel.Id,
                Product_Name = viewModel.ProductName,
                Product_Description = viewModel.ProductDescription,
                Prix =viewModel.Prix,
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(product.Product_Name) && String.IsNullOrWhiteSpace(product.Product_Description))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name and description.", "OK");
                return;
            }
            if (product.Id == 0)
            {
                await _productStore.AddProduct(product);
                MessagingCenter.Send(this, Events.ProductAdded, product);
            }
            else
            {
                await _productStore.UpdateProduct(product);
                MessagingCenter.Send(this, Events.ProductUpdated, product);
            }
            await _pageService.PopAsync();
        }


    }
}
