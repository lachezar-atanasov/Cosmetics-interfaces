using Cosmetics.Core.Contracts;
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
            var numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments,nameof(CommandType.AddToShoppingCart));

            var productToAdd = CommandParameters[0];

            return AddToShoppingCart(productToAdd);
        }

        private string AddToShoppingCart(string productName)
        {
            IShoppingCart shoppingCart = Repository.ShoppingCart;
            IProduct product = Repository.FindProductByName(productName);

            shoppingCart.AddProduct(product);

            return $"Product {productName} was added to the shopping cart!";
        }
    }
}
