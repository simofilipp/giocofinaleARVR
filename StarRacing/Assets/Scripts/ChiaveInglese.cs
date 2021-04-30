using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiaveInglese : MonoBehaviour
{
    [SerializeField] float lifeQuantity;

    GameManager gm;
    NewCarController macchina;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        macchina= GameObject.Find("CarParent").GetComponent<NewCarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Car")
        {
            macchina.life += lifeQuantity;
            gm.RimuoviChiave(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
