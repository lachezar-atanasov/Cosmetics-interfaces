using Cosmetics.Core.Contracts;
using Cosmetics.Exceptions;
using Cosmetics.Models;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Core
{
    public class Repository : IRepository
    {
        private readonly List<IProduct> products;
        private readonly List<ICategory> categories;
        private readonly IShoppingCart shoppingCart;

        public Repository()
        {
            this.products = new List<IProduct>();
            this.categories = new List<ICategory>();

            this.shoppingCart = new ShoppingCart();
        }

        public IShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;
            }
        }

        public IList<ICategory> Categories
        {
            get
            {
                return new List<ICategory>(this.categories);
            }
        }
        public IList<IProduct> Products
        {
            get
            {
                return new List<IProduct>(this.products);
            }
        }

        public void CreateCategory(string categoryToAdd)
        {
            ICategory category = new Category(categoryToAdd);
            this.categories.Add(category);
        }
        public IProduct CreateProduct(string name, string brand, decimal price, GenderType gender)
        {
            Product product = new Product(name, brand, price, gender);
            this.products.Add(product);
            return product;
        }
        public IShampoo CreateShampoo(string name, string brand, decimal price, GenderType genderType, int millilitres, UsageType usageType)
        {
            Shampoo shampoo = new Shampoo(name,  brand, price,genderType, millilitres,  usageType);
            products.Add(shampoo);
            return shampoo;
        }
        public ICream CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scentType)
        {
            Cream cream = new Cream(name, brand, price,gender, scentType);
            products.Add(cream);
            return cream;
        }
        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType genderType, string ingredients)
        {
            Toothpaste toothpaste = new Toothpaste(name, brand, price, genderType, ingredients);
            products.Add(toothpaste);
            return toothpaste;
        }

        public ICategory FindCategoryByName(string categoryName)
        {
            foreach (ICategory category in categories)
            {
                if (category.Name == categoryName)
                {
                    return category;
                }
            }

            throw new InvalidInputException($"Category {categoryName} does not exist!");
        }

        public IProduct FindProductByName(string productName)
        {
            return products.FirstOrDefault(x => x.Name == productName) ?? 
                throw new InvalidInputException("There is no product with that name. ");
        }

        public bool CategoryExists(string categoryName)
        {
            bool exists = false;

            foreach (ICategory category in categories)
            {
                if (category.Name == categoryName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        public bool ProductExists(string productName)
        {
            bool exists = false;

            foreach (IProduct product in products)
            {
                if (product.Name == productName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
    }
}
