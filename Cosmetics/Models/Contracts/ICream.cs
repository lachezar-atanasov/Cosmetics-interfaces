using Cosmetics.Models.Enums;

namespace Cosmetics.Models.Contracts
{
    public interface ICream
    {
        ScentType Scent { get; }
    }
}