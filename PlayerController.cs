using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int score;
    private int lives;
    private int pickups;

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        pickups = 12;
        lives = 3;
        winText.text = "";
        livesText.text = "Lives: 3";
        SetCountText ();
        SetLivesText();

    }

    void FixedUpdate()
        {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            pickups = pickups - 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("BadPickUp"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            lives = lives - 1;
            SetCountText();
            SetLivesText();
        }
    }

    void SetCountText ()
    {
        scoreText.text = "Score: " + score.ToString();

        if (pickups <= 0)
        {
            SceneManager.LoadScene("Level2");
        }


            if (count >= 12)
        {
            winText.text = "SUGOI!!! YOU WON!! :3 uwu Game made by Kevin Le";
        }
    }


    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            winText.text = "Awww D: You lose T-T ;-;";
        }

    }


}