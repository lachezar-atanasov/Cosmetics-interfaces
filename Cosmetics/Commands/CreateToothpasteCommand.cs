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

/*            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);
            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];
            decimal price = ParseDecimalParameter(this.CommandParameters[2], "Price");
            GenderType gender = ParseGenderType(this.CommandParameters[3]);
*/


            throw new ArgumentException();

        }
    }
}
