using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorGreen : MonoBehaviour
{
    private Animator animatorD;
    private Animator animatorU;
    public GameObject doorGreenU;
    public GameObject doorGreenD;
    public GameObject keycardGreen;
    public GameObject player;
    private void Start()
    {
        animatorD = doorGreenD.GetComponent<Animator>();
        animatorU = doorGreenU.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Noticed");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Noticed");
            if (keycardGreen.activeSelf == false) 
            {
                Debug.Log("keycard Noticed");
                animatorD.SetTrigger("OpenDoorDown");
                animatorU.SetTrigger("OpenDoorUp");
            }
        }
    }
}
