using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{

    public GameObject CircleOnPlayer;
    public GameObject Circle;
    public GameObject Player;

    
    // Start is called before the first frame update
    void Start()
    {
        CircleOnPlayer.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.SetActive(false);
                CircleOnPlayer.SetActive(true);

            }
        }
    }
}
