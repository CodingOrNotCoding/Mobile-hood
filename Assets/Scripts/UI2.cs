using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI2 : MonoBehaviour
{
    //public GameObject audioSource;
    //bool soundToggle = true;
    GameObject[] GOlist;
    public Text moneybag;
    void Start()
    {



    }
    
    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        moneybag.text = ("Money: " + GameManager.bagCount + "/" + GameManager.maxBags);

        /*if (GameManager.bag_count > GameManager.max_bags)
            GameManager.bag_count = GameManager.max_bags;

        if (GameManager.bag_count < 0)
            GameManager.bag_count = 0;*/

    }

    public void DestroyAll()
    {
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
