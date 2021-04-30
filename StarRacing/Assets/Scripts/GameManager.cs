using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> alieniPrimoLivello;
    public List<GameObject> colliderAlieniCuore;
    public List<GameObject> posizioniSpawn;
    public List<GameObject> alieniCuore;
    public List<GameObject> alieniTrapper;

    public List<GameObject> spawnChiavi;
    public GameObject chiave;
    List<GameObject> chiavi;
    

    public GameObject alieniTerzoLivello;
    public GameObject ufoMadre;
    public Image vita;
    public Sprite[] livelli;
    public Sprite[] killSprites;
    public Image livelliImage;
    public Image killImage;
    public NewCarController macchina;

    float timerChiave=0;

    bool secondoLivello=false;
    bool terzoLivello=false;
    bool bossFinale = false;

    void Start()
    {
        AggiornaSpriteLivello(0);
        chiavi = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        vita.fillAmount = macchina.life / 100;
        if (macchina.life <= 0)
        {
            SceneManager.LoadScene(2);
        }
        if (alieniPrimoLivello.Count == 0&& !secondoLivello)
        {
            Invoke("IniziaSecondoLivello", 5);
            AggiornaSpriteLivello(1);
            secondoLivello = true;
        }
        if (alieniCuore.Count == 0 && posizioniSpawn.Count==0 && !terzoLivello)
        {
            Invoke("IniziaTerzoLivello", 5);
            AggiornaSpriteLivello(2);
            terzoLivello = true;
        }
        if(alieniTrapper.Count==0 && !bossFinale)
        {
            foreach(SphereCollider sc in ufoMadre.GetComponentsInChildren<SphereCollider>())
            {
                sc.enabled = true;
            }
            AggiornaSpriteLivello(3);
            bossFinale = true;
        }
        timerChiave += Time.deltaTime;
        if (timerChiave >= 15 && chiavi.Count < 4) 
        {
            timerChiave = 0;
            GameObject chiaveTemp= Instantiate(chiave, spawnChiavi[Random.Range(0, spawnChiavi.Count - 1)].transform.position,Quaternion.identity);
            chiavi.Add(chiaveTemp);
        }
    }

    void IniziaSecondoLivello()
    {
        foreach(GameObject go in colliderAlieniCuore)
        {
            Debug.Log("secondo livello");
            go.GetComponent<BoxCollider>().enabled = true;
        }

    }
    public void IniziaTerzoLivello()
    {
        alieniTerzoLivello.SetActive(true);
    }

    public void RimuoviAlieno(GameObject go)
    {
        alieniPrimoLivello.Remove(go);
    }
    public void RimuoviAlienoCuore(GameObject go)
    {
        alieniCuore.Remove(go);
    }
    public void RimuoviAlienoTrapper(GameObject go)
    {
        alieniTrapper.Remove(go);
    }


    void AggiornaSpriteLivello(int i)              
    {
        livelliImage.enabled = true;
        livelliImage.sprite = livelli[i];
        Invoke("SpegniSpriteLivelli", 3);
    }
    void SpegniSpriteLivelli()
    {
        livelliImage.enabled=false;
    }

    public void RimuoviChiave(GameObject go)
    {
        chiavi.Remove(go);
    }

    public void AccendiImageKill()
    {
        killImage.enabled = true;
        killImage.sprite = killSprites[Random.Range(0, 1)];
        Invoke("SpegniImageKill", 0.5f);
    }

    void SpegniImageKill()
    {
        killImage.enabled = false;
    }
}
