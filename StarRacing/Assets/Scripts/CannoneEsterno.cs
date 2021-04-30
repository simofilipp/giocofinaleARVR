using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoneEsterno : MonoBehaviour
{
    public GameObject palla;
    public GameObject car;
    public Transform mirino;
    public GameObject parent;

    [Header("Opzioni palla di cannone")]
    [SerializeField] public float speed;
    [SerializeField] public float rateOfFire;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mirino.transform.LookAt(car.transform.position);
        parent.transform.LookAt(car.transform.position);
    }

    public void Spara()
    {
        GameObject colpo = Instantiate(palla, mirino.transform.position, mirino.transform.rotation);
        colpo.GetComponent<Rigidbody>().velocity = (mirino.transform.forward * speed);
        Destroy(colpo, 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            InvokeRepeating("Spara", 0.5f, rateOfFire);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            CancelInvoke("Spara");

        }

    }
}
