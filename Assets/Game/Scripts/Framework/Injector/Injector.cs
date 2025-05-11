using System;
using System.Collections.Generic;
using UnityEngine;

namespace EisvilTest.Framework
{
    public static class Injector
    {
        private static readonly Dictionary<Type, object> _entities = new();

        public static bool Bind<T>(T value) where T : class
        {
            var type = typeof(T);

            if (!_entities.ContainsKey(type))
            {
                _entities[type] = value;

                return true;
            }
            else
            {
                Debug.LogWarning($"[Injector]: The bindable object of type {type} already exists.");

                return false;
            }
        }

        public static void Unbind<T>(T value) where T : class
        {
            var type = typeof(T);

            _entities.Remove(type);
        }

        public static T Get<T>() where T : class
        {
            var type = typeof(T);

            if (_entities.TryGetValue(type, out var @object))
            {
                return (T)@object;
            }
            else
            {
                Debug.LogError($"[Injector]: Could not find bindable object of type {type}.");

                return null;
            }
        }
    }
}