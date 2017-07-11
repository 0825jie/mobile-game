using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    public Game game;
    public Text timerText;
    public Text finalText;
    private float startTime;
    private bool finished;
    public string lastTime;
    private float t;
    private int count;
    private string minute;
    private string second;
    public static string finalScore;
    public static string cong;
    public AudioSource deathMusic;
    public AudioSource backMusic;
    public AudioSource shootMusic;
    // Use this for initialization
    void Start()
    {
        finished = false;
        startTime = Time.time;
        count = 1;
        finalText.text = null;

    }

    // Update is called once per frame
    void Update()
    {
        t = Time.time - startTime;
        int a = (int)t / 60;
        minute = (a).ToString();
        float b = t % 60;
        second = (t % 60).ToString("f2");
       

        if (game.player.health <= 0 && count == 1)
        {
            backMusic.Stop();
            shootMusic.volume = 0;
            deathMusic.Play();
            deathMusic.Play();

            count++;
            finished = true;
            timerText.text = null;
            finalText.text = "Trojan Game Over !";
            int temp = (int)(a * 60 + b);
            Debug.Log("this is cur time" + temp);
            if (temp > 65)
            {
                Debug.Log(PlayerPrefs.GetInt("final") + "DDDDDDDDDD");
                finalScore = lastTime;
                cong = "Rank 6!";
                Debug.Log("set new 000000000");
            }
            else
            {
                finalScore = lastTime;
                cong = "Rank 17!";
            }
            return;

        }

        if (!finished)
            keepChanging();

    }

    void keepChanging()
    {
        timerText.text = minute + ":" + second;
        lastTime = minute + ":" + second;
    }

}