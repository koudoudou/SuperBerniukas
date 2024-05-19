using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    public GameObject panel;
    
    public void ChangePanel()
    {
        if(panel != null && (panel.activeSelf == false))
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
