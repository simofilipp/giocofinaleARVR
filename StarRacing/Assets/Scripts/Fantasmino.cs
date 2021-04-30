using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmino : MonoBehaviour
{
    [Header("Opzioni nemico")]
    [SerializeField] public string nomeMacchina;
    [SerializeField] public float speed;


    public bool visto;
    public GameObject macchina;
    public GameManager gm;
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
            macchina.GetComponent<NewCarController>().life -= 15;
            Debug.Log("Danno");
            visto = false;
        }
        if (collision.gameObject.name == "ColpoCannone")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(10,20,10)*10, ForceMode.Impulse);
            gm.AccendiImageKill();
            gm.RimuoviAlieno(this.gameObject);
            Destroy(this.gameObject, 2);
        }
    }
}
