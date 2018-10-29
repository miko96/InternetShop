using IShop.DataLayer.Common.UnitOfWork;
using IShop.DataLayer.Entities;
using System.Threading.Tasks;

namespace IShop.DataLayer
{
    public interface IShopUnitOfWork
    {
        IRepository<Post> Posts { get; }
        IRepository<Comment> Comments { get; }

        Task SaveAsync();
    }
}
