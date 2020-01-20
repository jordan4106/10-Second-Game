using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float timeLeft = 12.0f;

    public bool isGrounded = false;
    private bool win = true;
    
    
    public Text winText;
    public Text TimerText; // used for showing countdown from 3, 2, 1 
    public Text LoseText;
    public Text StartText;
    public Text RestartText;

    public AudioSource LoseAudio;
    public AudioSource WinAudio;
    public AudioSource GameAudio;
    public AudioSource JumpAudio;
    public AudioSource IntroAudio;
    
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        timeLeft -= Time.deltaTime;
        TimerText.text = (timeLeft).ToString("0");
        

        if (timeLeft < 10)
        {
            Destroy(StartText);

        }

        if (timeLeft == 10)
        {
            IntroAudio.Stop();
            GameAudio.Play();
        }

        if (timeLeft < 0)
        {
            Destroy(gameObject);
            LoseText.text = "You Lose! Game Created by Jordan Marr!";
            

            GameAudio.Stop();
            LoseAudio.Play();
        }

        if (!win)
        {
            timeLeft += Time.deltaTime; //time pauses if bool is won
        }

        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            JumpAudio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Destroy(TimerText);
            winText.text = "You Win! Game Created by Jordan Marr!";
            GameAudio.Stop();
            WinAudio.Play();
            win = false;
        }
    }

}
