using UnityEngine;

public abstract class Singleton<T> where T : new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}


/// <summary>
/// Singleton mono alway exist through all screnes. 
/// </summary>
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
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

}// SingletonMono