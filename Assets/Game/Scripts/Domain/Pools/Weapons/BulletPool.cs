using EisvilTest.Framework;

namespace EisvilTest
{
    public class BulletPool : Pool<Bullet>
    {
        private const int _CAPACITY = 10;
        private const int _SIZE = 20;

        public override void Create()
        {
            Injector.Bind(this);

            _capacity = _CAPACITY;
            _size = _SIZE;

            base.Create();
        }
    }
}