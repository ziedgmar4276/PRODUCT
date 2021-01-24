using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NSubstitute;
using PRODUCT.DB;
using NUnit.Framework;
namespace PRODUCTTEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Produit p = new Produit("58", "aziz", "eeee");
            //IDAoImpProduit daopr = new IDAoImpProduit();
            //bool veri=daopr.ajout(p);
            //Assert.IsTrue(veri);
            //IFakeDAO fake = Substitute.For<ISQliteDB>();
            // fake.ajout().Returns(true);
            // ConsoleProduit d = new ConsoleProduit();
            //  bool pp = d.ajoutt(fake);
            //  Assert.IsTrue(pp);
            //Arrange
            var sqlite = new SQLiteDb();
            var productStore = new SQLiteProductStore(sqlite);
            var pageService = Substitute.For<IPageService>();
            var addService = Subtitute.For<IProductStore>();
            var vm = new ProductsPageViewModel(productStore, pageService);


            //Act
            vm.LoadDataCommand.Execute(null);
            var x = vm.Products;
            vm.AddProductCommand.Execute(null);
            //Assert

            Assert.IsNotNull(x);
        }
    }
}
