using Cosmetics.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Cosmetics.Exceptions;

namespace Cosmetics.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private const string ProductNotFoundErrorMessage = "Shopping cart does not contain product with name {0}!";

        private readonly ICollection<IProduct> _productList;

        public ShoppingCart()
        {
            _productList = new List<IProduct>();
        }

        public ICollection<IProduct> Products => new List<IProduct>(_productList);

        public void AddProduct(IProduct product)
        {
            _productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (!ContainsProduct(product))
            {
                throw new InvalidInputException(string.Format(ProductNotFoundErrorMessage, product.Name));
            }
            _productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return _productList.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            return _productList.Sum(x => x.Price);
        }
    }
}
