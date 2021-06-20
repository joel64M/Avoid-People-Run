using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameManagerScript gms;

    private void Start()
    {
        gms = GameManagerScript.instance;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                transform.GetChild(i).SetAsFirstSibling();
            }
        }

        GetComponent<Animator>().Rebind();

    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        gms.GameOver();
    //    }
    //}
}
