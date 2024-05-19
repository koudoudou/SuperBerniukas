using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefab : MonoBehaviour
{
    public static SavePrefab instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
