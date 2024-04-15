﻿using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using System.Collections.Generic;
using Cosmetics.Commands.Enums;

namespace Cosmetics.Commands
{
    public class AddToShoppingCartCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 1;

        public AddToShoppingCartCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments,nameof(CommandType.AddToShoppingCart));

            string productToAdd = this.CommandParameters[0];

            return AddToShoppingCart(productToAdd);
        }

        private string AddToShoppingCart(string productName)
        {
            IShoppingCart shoppingCart = this.Repository.ShoppingCart;
            IProduct product = this.Repository.FindProductByName(productName);

            shoppingCart.AddProduct(product);

            return $"Product {productName} was added to the shopping cart!";
        }
    }
}
