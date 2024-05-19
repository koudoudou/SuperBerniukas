using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacterProfile : MonoBehaviour
{
    public GameObject[] portraits;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("characterNR");
        portraits[selectedCharacter].SetActive(true);


    }

    private void Update()
    {
        int selectedCharacter = PlayerPrefs.GetInt("characterNR");
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 9 || SceneManager.GetActiveScene().buildIndex == 11 || SceneManager.GetActiveScene().buildIndex == 10 || SceneManager.GetActiveScene().buildIndex == 12 || SceneManager.GetActiveScene().buildIndex == 13)
        {
            portraits[selectedCharacter].SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            portraits[selectedCharacter].SetActive(true);
        }
    }

}
