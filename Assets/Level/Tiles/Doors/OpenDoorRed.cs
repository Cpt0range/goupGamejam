using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorRed : MonoBehaviour
{
    private Animator animatorL;
    private Animator animatorR;
    public GameObject doorRedL;
    public GameObject doorRedR;
    public GameObject keycardRed;
    public GameObject player;
    private void Start()
    {
        animatorL = doorRedL.GetComponent<Animator>();
        animatorR = doorRedR.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keycardRed.activeSelf == false) 
            {
                animatorL.SetTrigger("OpenDoorLeft");
                animatorR.SetTrigger("OpenDoorRight");

            }
        }
    }
}
