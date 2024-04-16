using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using Cosmetics.Commands.Enums;
using Cosmetics.Exceptions;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand: BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {

        }

        public override string Execute()
        {
            int numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments, nameof(CommandType.CreateCream));
            string name = CommandParameters[0];

            if (Repository.ProductExists(name))
            {
                throw new InvalidInputException("Product already exists! ");
            }

            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2],"Price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            ScentType scentType = ParseScentType(CommandParameters[4]);

            Repository.CreateCream(name, brand, price, gender, scentType);
            return $"Cream with name {name} was created!";
        }

    }
}
