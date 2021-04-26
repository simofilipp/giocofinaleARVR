using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiaveInglese : MonoBehaviour
{
    [SerializeField] float lifeQuantity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            other.gameObject.GetComponent<NewCarController>().life += lifeQuantity;
        }
    }
}
