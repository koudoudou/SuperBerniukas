using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip  --------")]
    public AudioClip background;
    public AudioClip buttonPress;
    public AudioClip doorPress;
    public AudioClip fridgePress;
    public AudioClip drinkPress;
    public AudioClip eatPress;
    public AudioClip stairsPress;
    public AudioClip toiletPress;
    public AudioClip punchPress;
    public AudioClip ballPress;
    public AudioClip wardrobePress;
    public AudioClip cardFLip;
    public AudioClip matchSound;

    public static AudioManager instance;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();        
    }

    private void Update()
    {

    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
