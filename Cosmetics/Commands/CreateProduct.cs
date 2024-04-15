using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Exceptions;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using CommandType = Cosmetics.Commands.Enums.CommandType;

namespace Cosmetics.Commands
{
    public class CreateProduct : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 4;
        public CreateProduct(IList<string> parameters, IRepository repository)
        :base(parameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfParameters = CommandParameters.Count;
            ValidationHelper.ValidateArgumentsCount(numberOfParameters, ExpectedNumberOfArguments, nameof(CommandType.CreateProduct));
            string name = CommandParameters[0];
            string brand = CommandParameters[1];
            if (!decimal.TryParse(CommandParameters[2],NumberStyles.Any,CultureInfo.InvariantCulture,out decimal price))
            {
                throw new InvalidInputException($"Third parameter should be price (real number).");
            }

            if (!Enum.TryParse<GenderType>(CommandParameters[3], true, out GenderType result))
            {
                throw new InvalidInputException("Forth parameter should be one of Men, Women or Unisex.");
            }
            GenderType gender = result;

            if (Repository.ProductExists(name))
            {
                throw new DuplicateNameException($"Product with name {name} already exists! ");
            }
            this.Repository.CreateProduct(name, brand, price, gender);

            return $"Product with name {name} was created!";
        }
    }
}
