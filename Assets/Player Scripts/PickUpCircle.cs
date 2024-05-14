using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCircle : MonoBehaviour
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

        print("Collison!");

        if (other.gameObject.tag == "Pickable")        
        {
            
            if (Input.GetKey(KeyCode.Space))
            {
                other.gameObject.SetActive(false);

                CircleOnPlayer.SetActive(true);

            }
        }
    }

}
