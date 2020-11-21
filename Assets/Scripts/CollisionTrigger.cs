using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollisionTrigger : MonoBehaviour
{

    public Transform hookLocater;
    public GameObject hookObject;

    public AudioSource audioSourceCash;
    public AudioSource audioSourceHelp;

    public GameObject moneyBagObject;

    GameObject childObject;

    GameObject caughtObject;
    bool isCaught = false;


   

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name);
        if (other.tag.Equals("Moneybag") && !HookRotate.activeState.ToString().Equals("spin"))
        {
            moneyBagObject.SetActive(true);
            Destroy(other.gameObject);
            GameManager.addBag();
            audioSourceCash.Play();
        }

        if (other.tag.Equals("Fakir") && !HookRotate.activeState.ToString().Equals("spin") && GameManager.bagCount > 0 )
        {
            if (!other.gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                GameManager.deliverBag();
                audioSourceHelp.Play();
            }
            
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }


        if (other.tag.Equals("Obstacle"))
        {
            HookRotate.setActiveState(3);

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hookObject.transform.position = hookLocater.position;
    }
}
