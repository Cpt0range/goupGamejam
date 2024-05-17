using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorBlue : MonoBehaviour
{
    private Animator animatorD;
    private Animator animatorU;
    public GameObject doorBlueD;
    public GameObject doorBlueU;
    public GameObject keycardBlue;
    public GameObject player;
    private void Start()
    {
        animatorD = doorBlueD.GetComponent<Animator>();
        animatorU = doorBlueU.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keycardBlue.activeSelf == false) 
            {
                animatorD.SetTrigger("OpenDoorDown");
                animatorU.SetTrigger("OpenDoorUp");
            }
        }
    }
}
