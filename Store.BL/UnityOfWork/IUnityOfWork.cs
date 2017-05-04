using Store.BL.Repository;

namespace Store.BL.UnityOfWork
{
    public interface IUnityOfWork
    {
        ProductRepository Products { get; }
        void Save();
    }
}
