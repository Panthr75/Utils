using UnityEngine;
using System;

public class UnitySingleton<T> : MonoBehaviour
{
    internal static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Type TType = typeof(T);

                GameObject obj = new GameObject(TType.Name);
                obj.SetActive(false);

                obj.AddComponent(TType);

                _instance = (T)Convert.ChangeType(obj.GetComponent(TType), TType);

                DontDestroyOnLoad(obj);
                obj.SetActive(true);
            }

            return _instance;
        }
    }
}
