using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SferaUfoMadre : MonoBehaviour
{
    UfoMadre um;
    // Start is called before the first frame update
    void Start()
    {
        um = GetComponentInParent<UfoMadre>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ColpoCannone")
        {
            um.RimuoviSfera(this.gameObject);
            Destroy(this.gameObject, 0);   
        }
    }
}
