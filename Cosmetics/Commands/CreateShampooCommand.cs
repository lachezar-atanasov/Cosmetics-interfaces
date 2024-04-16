using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using Cosmetics.Exceptions;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {

        }

        public override string Execute()
        {
            string name = CommandParameters[0];

            if (Repository.ProductExists(name))
            {
                throw new InvalidInputException("Product already exists! ");
            }

            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2],"Price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            int milliliters = ParseIntParameter(CommandParameters[4], "Milliliters");
            UsageType usageType = ParseUsageType(CommandParameters[5]);

            Repository.CreateShampoo(name, brand, price, gender, milliliters, usageType);
            return $"Shampoo with name {name} was created!";
        }

    }
}
