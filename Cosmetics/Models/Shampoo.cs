using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Diagnostics;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;
        private int _millilitres;
        private UsageType _usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            :base(name,brand,price,gender)
        {
            Millilitres = millilitres;
            Usage = usage;
        }
        public int Millilitres
        {
            get 
            {
                return _millilitres;
            }
            set
            {
                ValidationHelper.ValidateNonNegative(value, "Millilitres");
                _millilitres = value;
            }
        }
        public UsageType Usage
        {
            get
            {
                return _usage;
            }
            set
            {
                _usage = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(GetProductBaseInfo());
            sb.AppendLine($" #Milliliters: {Millilitres}");
            sb.AppendLine($" #Usage: {Usage}");
            sb.AppendLine($" ===");
            return sb.ToString();
        }
    }
}
