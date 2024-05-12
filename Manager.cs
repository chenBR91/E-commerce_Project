﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Manager
    {
        private UserSeller[] sellers;
        private int sellersLogSize=0;
        private UserBuyer[] buyers;
        private int buyersLogSize=0;
        private string name;
        private int size = 2;
        private Product[] productsArr;

        public Manager(string _name)
        {
            this.name = _name;
            buyers = new UserBuyer[size];
            sellers = new UserSeller[size];
        }

        public bool addBuyer(string name, string password, Address address)
        {
            UserBuyer[] tempNewBuyers;

            if (buyers == null)
            {
                tempNewBuyers = new UserBuyer[1];
                tempNewBuyers[0] = new UserBuyer(name, password, address);
            }
            else
            {
                tempNewBuyers = new UserBuyer[buyers.Length + size];
                buyers.CopyTo(tempNewBuyers, 0);
                tempNewBuyers[buyersLogSize] = new UserBuyer(name, password, address);
                buyersLogSize++;
            }
            buyers = tempNewBuyers;
            return true;
        }

        public bool addSeller(string name, string password, Address address)
        {
            UserSeller[] tempNewSellers;

            if (sellers == null)
            {
                tempNewSellers = new UserSeller[1];
                tempNewSellers[0] = new UserSeller(name, password, address);
            }
            else
            {
                tempNewSellers = new UserSeller[sellers.Length + size];
                sellers.CopyTo(tempNewSellers, 0);
                tempNewSellers[sellersLogSize] = new UserSeller(name, password, address);
                sellersLogSize++;
            }
            sellers = tempNewSellers;
            return true;
        }


        public bool addMyProduct(Product product)
        {
            Product[] newProduct;
            foreach (UserBuyer buyer in buyers)
            {
                //if (buyer.GetName() == "Chen")
                //    Console.WriteLine("exsit");
                Console.WriteLine("fff");
            }
            if(productsArr == null)
            {
                newProduct = new Product[1];
                newProduct[0] = new Product(product.GetProductName(), product.GetPrice()); 
            }

            else
            {
                newProduct = new Product[productsArr.Length+1];
                productsArr.CopyTo(newProduct, 0);
                newProduct[productsArr.Length] = new Product(product.GetProductName(), product.GetPrice());
            }
            productsArr = newProduct;

            return true; 
        }


        public bool payOrderAllCart(string name)
        {
            int totalPrice=0;
            foreach (UserBuyer buyer in buyers)
            {
                if (name == buyer.GetName())
                {
                    Console.WriteLine(buyer);
                }

                else
                    return false;
            }
            return true;
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("\n***list all products***\n");
            if(productsArr != null) 
                foreach (Product productDetail in productsArr) 
                {
                    Console.WriteLine($"name: {productDetail.GetProductName()} price: {productDetail.GetPrice()}");
                }
        }
    }
}