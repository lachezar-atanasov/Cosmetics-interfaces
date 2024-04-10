using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;
        private string _ingredients;
        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            :base(name,brand,price,gender)
        {
            Ingredients = ingredients;
        }
        public override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }
        public override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength);
        }
        public override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }
        public string Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Ingredients can't be null! ");
                }
                _ingredients = value;
            }
        }

        public override string Print()
        {
            string commaSeparatedIngredients = String.Join(", ",Ingredients.Split(","));
            StringBuilder sb = new StringBuilder(GetProductBaseInfo());
            sb.AppendLine($" #Ingredients: {commaSeparatedIngredients}");
            sb.AppendLine($" ===");
            return sb.ToString();
        }
    }
}
