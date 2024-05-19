using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startcl : MonoBehaviour
{
    public static void startTo(string name)
    {
        PlayerPrefs.SetString("top", name);

    }

    public static void startBo(string name)
    {

        PlayerPrefs.SetString("bottom", name);

    }

    public static void startSh(string name)
    {

        PlayerPrefs.SetString("shoes", name);
    }
}
