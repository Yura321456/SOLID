// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using UnityEngine;


public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;

    private static object _instanceLock = new object();
    public static T instance
    {
        get
        {
            lock (_instanceLock)
            {
                if (Application.isPlaying == false)
                    throw new Exception("Game is Closed");

                if (_instance)
                {
                    return _instance;
                }

                T[] instances = FindObjectsOfType<T>();

                if (instances.Length > 0)
                {
                    _instance = instances[0];

                    for (int i = 1; i < instances.Length; i++)
                    {
                        Destroy(instances[i].gameObject);
                    }
                }
                else
                {
                    var gameObject = new GameObject();
                    _instance = gameObject.AddComponent<T>();

                    _instance.name = _instance.GetType().Name;
                }

                return _instance;
            }
        }
    }
}
