using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirinoScript : MonoBehaviour
{
    public GameObject cannone;
    public GameObject proiettile;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cannone.transform.LookAt(transform.position);
       //transform.position = cannone.transform.position + new Vector3(40, 0, 15);
            transform.localPosition += new Vector3(
                Input.GetAxisRaw("Mouse X") + Time.deltaTime * speed,
                Input.GetAxisRaw("Mouse Y") + Time.deltaTime * speed,
                0.0f
                );
        if (Input.GetMouseButtonDown(0))
        {
            GameObject colpo = Instantiate(proiettile, cannone.transform.position, cannone.transform.rotation);
            colpo.name = "ColpoCannone";
            colpo.GetComponent<Rigidbody>().velocity = (cannone.transform.forward * 1000);
            Destroy(colpo, 1);
        }
    }

}
