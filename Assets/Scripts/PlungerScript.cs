using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform hookLocater;
    public Transform hookRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hookLocater.position;
        transform.rotation = hookRotation.rotation;
    }
}
