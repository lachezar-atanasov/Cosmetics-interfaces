using Cosmetics.Commands.Contracts;
using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Commands.Enums;
using Cosmetics.Exceptions;

namespace Cosmetics.Commands
{
    public class CreateCategoryCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 1;

        public CreateCategoryCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments, nameof(CommandType.CreateCategory));

            string categoryName = CommandParameters[0];
            return CreateCategory(categoryName);
        }

        private string CreateCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new InvalidInputException("Category name cannot be null or empty.");
            }

            if (categoryName.Length<3 || categoryName.Length>10)
            {
                throw new InvalidInputException("Category name should be between 3 and 10 symbols.");
            }
            if (Repository.CategoryExists(categoryName))
            {
                throw new DuplicatedEntityException(string.Format($"Category with name {categoryName} already exists!"));
            }

            Repository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }
    }
}
