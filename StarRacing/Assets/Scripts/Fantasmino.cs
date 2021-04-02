using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmino : MonoBehaviour
{
    [Header("Opzioni nemico")]
    [SerializeField] public string nomeMacchina;
    [SerializeField] public float speed;


    bool visto;
    Vector3 posizioneIniziale;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(nomeMacchina);
        posizioneIniziale = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (visto)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(nomeMacchina).transform.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, posizioneIniziale, step);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nomeMacchina)
        {
            Debug.Log("Visto");
            visto = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == nomeMacchina)
        {
            Debug.Log("Non Visto");
            visto = false;
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == nomeMacchina)
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("Danno");
            visto = false;
        }
    }
}
