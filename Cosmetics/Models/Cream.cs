using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 15;
        private const int BrandMinLength = 3;
        private const int BrandMaxLength = 15;

        public Cream(string name,string brand, decimal price, GenderType gender, ScentType scent)
            :base(name,brand,price,gender)
        {
            Scent = scent;
        }

        public ScentType Scent { get; set; }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(GetProductBaseInfo());
            sb.AppendLine($" #Scent: {Scent}");
            sb.AppendLine($" ===");
            return sb.ToString();
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
    }
}
