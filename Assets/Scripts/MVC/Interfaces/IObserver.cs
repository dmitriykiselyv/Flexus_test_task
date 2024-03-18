namespace MVC.Interfaces
{
    public interface IObserver<in T>
    {
        void DataChanged(T data);
    }
}