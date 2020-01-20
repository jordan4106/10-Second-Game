using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public Text LoseText;
    public Text TimerText;
    public AudioSource LoseAudio;
    public AudioSource GameAudio;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        LoseText.text = "You Lose! Game Created by Jordan Marr!";
        Destroy(TimerText);
        GameAudio.Stop();
        LoseAudio.Play();
    }
}
