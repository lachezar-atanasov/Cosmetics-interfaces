using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Exceptions;

namespace Cosmetics.Models
{
    public class Category : ICategory
    {
        private const int NameMinLength = 2;
        private const int NameMaxLength = 15;
        private const string ProductNotFoundErrorMessage = "Product not found in category.";

        private readonly string _name;
        private readonly ICollection<IProduct> _products;

        public Category(string name)
        {
            Name = name;
            _products = new List<IProduct>();
        }
        public string Name
        {
            get => _name;
            private init
            {
                ValidationHelper.ValidateStringLength(value, NameMinLength, NameMaxLength, "Category name");
                 _name = value;
            }
        }

        public ICollection<IProduct> Products => new List<IProduct>(_products);

        public void AddProduct(IProduct product)
        {
             _products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            var productFound = _products.FirstOrDefault(x => x.Name == product.Name);

            if (productFound == null)
            {
                throw new InvalidInputException(ProductNotFoundErrorMessage);
            }

            _products.Remove(productFound);
        }

        public string Print()
        {
            if (!_products.Any())
            {
                return $"#Category: {Name}\r\n #No products in this category";
            }

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Category: {Name}");

            foreach (var product in _products)
            {
                strBuilder.Append(product.Print());
            }

            return strBuilder.ToString().Trim();
        }
    }
}
