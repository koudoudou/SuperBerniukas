using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StatChange : MonoBehaviour
{

    public void Eat(float amount)
    {
        StatManager.Instance.Eat(amount);
    }
    public void Drink(float amount)
    {
        StatManager.Instance.Drink(amount);
    }
    public void WC()
    {
        StatManager.Instance.WC();
    }

    public void Clean()
    {
        StatManager.Instance.Shower();
    }

    public void Gym()
    {
        StatManager.Instance.Exercise();
    }

    public void LivingRoom(float amount)
    {
        StatManager.Instance.Play(amount);
    }
}
