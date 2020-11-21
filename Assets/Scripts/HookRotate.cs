using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class HookRotate : MonoBehaviour
{
    public AudioSource audioSource;

    public Transform center;
    public Transform hook;

    public GameObject moneyBagObject;

    public static bool hasCoin = false;
    public float timer = 0.0f;
    private float hookDelay = 0.0f;

    private bool canThrow = true;

    public enum stateList
    {
        spin, throwingHook, pullback
    }

    public static void setActiveState(int i){
        switch(i)
        {
            case 1:
                activeState = stateList.spin;
                break;
            case 2:
                activeState = stateList.throwingHook;
                break;
            case 3:
                activeState = stateList.pullback;
                break;
        }

    }
    

    public static stateList activeState;



    private Vector3 axis = new Vector3(0f, 1f, 0f);
    public float rotateSpeed = 5f;
    public float throwSpeed = 0.2f;
    public float pullBackSpeed = 0.2f;

    //public float hookMaxScale = 4.5f;

    private float hookInitialScale = 0.8f;
    public bool isThrown, pullBack = false;
    public int state;

    // Start is called before the first frame update
    void Start()
    {
        activeState = stateList.spin;
    }



    private void defineState()
    {
        if ( Input.GetMouseButton(0) && activeState == stateList.spin && timer == 0 && canThrow)
        {
            activeState = stateList.throwingHook;
            audioSource.Play();
            canThrow = false;
        }

        if (!Input.GetMouseButton(0) && activeState == stateList.throwingHook)
        {
            activeState = stateList.pullback;
            Debug.Log("Pullback");
         
        }

        /*else if (activeState == stateList.throwingHook && center.localScale.y >= hookMaxScale)
        {
            activeState = stateList.pullback;
        }*/

        else if (activeState == stateList.pullback && center.localScale.y <= hookInitialScale)
        {
            activeState = stateList.spin;
            timer = hookDelay;
            moneyBagObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        defineState();
        if (activeState == stateList.spin) {
            center.RotateAround(center.position, axis, -rotateSpeed);
            if (hasCoin)
            {
                hasCoin = false;
            }
        }

        if(activeState == stateList.throwingHook)
        {
            center.localScale = new Vector3(center.localScale.x, center.localScale.y + throwSpeed, center.localScale.z);
        }

        if(activeState == stateList.pullback)
        {

            center.localScale = new Vector3(center.localScale.x, center.localScale.y - pullBackSpeed, center.localScale.z);
            
        }

        if(!canThrow && Input.GetMouseButtonUp(0))
        {
            canThrow = true;
        }
    }
    void Update()
    {
        /*if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            timer = 0;
        }*/
    }


}
