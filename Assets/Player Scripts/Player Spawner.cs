using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject Spawn1;
    [SerializeField] GameObject Spawn2;
    [SerializeField] GameObject Spawn3;
    [SerializeField] GameObject Spawn4;
    [SerializeField] GameObject Player;
    void Start()
    {
        Vector2[] Spawnpoint = new Vector2[4];
        Spawnpoint[0] = Spawn1.transform.position; 
        Spawnpoint[1] = Spawn2.transform.position; 
        Spawnpoint[2] = Spawn3.transform.position; 
        Spawnpoint[3] = Spawn4.transform.position;
        Player.transform.position = Spawnpoint[(int)Mathf.Round(Random.Range(0, 3))];
    }
}
