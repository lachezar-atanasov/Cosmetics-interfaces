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
        private readonly List<IProduct> _products = new();
        private readonly List<ICategory> _categories = new();
        public IShoppingCart ShoppingCart { get; } = new ShoppingCart();
        public IList<ICategory> Categories => new List<ICategory>(_categories);
        public IList<IProduct> Products => new List<IProduct>(_products);

        public void CreateCategory(string categoryToAdd)
        {
            ICategory category = new Category(categoryToAdd);
            _categories.Add(category);
        }
        public IProduct CreateProduct(string name, string brand, decimal price, GenderType gender)
        {
            Product product = new(name, brand, price, gender);
            _products.Add(product);
            return product;
        }
        public IShampoo CreateShampoo(string name, string brand, decimal price, GenderType genderType, int millilitres, UsageType usageType)
        {
            Shampoo shampoo = new(name,  brand, price,genderType, millilitres,  usageType);
            _products.Add(shampoo);
            return shampoo;
        }
        public ICream CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scentType)
        {
            Cream cream = new(name, brand, price,gender, scentType);
            _products.Add(cream);
            return cream;
        }
        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType genderType, string ingredients)
        {
            Toothpaste toothpaste = new(name, brand, price, genderType, ingredients);
            _products.Add(toothpaste);
            return toothpaste;
        }

        public ICategory FindCategoryByName(string categoryName)
        {
            foreach (ICategory category in _categories)
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
            return _products.FirstOrDefault(x => x.Name == productName) ?? 
                throw new InvalidInputException("There is no product with that name. ");
        }

        public bool CategoryExists(string categoryName)
        {
            bool exists = false;

            foreach (ICategory category in _categories)
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
            return _products.Any(product => product.Name == productName);
        }
    }
}
