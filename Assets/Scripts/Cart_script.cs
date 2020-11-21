using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_script : MonoBehaviour
{
    // Start is called before the first frame update

    new Vector3 pos_vector;
    bool left = true;
    void Start()
    {
        if (transform.position.x > 0) left = false;
        pos_vector = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (left) pos_vector.x += 0.1f;
        else pos_vector.x -= 0.1f;

        transform.position = pos_vector;

        if (transform.position.x > 11f || transform.position.x < -11f) Destroy(gameObject);
    }
}
