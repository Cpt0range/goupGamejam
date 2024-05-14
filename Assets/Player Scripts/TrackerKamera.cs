using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrackerKamera : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float FollowSpeed;
    [SerializeField] private float MouseForce;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Screen.width);

        Vector3 mousePosition = Input.mousePosition;

        mousePosition.x -= Screen.width / 2;

        mousePosition.y -= Screen.height / 2;

        Vector3 Target =
        Player.transform.position + mousePosition * MouseForce;

        Vector3 MoveVektor = Target - transform.position;

        MoveVektor.z = 0;

        transform.Translate(MoveVektor * Time.deltaTime * FollowSpeed);



    }
}