using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace EisvilTest
{
    public class EntryPoint
    {
        private SystemPrefabs _systemPrefabs;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void StartGame()
        {
            ConfigureSettings();

            EntryPoint instance = new();
            instance.LoadAssets();
        }

        private static void ConfigureSettings()
        {
            Application.targetFrameRate = Global.TARGET_FRAME_RATE;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void LoadAssets()
        {
            SceneManager.LoadScene(Global.GAME_SCENE);
            Addressables.LoadAssetAsync<SystemPrefabs>(Global.SYSTEM_PREFABS_ADDRESS).Completed += OnCompleted;
        }

        private void OnCompleted(AsyncOperationHandle<SystemPrefabs> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _systemPrefabs = handle.Result;
                InitializeSystems();
            }
            else
            {
                Debug.LogError("Failed to load SystemPrefabs.");
            }
        }

        private void InitializeSystems()
        {
            InputSystem inputSystem = Object.Instantiate(_systemPrefabs.InputSystem);
            LevelSystem levelSystem = Object.Instantiate(_systemPrefabs.LevelSystem);
            MenuSystem menuSystem = Object.Instantiate(_systemPrefabs.MenuSystem);

            inputSystem.Initialize();
            levelSystem.Initialize();
            menuSystem.Initialize();
        }
    }
}