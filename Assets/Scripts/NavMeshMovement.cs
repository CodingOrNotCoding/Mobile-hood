using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshMovement : MonoBehaviour
{
  
    UnityEngine.AI.NavMeshAgent agent;

    //public int RoadID;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //agent.destination = new Vector3(-52f, 0f, 0f);
        //agent.updateRotation = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(agent.hasPath)
        if (agent.remainingDistance < 1f) Destroy(gameObject);
    }

}
