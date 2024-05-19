using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class ChangeClothes : MonoBehaviour
{
    public Sprite[] tops;
    public Sprite[] pants;
    public Sprite[] shoes;
    
    public void ChangeTop(int number)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject top = player.transform.Find("Top").gameObject;
        DeactivateChildrenRecursive(player.transform.Find("Top"));
        SpriteRenderer photoRenderer = top.GetComponent<SpriteRenderer>();
        photoRenderer.sprite = tops[number];
        PlayerPrefs.SetString("top", tops[number].name);
    }
    public void ChangeBottom(int number)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject bottom = player.transform.Find("Bottom").gameObject;
        DeactivateChildrenRecursive(player.transform.Find("Bottom"));
        SpriteRenderer photoRenderer = bottom.GetComponent<SpriteRenderer>();
        photoRenderer.sprite = pants[number];
        PlayerPrefs.SetString("bottom", pants[number].name);
    }

    public void ChangeBoots(int number)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject boots = player.transform.Find("Shoes").gameObject;
        DeactivateChildrenRecursive(player.transform.Find("Shoes"));
        SpriteRenderer photoRenderer = boots.GetComponent<SpriteRenderer>();
        photoRenderer.sprite = shoes[number];
        PlayerPrefs.SetString("shoes", shoes[number].name);
    }

    //public void SaveClothes()
    //{

    //    PlayerPrefs.SetInt("ch",1);
    //}

    void DeactivateChildrenRecursive(Transform parent)
    {
        // Loop through each child of the parent transform
        foreach (Transform child in parent)
        {
            // Deactivate the child GameObject
            child.gameObject.SetActive(false);

            // Recursively deactivate children of this child
            DeactivateChildrenRecursive(child);
        }
    }


}
