using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 2.5f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text aiScore;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject game;
    [SerializeField] private Text end;

    AudioManager audioManager;

    private int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);

    }
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1,0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }
    
    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPoz = transform.position;
        Vector2 playerPoz = myObject.position;

        float xDirection, yDirection;

        if(transform.position.x >0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPoz.y - playerPoz.y) / myObject.GetComponent<Collider2D>().bounds.size.y;

        if(yDirection ==0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
            audioManager.PlaySFX(audioManager.ballPress);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x > 0)
        {
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        else if(transform.position.x < 0)
        {
            ResetBall();
            aiScore.text = (int.Parse(aiScore.text) + 1).ToString();
        }
    }
    private void Update()
    {
        if(playerScore.text == "5")
        {
            game.SetActive(false);
            end.text = "Jūs laimėjote prieš Andrių ir jūsų laimė pakilo";
            endScreen.SetActive(true);
            aiScore.text = "0";
            playerScore.text = "0";
            StatManager.Instance.Play(15);

        }
        else if (aiScore.text == "5")
        {
            game.SetActive(false);
            end.text = "Jūs pralaimėjote prieš Andrių ir nuliūdote";
            endScreen.SetActive(true);
            aiScore.text = "0";
            playerScore.text = "0";
            StatManager.Instance.Play(-15);
        }
    }

    public void Startg()
    {
        Invoke("StartBall", 2f);
    }
}
