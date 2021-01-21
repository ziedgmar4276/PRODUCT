using PRODUCT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRODUCT.ViewModels
{
   public  class ProductViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public ProductViewModel() { }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            _productName = product.Product_Name;
            _productDescription = product.Product_Description;
            _Prix = product.Prix;
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                SetValue(ref _productName, value);
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription; }
            set
            {
                SetValue(ref _productDescription, value);
                OnPropertyChanged(nameof(ProductDescription));
            }
        }
        private int _Prix;
        public int Prix
        {
            get { return _Prix; }
            set
            {
                SetValue(ref _Prix, value);
                OnPropertyChanged(nameof(Prix));
            }
        }
    }
}
