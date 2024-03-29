﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Bilgisayar"},
                new Category{CategoryId=2, CategoryName="Telefon"},
            };

            List<Product> products = new List<Product>
            {
                new Product {productId = 1, CategoryId = 1, productName = "Acer Laptop", QuantityPerUnit = "32 GB Ram", UnitPrice =10000, UnitsInStock=5},
                new Product {productId = 2, CategoryId = 1, productName = "Asus Laptop", QuantityPerUnit = "12 GB Ram", UnitPrice =8000, UnitsInStock=3},
                new Product {productId = 3, CategoryId = 1, productName = "Hp Laptop", QuantityPerUnit = "8 GB Ram", UnitPrice =6000, UnitsInStock=2},
                new Product {productId = 4, CategoryId = 2, productName = "Samsung Telefon", QuantityPerUnit = "4 GB Ram", UnitPrice =5000, UnitsInStock=15},
                new Product {productId = 5, CategoryId = 2, productName = "Apple Telefon", QuantityPerUnit = "4 GB Ram", UnitPrice =8000, UnitsInStock=0},

            };

            Console.WriteLine("Algoritmik-----------------");


            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    Console.WriteLine(product.productName);

                }
            }

            Console.WriteLine("Linq-----------------");

            var result = products.Where(p=>p.UnitPrice>5000 && p.UnitsInStock>3);

            foreach (var product in result)
            {
                Console.WriteLine(product.productName);
            }



            GetProducts(products);
        }

        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    filteredProducts.Add(product);
                }
            }

            return filteredProducts;
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();

        }


    }

    class Product
    {
        public int productId{ get; set; }
        public int CategoryId { get; set; }
        public string productName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
