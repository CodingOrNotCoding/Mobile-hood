using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public enum stateList
    {
        spin, throwingHook, throwingGold, pullback, pullbackWithGold, pullbackWithoutGold
    }

    public static stateList activeState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
