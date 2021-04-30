using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienoCuoreScript : MonoBehaviour
{

    public GameObject palla;
    public GameObject car;
    public Transform mirino1;
    public Transform mirino2;
    public GameManager gm;

    [SerializeField] public float speed;

    private float timer=0;
    // Start is called before the first frame update
    private void Start()
    {
        car = GameObject.Find("CarParent");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        mirino1.transform.LookAt(new Vector3(car.transform.position.x, car.transform.position.y - 10, car.transform.position.z));
        mirino2.transform.LookAt(new Vector3(car.transform.position.x, car.transform.position.y-10, car.transform.position.z));



        if (timer >= 0.8f)
        {
            GameObject colpo = Instantiate(palla, mirino1.transform.position, mirino1.transform.rotation);
            colpo.GetComponent<Rigidbody>().velocity = (mirino1.transform.forward * speed);

            GameObject colpo2 = Instantiate(palla, mirino2.transform.position, mirino2.transform.rotation);
            colpo2.GetComponent<Rigidbody>().velocity = (mirino2.transform.forward * speed);

            Destroy(colpo, 2);
            Destroy(colpo2, 2);
            timer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name== "ColpoCannone")
        {
            gm.RimuoviAlienoCuore(this.gameObject);
            gm.AccendiImageKill();
            Destroy(this.gameObject, 0);
        }
    }

}
