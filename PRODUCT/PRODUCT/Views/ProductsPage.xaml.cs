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
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            var productStore = new SQLiteProductStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ProductsPageViewModel(productStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }


        void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectProductCommand.Execute(e.SelectedItem);
        }
        public ProductsPageViewModel ViewModel
        {
            get { return BindingContext as ProductsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}