namespace MVC.Interfaces
{
    public interface IObservable<out T>
    {
        void Attach(IObserver<T> observer);
        void Detach(IObserver<T> observer);
        void NotifyObservers();
    }
}