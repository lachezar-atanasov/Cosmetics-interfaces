using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender) 
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
        }

        public string Name

        {
            get
            {
                return name;
            }
            set
            {
                ValidateName(value);
                name = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                ValidateBrand(value);
                brand = value;
            }
        }


        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                ValidatePrice(value);
                price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public abstract string Print();
        public string GetProductBaseInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#{Name} {Brand}");
            sb.AppendLine($" #Price: {Price}");
            sb.AppendLine($" #Gender: {Gender}");
            return sb.ToString();
        }
        public abstract void ValidateName(string name);
        public abstract void ValidateBrand(string brand);
        public abstract void ValidatePrice(decimal price);
    }
}
