using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveCharacterCanvas : MonoBehaviour
{
    public static SaveCharacterCanvas instance;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Check if the current scene is not Scene 0
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            // Don't destroy this object when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If the current scene is Scene 0, destroy this object
            Destroy(gameObject);
        }

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

    // This method is called when a new scene is loaded
    void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is called when this script is disabled
    void OnDisable()
    {
        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method is called when a scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the loaded scene is Scene 0, destroy this object
        if (scene.buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }
}
