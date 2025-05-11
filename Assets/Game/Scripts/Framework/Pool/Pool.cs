using System.Collections.Generic;
using UnityEngine;

namespace EisvilTest.Framework
{
    public class Pool<T> : MonoBehaviour where T : PooledObject<T>
    {
        [Header("Prefabs")]
        [SerializeField] protected T _prefab;

        protected List<T> _activeList;
        protected Stack<T> _inactiveStack;

        protected int _capacity;
        protected int _size;

#if UNITY_EDITOR
        public int Count => _activeList.Count + _inactiveStack.Count;
        public int ActiveCount => _activeList.Count;
        public int InactiveCount => _inactiveStack.Count;
#endif

        public virtual void Create()
        {
            _activeList = new List<T>();
            _inactiveStack = new Stack<T>();

            for (int i = 0; i < _capacity; i++)
            {
                T pooledObject = Instantiate();
                SetInactive(pooledObject);
            }
        }

        public virtual void Initialize()
        {
            foreach (T pooledObject in _inactiveStack.ToArray())
            {
                pooledObject.Initialize();
            }
        }

        public virtual void Clear()
        {
            while (_activeList.Count > 0)
            {
                T pooledObject = _activeList[0];
                _activeList.RemoveAt(0);
                pooledObject.Disable();
                SetInactive(pooledObject);
            }
        }

        public virtual T Get()
        {
            T pooledObject;

            if (_inactiveStack.Count > 0)
            {
                pooledObject = _inactiveStack.Pop();
            }
            else
            {
                pooledObject = Instantiate();
                pooledObject.Initialize();
            }

            SetActive(pooledObject);

            return pooledObject;
        }

        public virtual void Release(T pooledObject)
        {
            _activeList.Remove(pooledObject);
            pooledObject.Disable();
            SetInactive(pooledObject);
        }

        private T Instantiate()
        {
            T pooledObject = Instantiate(_prefab);
            pooledObject.transform.parent = transform;
            pooledObject.Pool = this;
            return pooledObject;
        }

        private void SetActive(T pooledObject)
        {
            pooledObject.SetActive(true);
            _activeList.Add(pooledObject);
        }

        private void SetInactive(T pooledObject)
        {
            if (_inactiveStack.Count < _size)
            {
                pooledObject.SetActive(false);
                _inactiveStack.Push(pooledObject);
            }
            else
            {
                pooledObject.Destroy();
            }
        }
    }
}