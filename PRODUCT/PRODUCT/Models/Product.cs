using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace PRODUCT.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Product_Name { get; set; }
        [MaxLength(255)]
        public string Product_Description { get; set; }
        [MaxLength(255)]
        public int Prix { get; set; }

    }
}
