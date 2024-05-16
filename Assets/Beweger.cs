using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beweger : MonoBehaviour
{ 
    public GameObject Player;
    [SerializeField] private FieldOfView fieldOfView;

    public GameObject Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Enemy.transform.position;
        fieldOfView.SetAimDirection(Player.transform.position - Enemy.transform.position);
        fieldOfView.SetOrigin(transform.position);

    }
}
