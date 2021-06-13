using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator anim;
    GameManagerScript gms;

    public Camera cam;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        gms = GameManagerScript.instance;
        gms.AddCharAnimation(this);
        cam = Camera.main;
    }

    private void Update()
    {

        if (gms.isGameStart)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }

        if (gms.isGameComplete)
        {
            transform.LookAt(cam.transform,Vector3.up);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y, 0);
        }
    }
    public void GameFailedAnimation()
    {
        anim.SetBool("Lose", true);
    }
    public void GameCompleteAnimation()
    {
        anim.SetBool("Win", true);
     

    }
}

