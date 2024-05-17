using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPurple : MonoBehaviour
{
    private Animator animatorL;
    private Animator animatorR;
    public GameObject doorPurpleL;
    public GameObject doorPurpleR;
    public GameObject keycardPurple;
    public GameObject player;
    private void Start()
    {
        animatorL = doorPurpleL.GetComponent<Animator>();
        animatorR = doorPurpleR.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerSighted");
            if (keycardPurple.activeSelf == false) 
            {
                animatorL.SetTrigger("OpenDoorLeft");
                animatorR.SetTrigger("OpenDoorRight");

            }
        }
    }
}
