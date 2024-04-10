using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Toothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandManLength = 10;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

    }
}
