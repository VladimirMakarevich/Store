using Store.BL.Repository;

namespace Store.BL.UnityOfWork
{
    public interface IUnityOfWork
    {
        ProductRepository Products { get; }
        UserRepository Users { get; }
        void Save();
    }
}
