using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorBlue : MonoBehaviour
{
    private Animator animatorL;
    private Animator animatorR;
    public GameObject doorBlueL;
    public GameObject doorBlueR;
    public GameObject Player;
    private void Start()
    {
        animatorL = doorBlueL.GetComponent<Animator>();
        animatorR = doorBlueR.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerSighted");
            if(Player.GetComponent<KeyCards>().bluKeycard)
            {
                animatorL.SetTrigger("Open");
                animatorR.SetTrigger("Open");
            }
        }
    }
}
