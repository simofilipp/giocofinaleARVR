using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UfoMadre : MonoBehaviour
{
    public List<GameObject> sfere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sfere.Count == 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void RimuoviSfera(GameObject go)
    {
        sfere.Remove(go);
    }
}
