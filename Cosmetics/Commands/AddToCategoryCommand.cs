using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using System.Collections.Generic;
using Cosmetics.Commands.Enums;

namespace Cosmetics.Commands
{
    public class AddToCategoryCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 2;

        public AddToCategoryCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            var numberOfParameters = CommandParameters.Count; 
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments,nameof(CommandType.AddProductToCategory));

            var categoryName = CommandParameters[0];
            var productNameToAdd = CommandParameters[1];

            return AddToCategory(categoryName, productNameToAdd);
        }

        private string AddToCategory(string categoryName, string productName)
        {
            var category = Repository.FindCategoryByName(categoryName);
            var product = Repository.FindProductByName(productName);

            category.AddProduct(product);

            return $"Product {productName} added to category {categoryName}!";
        }
    }
}
