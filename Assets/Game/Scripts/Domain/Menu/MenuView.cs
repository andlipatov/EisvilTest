using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public abstract class MenuView : MonoBehaviour
    {
        protected MenuStateMachine _menuStateMachine;

        public virtual void Initialize(Transform _parent)
        {
            transform.SetParent(_parent, false);
            _menuStateMachine = Injector.Get<MenuStateMachine>();
        }

        public abstract void Enable();

        public abstract void Disable();

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}