using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienoCuoreScript : MonoBehaviour
{
    public Transform car;
    public float distance = 3.0f;
    public float high;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //transform.LookAt(car);
        //Vector3 diff = transform.position + car.position;
        //diff.y = high;
        //transform.position = car.position + diff.normalized * distance;
        //if (transform.position.z < car.position.z+30)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, car.position.z + 30);
        //}

    }

}
