using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadCharacter : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector3 newPosition = new Vector3(-2f, -1.5f, 0f);
    public Vector3 newScale = new Vector3(0.4f, 0.4f, 0.4f);
    // Start is called before the first frame update
    void Start()
    {
        
        //if (PlayerPrefs.GetInt("ch") == 0)
        //{
        //    int selectedCharacter = PlayerPrefs.GetInt("characterNR");

        //    GameObject pr = prefabs[selectedCharacter];
        //    GameObject newPrefabInstance = Instantiate(pr);
        //    newPrefabInstance.transform.position = newPosition;
        //    newPrefabInstance.transform.localScale = newScale;
        //    newPrefabInstance.tag = "Player";
        //}
        //else
        //{
           
            GameObject newPrefabInstance = Instantiate(Resources.Load("Prefabs/Character", typeof(GameObject))) as GameObject;
            DeactivateChildrenRecursive(newPrefabInstance.transform.Find("Top"));
            DeactivateChildrenRecursive(newPrefabInstance.transform.Find("Body"));
            DeactivateChildrenRecursive(newPrefabInstance.transform.Find("Bottom"));
            DeactivateChildrenRecursive(newPrefabInstance.transform.Find("Shoes"));

            string body = PlayerPrefs.GetString("body");
            string top = PlayerPrefs.GetString("top");
            string bottom = PlayerPrefs.GetString("bottom");
            string shoes = PlayerPrefs.GetString("shoes");
            ActivateChildrenRecursive(newPrefabInstance.transform.Find("Body"), body);
            ActivateChildrenRecursive(newPrefabInstance.transform.Find("Top"), top);
            ActivateChildrenRecursive(newPrefabInstance.transform.Find("Bottom"), bottom);
            ActivateChildrenRecursive(newPrefabInstance.transform.Find("Shoes"), shoes);

            newPrefabInstance.transform.position = newPosition;
            newPrefabInstance.transform.localScale = newScale;
            newPrefabInstance.tag = "Player";
        //}    
    }
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
    void ActivateChildrenRecursive(Transform parent, string top)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name == top)
                child.gameObject.SetActive(true);
        }
    }
}
