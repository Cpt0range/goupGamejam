using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCards : MonoBehaviour
{
    [SerializeField] private string Card;
    public bool bluKeycard;
    public GameObject BlueKeycardUI;
    public GameObject BlueKeycard;

    public bool redKeycard;
    public GameObject RedKeycardUI;
    public GameObject RedKeycard;

    public bool grnKeycard;
    public GameObject GreenKeycardUI;
    public GameObject GreenKeycard;

    public bool purKeycard;
    public GameObject PurpleKeycardUI;
    public GameObject PurpleKeycard;

    public bool yelKeycard;
    public GameObject YellowKeycardUI;
    public GameObject YellowKeycard;

    private void Start()
    {
        BlueKeycard.SetActive(true);
        BlueKeycardUI.SetActive(false);

        RedKeycard.SetActive(true);
        RedKeycardUI.SetActive(false);

        GreenKeycard.SetActive(true);
        GreenKeycardUI.SetActive(false);

        PurpleKeycard.SetActive(true);
        PurpleKeycardUI.SetActive(false);

        YellowKeycard.SetActive(true);
        YellowKeycardUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
     
        if (trigger.CompareTag("Player"))
        {
            switch (Card) 
            {
                case "Blue":
                    bluKeycard = true;
                    BlueKeycard.SetActive(false);
                    BlueKeycardUI.SetActive(true);
                    break;
                case "Red":
                    redKeycard = true;
                    RedKeycard.SetActive(false);
                    RedKeycardUI.SetActive(true);
                    break;
                case "Green":
                    grnKeycard = true;
                    GreenKeycard.SetActive(false);
                    GreenKeycardUI.SetActive(true);
                    break;
                case "Purple":
                    purKeycard = true;
                    PurpleKeycard.SetActive(false);
                    PurpleKeycardUI.SetActive(true);
                    break;
                case "Yellow":
                    yelKeycard = true;
                    YellowKeycard.SetActive(false);
                    YellowKeycardUI.SetActive(true);
                    break;
                case "Player":
                    break;
                case "DoorController":
                    break;
                default:
                    Debug.Log("Invalid Keycard Type");
                    break;
            }
        }
    }
}
