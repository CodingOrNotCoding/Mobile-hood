using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIscript : MonoBehaviour
{
    //public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioSource endSource;

    GameObject[] GOlist;
    public Text moneybag;
    public Text scoreText;
    public Text helpedFakirs;
    public bool timerOn = false;
    public GameObject GameOver;
    public GameObject PlayCanvas;
    void Start()
    {
      
    }
    void Update()
    {
        //print(timerOn);
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;


        if (timerOn)
        {
            moneybag.text = ("Money: " + GameManager.bagCount + "/" + GameManager.maxBags + "  Score: " + GameManager.score.ToString() + "  Helped: " + GameManager.bagsDelivered.ToString() + "  Time :" + ((int)GameManager.timer).ToString());

            if (GameManager.timer <= 0)
            {
                endSource.Play();
                audioSource.Stop();
                scoreText.text = ("Your score: " + GameManager.score.ToString());
                helpedFakirs.text = ("You have helped " + GameManager.bagsDelivered.ToString() + " fakirs");

                GameManager.timer = 0;
                //PlayCanvas.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(true);
                PauseGame(true);
                timerOn = false;

                moneybag.text = "";


            }
          
        }
        
    }

    public void DestroyAll()
    {
        audioSource.Play();
        Debug.Log("hello world");
        Time.timeScale = 1;

        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Cars");
        foreach (GameObject GO in GOs)
            GameObject.Destroy(GO);

        GOs = GameObject.FindGameObjectsWithTag("Fakir");
        foreach (GameObject GO in GOs)
            GameObject.Destroy(GO);

        GameManager.resetStats();

    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }
    public void setTimer(bool a)
    {
        if (a) timerOn = true;
        else timerOn = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    float deltaTime = 0.0f;

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
