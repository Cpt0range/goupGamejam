using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{

    public GameObject CircleOnPlayer;
    public GameObject Circle;
    public GameObject Player;
    Boolean Contact = false;

    
    // Start is called before the first frame update
    void Start()
    {
        CircleOnPlayer.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Contact = true;
       // Debug.Log("Contact!");
    }
    private void OnTriggerExit2D(Collider2D Player)
    {
        Contact = false;
       // Debug.Log("Lost Contact!");
    }
    private void Update()
    {
        if (Contact) 
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
               this.gameObject.SetActive(false);
               CircleOnPlayer.SetActive(true);
            }
        }
    }
}
