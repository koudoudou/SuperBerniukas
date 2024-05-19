using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;
    AudioManager audioManager;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    public Text atspejimai;

    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject game;

    private bool firstGuess, secondGuess;

    private int countGuesses, gameGuesses;
    private int countCorrectGuesses = 0;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private void Update()
    {
        if (countCorrectGuesses == 20)
        {
            game.SetActive(false);
            endScreen.SetActive(true);
        }
    }
    private void Awake()
    {

            puzzles = Resources.LoadAll<Sprite>("Images");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;

    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("puzzleBtn");

        for (int i=0; i< objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i< looper; i++)
        {
            if(index == looper/2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickPuzzle());
            btn.onClick.AddListener(() => CardFlip());
        }
    }
    public void CardFlip()
    {
        audioManager.PlaySFX(audioManager.cardFLip);
    }
    public void CardMatch()
    {
        audioManager.PlaySFX(audioManager.matchSound);
    }
    public void PickPuzzle()
    {

        
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
           
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            if(firstGuessPuzzle == secondGuessPuzzle)
            {
                print("Puzzle Match");
                countCorrectGuesses++;
                countGuesses++;
                atspejimai.text = countGuesses.ToString();
                CardMatch();
            }
            else
            {
                print("Puzzle dont match");
                countGuesses++;
                atspejimai.text = countGuesses.ToString();
            }

            StartCoroutine(checkThePuzzleMatch());
        }

    }

    IEnumerator checkThePuzzleMatch()
    {
        yield return new WaitForSeconds(0.4f);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.4f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckTheGameFinished();
        }else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(0.4f);

        firstGuess = secondGuess = false;
    }

    void CheckTheGameFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            print("game finish");
            print("It took you " + countGuesses);
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i=0; i< list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
