using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorYellowD : MonoBehaviour
{
    private Animator animatorL;
    private Animator animatorR;
    public GameObject doorYellowDL;
    public GameObject doorYellowDR;
    public GameObject keycardYellow;
    public GameObject keycardYellow2;
    public GameObject player;
    private void Start()
    {
        animatorL = doorYellowDL.GetComponent<Animator>();
        animatorR = doorYellowDR.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerSighted");
            if (keycardYellow.activeSelf == false|keycardYellow2.activeSelf == false) 
            {
                animatorL.SetTrigger("OpenDoorLeft");
                animatorR.SetTrigger("OpenDoorRight");

            }
        }
    }
}
