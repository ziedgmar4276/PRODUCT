using PRODUCT.DB;
using PRODUCT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRODUCT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsDetailPage : ContentPage
    {
        public ProductsDetailPage(ProductViewModel viewModel)
        {
            InitializeComponent();

            var productStore = new SQLiteProductStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.ProductName == null) ? "New Product" : "Edit Product";
            BindingContext = new ProductsDetailViewModel(viewModel ?? new ProductViewModel(), productStore, pageService);
        }
    }
}