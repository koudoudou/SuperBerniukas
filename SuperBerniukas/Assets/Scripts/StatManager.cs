using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    float hunger = 100;
    Slider hungerSlider;
    float happiness = 100;
    Slider happinessSlider;
    float clean = 100;
    Slider cleanSlider;
    float wc = 100;
    Slider WCSlider;
    double money;
    double IQ;

    public static StatManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Object hungerObj = GameObject.FindWithTag("hunger");
        hungerSlider = hungerObj.GetComponent<Slider>();

        Object happyObj = GameObject.FindWithTag("happy");
        happinessSlider = happyObj.GetComponent<Slider>();

        Object cleanObj = GameObject.FindWithTag("clean");
        cleanSlider = cleanObj.GetComponent<Slider>();

        Object wcObj = GameObject.FindWithTag("wc");
        WCSlider = wcObj.GetComponent<Slider>();

        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        float i;
        hungerSlider.value = hunger;
        happinessSlider.value = happiness;
        cleanSlider.value = clean;
        WCSlider.value = wc;

        if(hunger >0)
            hunger -= 0.6f * Time.deltaTime;
        if(hunger > 100)
        {
            i = hunger - 100;
            hunger -= i;
        }

        if (happiness > 0)
            happiness -= 0.7f * Time.deltaTime;
        if (happiness > 100)
        {
            i = happiness - 100;
            happiness -= i;
        }

        if (clean > 0)
            clean -= 0.5f * Time.deltaTime;

        if (wc > 0)
            wc -= 0.4f * Time.deltaTime;

        if (hunger <= 0 || happiness <=0 || clean <=0 || wc <=0)
        {
            SceneManager.LoadScene(10);
        }
    }

     public void Eat(float amount)
    {
        
        hunger += amount;
        wc -= amount * 0.5f;
    }

     public void Drink(float amount)
    {
        hunger += amount;
       
        wc -= amount * 2;
    }
    public void WC()
    {
        wc = 100;
    }
    public void Shower()
    {
        clean = 100;
    }

    public void Exercise()
    {
        happiness += 15;
        clean -= 10;
        hunger -= 5;
    }

    public void Play(float amount)
    {
        happiness += amount;
        clean -= 5;
        hunger -= 10;
    }
}
