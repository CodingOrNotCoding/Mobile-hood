using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_script2 : MonoBehaviour
{
    // Start is called before the first frame update

    new Vector3 pos_vector;
    bool left = true;
    public float moveSpeed = 10f;

    void Start()
    {
        if (transform.position.x > 0) left = false;
        pos_vector = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (left) pos_vector.x += moveSpeed * Time.deltaTime;
        else pos_vector.x -= moveSpeed * Time.deltaTime;

        transform.position = pos_vector;

        if (transform.position.x > 11f || transform.position.x < -11f) Destroy(gameObject);
    }
}
