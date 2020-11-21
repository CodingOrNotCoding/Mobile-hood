using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_cart : MonoBehaviour
{
  
    public GameObject cartPrefab;
    public GameObject fakirPrefab;

    public GameObject Roads;

    public bool bothDirections = true;

    public float fakirProbability = 0.5f;

    Vector3 inst_pos;

    List<Vector3> roadPositions = new List<Vector3>();

    void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            roadPositions.Add(Roads.transform.GetChild(i).transform.position);
            //print(roadPositions[i]);
        }
   
        InvokeRepeating("Inst_cart", 1.0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Inst_cart()
    {
        int startRoad = GetRandomRoad();
        inst_pos = roadPositions[startRoad];

        int destination = 0;

        Quaternion InstQuat = Quaternion.Euler(new Vector3(0, -90, 0));

        switch (startRoad)
        {
            case 0: destination = 1; InstQuat = Quaternion.Euler(new Vector3(0, -90, 0));  break;
            case 1: destination = 0; InstQuat = Quaternion.Euler(new Vector3(0, +90, 0));  break;
            case 2: destination = 3; InstQuat = Quaternion.Euler(new Vector3(0, -90, 0));  break;
            case 3: destination = 2; InstQuat = Quaternion.Euler(new Vector3(0, +90, 0));  break;
            case 4: destination = 5; InstQuat = Quaternion.Euler(new Vector3(0, -90, 0));  break;
            case 5: destination = 4; InstQuat = Quaternion.Euler(new Vector3(0, +90, 0));  break;
            case 6: destination = 7; InstQuat = Quaternion.Euler(new Vector3(0, -90, 0));  break;
            case 7: destination = 6; InstQuat = Quaternion.Euler(new Vector3(0, +90, 0));  break;
        }

        GameObject cartObject;

        if (Random.Range(0.0f, 1.0f) < fakirProbability)
            cartObject = Instantiate(fakirPrefab, inst_pos, InstQuat);
        else 
            cartObject = Instantiate(cartPrefab, inst_pos, InstQuat);
        
        cartObject.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = roadPositions[destination];
        //cartObject.GetComponent<NavMeshMovement>().RoadID = randomRoad;

    }


    int GetRandomRoad()
    {
        if (bothDirections)
        {
            return Random.Range(0, 8);
        }
        else
        {
            switch (Random.Range(0, 4))
            {
                case 0: return 0;
                case 1: return 3;
                case 2: return 4;
                case 3: return 7;
            }
        }

        return 0;
    }

}


