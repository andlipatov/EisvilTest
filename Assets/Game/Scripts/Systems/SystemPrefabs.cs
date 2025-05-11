using UnityEngine;

namespace EisvilTest
{
    [CreateAssetMenu(fileName = "SystemPrefabs", menuName = "EisvilTest/SystemPrefabs")]
    public class SystemPrefabs : ScriptableObject
    {
        public InputSystem InputSystem;
        public LevelSystem LevelSystem;
        public MenuSystem MenuSystem;
    }
}