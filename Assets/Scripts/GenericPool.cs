using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly Transform _parentTransform;
    private readonly Queue<T> _objects = new Queue<T>();
    
    public GenericPool(T prefab, int initialSize, Transform parentTransform = null)
    {
        _prefab = prefab;
        _parentTransform = parentTransform;

        InitPool(initialSize);
    }

    private void InitPool(int initialSize)
    {
        for (int i = 0; i < initialSize; i++)
        {
            var newObj = Create();
            newObj.gameObject.SetActive(false);
            _objects.Enqueue(newObj);
        }
    }
    
    public T Get()
    {
        T obj;
        obj = _objects.Count == 0 ? Create() : _objects.Dequeue();
        obj.gameObject.SetActive(true);
        _objects.Enqueue(obj);
    
        return obj;
    }

    public void Return(T obj)
    {
        if (!obj.gameObject.activeInHierarchy)
        {
            return;
        }

        obj.gameObject.SetActive(false);
    }
    
    public IEnumerable<T> GetAllObj()
    {
        return _objects.Where(obj => obj != null);
    }

    private T Create()
    {
        var obj = Object.Instantiate(_prefab, _parentTransform);
        return obj;
    }
    
}