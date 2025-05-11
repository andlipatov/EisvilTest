using EisvilTest.Framework;

namespace EisvilTest
{
    public class RedEnemyPool : Pool<RedEnemy>
    {
        private const int _CAPACITY = 20;
        private const int _SIZE = 40;

        public override void Create()
        {
            Injector.Bind(this);

            _capacity = _CAPACITY;
            _size = _SIZE;

            base.Create();
        }
    }
}