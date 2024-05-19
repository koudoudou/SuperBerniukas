using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSFX : MonoBehaviour
{
    public static ButtonPressSFX Instance;
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void PressButton()
    {
        audioManager.PlaySFX(audioManager.buttonPress);
    }

    public void DoorButton()
    {
        audioManager.PlaySFX(audioManager.doorPress);
    }

    public void FridgeButton()
    {
        audioManager.PlaySFX(audioManager.fridgePress);
    }

    public void DrinkButton()
    {
        audioManager.PlaySFX(audioManager.drinkPress);
    }

    public void EatButton()
    {
        audioManager.PlaySFX(audioManager.eatPress);
    }

    public void StairsButton()
    {
        audioManager.PlaySFX(audioManager.stairsPress);
    }

    public void ToiletButton()
    {
        audioManager.PlaySFX(audioManager.toiletPress);
    }

    public void PunchButton()
    {
        audioManager.PlaySFX(audioManager.punchPress);
    }

    public void BallBounceSFX()
    {
        audioManager.PlaySFX(audioManager.ballPress);
    }

    public void WardrobeBUtton()
    {
        audioManager.PlaySFX(audioManager.wardrobePress);
    }

    public void CardFlip()
    {
        audioManager.PlaySFX(audioManager.cardFLip);
    }

    public void MatchEd()
    {
        audioManager.PlaySFX(audioManager.matchSound);
    }
}
