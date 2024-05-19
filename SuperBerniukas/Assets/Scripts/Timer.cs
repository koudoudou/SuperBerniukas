using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject panel;
    int i;
    private void Awake()
    {
         i = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 14 && SceneManager.GetActiveScene().buildIndex != 10 && SceneManager.GetActiveScene().buildIndex != 11 && SceneManager.GetActiveScene().buildIndex != 12 && SceneManager.GetActiveScene().buildIndex != 13)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (remainingTime < 1 && i ==0)
        {
            SceneManager.LoadScene(12);
            panel.SetActive(false);
            i = 1;
        }
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            panel.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            panel.SetActive(true);
        }
        if(SceneManager.GetActiveScene().buildIndex == 13)
        {
            panel.SetActive(false);
        }
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            panel.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            panel.SetActive(false);
        }
    }
}
