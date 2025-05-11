using UnityEngine;

namespace EisvilTest.Framework
{
    public abstract class PooledObject<T> : MonoBehaviour where T : PooledObject<T>
    {
        public Pool<T> Pool { protected get; set; }

        public virtual void Initialize() { }

        public virtual void Disable() { }

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }

        public virtual void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        protected virtual T Get()
        {
            return Pool.Get();
        }

        protected virtual void Release()
        {
            Pool.Release((T)this);
        }
    }
}