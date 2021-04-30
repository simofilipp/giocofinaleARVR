using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienoTrapper : MonoBehaviour
{
     GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ColpoCannone")
        {
            gm.RimuoviAlienoTrapper(this.gameObject);
            gm.AccendiImageKill();
            Destroy(this.gameObject, 0);
        }
    }
}
