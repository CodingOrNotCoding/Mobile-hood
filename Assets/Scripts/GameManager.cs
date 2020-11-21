using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static int bagCount=0;
    public static int maxBags = 10;
    public static int score = 0;
    public static float timer = 60;
    public static int scoreMultiplier = 10;
    public static int bagsDelivered = 0;
    public static int timerIncrement = 10;

    public int bagCount1 = 0;
    public int maxBags1 = 10;
    public int score1 = 0;
    public float timer1 = 60;
    public int scoreMultiplier1 = 10;
    public int bagsDelivered1 = 0;
    public int timerIncrement1 = 10;



    // Start is called before the first frame update
    public static void resetStats()
    {
        bagCount = 0;
        score = 0;
        timer = 60;
        bagsDelivered = 0;
    }

    public static void addBag()
    {
        if (bagCount < maxBags)
        {
            bagCount++;
        }
    }

    public static void removeBag()
    {
        if(bagCount > 0)
        {
            bagCount--;
        }
    }

    public static void deliverBag()
    {
        if (bagCount > 0)
        {
            bagsDelivered++;
            bagCount--;
            score += scoreMultiplier;
            timer += timerIncrement;
        }

    }


    void Awake()
    {
        Application.targetFrameRate = 30;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        bagCount1 = bagCount;
        maxBags1 = maxBags;
        score1 = score;
        timer1 = timer;
        scoreMultiplier1 = scoreMultiplier;
        bagsDelivered1 = bagsDelivered;
        timerIncrement1 = timerIncrement;
}
}
