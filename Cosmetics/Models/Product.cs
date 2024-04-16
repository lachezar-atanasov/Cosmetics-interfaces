using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{
    public class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;
        private string _name;
        private string _brand;
        private decimal _price;
        private GenderType _gender;

        public Product(string name, string brand, decimal price, GenderType gender) 
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
        }

        public string Name

        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }

        public string Brand
        {
            get => _brand;
            set
            {
                ValidateBrand(value);
                _brand = value;
            }
        }


        public decimal Price
        {
            get => _price;
            set
            {
                ValidatePrice(value);
                _price = value;
            }
        }

        public GenderType Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder(GetProductBaseInfo());
            sb.AppendLine($" ===");
            return sb.ToString();
        }
        public string GetProductBaseInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#{Name} {Brand}");
            sb.AppendLine($" #Price: {Price}");
            sb.AppendLine($" #Gender: {Gender}");
            return sb.ToString();
        }

        public virtual void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength,"Product name");
        }
        public virtual void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength, "Product brand");
        }
        public virtual void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }
    }
}
