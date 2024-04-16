using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using System.Collections.Generic;
using Cosmetics.Commands.Enums;

namespace Cosmetics.Commands
{
    public class ShowCategoryCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 1;

        public ShowCategoryCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments,
                nameof(CommandType.ShowCategory));

            string categoryToShow = CommandParameters[0];

            return ShowCategory(categoryToShow);
        }

        private string ShowCategory(string categoryName)
        {
            ICategory category = Repository.FindCategoryByName(categoryName);

            return category.Print();
        }
    }
}
