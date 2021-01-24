using PRODUCT.DB;
using PRODUCT.ViewModels;
using NSubstitute;
using NUnit.Framework;
using System;
using Moq;

namespace TestsFinal
{
    public class Tests
    {
        private ProductViewModel _viewModel;
        private ProductsPageViewModel _viewModelProductsPage;
        private ProductsDetailViewModel _vmd;
        private Mock<IPageService> _pageService;
        private Mock<IProductStore> _productStore;
        [SetUp]
        public void Setup()
        {
            _productStore = new Mock<IProductStore>();
            _pageService = new Mock<IPageService>();
            _viewModelProductsPage = new ProductsPageViewModel(_productStore.Object,_pageService.Object);
            _viewModel = new ProductViewModel();
            _vmd = new ProductsDetailViewModel(_viewModel, _productStore.Object, _pageService.Object);
        }

      

        [Test()]
        public void add()
        {
            _viewModelProductsPage.AddProductCommand.Execute(null);
            Assert.AreEqual(1, _viewModelProductsPage.Products);





            //Arrange
         //  var  sqlite = new SQLiteDb();
          // var productStore = new SQLiteProductStore(sqlite);
           // var pageService = Substitute.For<IPageService>();
         //  var addService = Substitute.For<IProductStore>();
         //  var vm = new ProductsPageViewModel(productStore, pageService);
            
            //Act
        //vm.LoadDataCommand.Execute(null);
        //    var x = vm.Products;

            //Assert

//Assert.IsNotNull(x);
        }
        [Test]
        public  void selected_product_isdeselceted()
        {
            var products = new ProductViewModel();
            _viewModelProductsPage.Products.Add(products);
            _viewModelProductsPage.SelectProductCommand.Execute(products);
            Assert.IsNull(_viewModelProductsPage.SelectedProduct);

        }
        [Test]
        public void test_navigation()
        {
            var products = new ProductViewModel();
            _viewModelProductsPage.Products.Add(products);
            _viewModelProductsPage.SelectProductCommand.Execute(products);
            //_pageService.Verify(p => p.PushAsync(It.IsAny<ProductsDetailViewModel>())) ;

        }
        
    }
}