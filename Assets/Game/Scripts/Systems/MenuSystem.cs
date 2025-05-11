using System;
using System.Collections.Generic;
using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class MenuSystem : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform _canvasTransform;

        [Header("Prefabs")]
        [SerializeField] private MainMenuView _mainMenuViewPrefab;
        [SerializeField] private GameplayMenuView _gameplayMenuViewPrefab;

        private MenuStateMachine _menuStateMachine;

        private Dictionary<Type, MenuView> _menuViewPrefabs;
        private Dictionary<Type, MenuView> _menuViews;

        public void Initialize()
        {
            Injector.Bind(this);

            _menuViewPrefabs = new Dictionary<Type, MenuView>
            {
                { typeof(MainMenuView), _mainMenuViewPrefab },
                { typeof(GameplayMenuView), _gameplayMenuViewPrefab }
            };

            _menuViews = new Dictionary<Type, MenuView>();

            _menuStateMachine = new MenuStateMachine();
            _menuStateMachine.SetState(_menuStateMachine.MainMenuState);
        }

        public void CreateMenu<T>() where T : MenuView
        {
            Type type = typeof(T);

            if (_menuViewPrefabs.TryGetValue(type, out MenuView menuViewPrefab))
            {
                MenuView menuView = Instantiate(menuViewPrefab);
                menuView.Initialize(_canvasTransform);
                menuView.Enable();

                _menuViews.Add(type, menuView);
            }
            else
            {
                Debug.LogWarning($"[MenuSystem]: Could not find menu of type {type}.");
            }
        }

        public void DestroyMenu<T>() where T : MenuView
        {
            Type type = typeof(T);

            if (_menuViews.TryGetValue(type, out MenuView menuView))
            {
                menuView.Disable();
                menuView.Destroy();

                _menuViews.Remove(type);
            }
            else
            {
                Debug.LogWarning($"[MenuSystem]: Could not find menu of type {type}.");
            }
        }
    }
}