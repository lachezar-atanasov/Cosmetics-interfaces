using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using System.Collections.Generic;
using Cosmetics.Commands.Enums;

namespace Cosmetics.Commands
{
    public class RemoveFromShoppingCartCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 1;

        public RemoveFromShoppingCartCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments, 
                nameof(CommandType.RemoveFromShoppingCart));


            string productToRemove = CommandParameters[0];

            return RemoveFromShoppingCart(productToRemove);
        }

        private string RemoveFromShoppingCart(string productName)
        {
            IShoppingCart shoppingCart = Repository.ShoppingCart;
            IProduct product = Repository.FindProductByName(productName);

            shoppingCart.RemoveProduct(product);

            return $"Product {productName} was removed from the shopping cart!";
        }
    }
}
