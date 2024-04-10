using Cosmetics.Core.Contracts;
using System;
using System.Collections.Generic;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {

            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);
            string name = CommandParameters[0];

            if (Repository.ProductExists(name))
            {
                throw new ArgumentException("Product already exists! ");
            }

            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2], "Price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            string ingredients = CommandParameters[4];

            Repository.CreateToothpaste(name, brand, price, gender, ingredients);
            return $"Toothpaste with name {name} was created!";

        }
    }
}
