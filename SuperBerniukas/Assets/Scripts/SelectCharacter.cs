using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public int characterNR = 0;
    public string body = "";

    public void SetCharacter(int characterNR)
    {
        PlayerPrefs.SetInt("characterNR", characterNR);

    }

    public void SetBody(string body)
    {
        PlayerPrefs.SetString("body", body);
    }
}
