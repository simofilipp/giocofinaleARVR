using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColliderAlieniCuore : MonoBehaviour
{
    public GameObject alienPrefab;
    public GameManager gm;
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
            if (gm.posizioniSpawn.Count > 0)
            {
                GameObject pos = gm.posizioniSpawn[Random.Range(0, gm.posizioniSpawn.Count - 1)];
                GameObject alien = Instantiate(alienPrefab, pos.transform);
                gm.alieniCuore.Add(alien);
                gm.posizioniSpawn.Remove(pos);
            }
        }
    }
}
