using System;
using UnityEngine;




/// <summary>
/// Singleton mono alway exist through all screnes. 
/// </summary>
public class SingletonBahaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static bool IsInstanceInvalid()
    {
        return instance != null;
    }

    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<T>();

            if (instance != null)
                return instance;

            Debug.LogError($"Not found Object for type {typeof(T).Name}");
            return instance;
        }


    } // Instance

}// SingletonBahaviour
