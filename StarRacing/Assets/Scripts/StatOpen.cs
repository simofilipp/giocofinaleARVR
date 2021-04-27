using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatOpen : MonoBehaviour
{
    public GameObject stat;


    public void OpenStat()
    {
        if (stat != null)
        {
            Animator animator = stat.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }
}
