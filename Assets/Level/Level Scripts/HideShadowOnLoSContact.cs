using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShadowOnLoSContact : MonoBehaviour
{
    /*void Update()
    {
        
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
    }
}
