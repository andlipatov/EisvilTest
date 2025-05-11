using UnityEngine;

namespace EisvilTest
{
    public interface IControllable
    {
        public void HandleMove(Vector2 direction);
        public void HandleLook(Vector2 direction);
        public void HandleShoot();
    }
}