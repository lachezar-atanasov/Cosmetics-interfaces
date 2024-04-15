using Cosmetics.Core.Contracts;
using System;
using System.Collections.Generic;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using Cosmetics.Exceptions;

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

            string name = CommandParameters[0];

            if (Repository.ProductExists(name))
            {
                throw new InvalidInputException("Product already exists! ");
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
