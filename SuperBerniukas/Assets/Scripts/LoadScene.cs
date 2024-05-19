using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int index;


    public void ChangeScene()
    {
        SceneManager.LoadScene(index);

    }

}