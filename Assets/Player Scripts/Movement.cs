using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float HP;

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveMod = 5;
    public Vector2 move;
    void Start()
    {

    HP = 100f;

    body = GetComponent<Rigidbody2D>();

    }   
    void FixedUpdate()
    {
        if (HP <= 0) SceneManager.LoadScene(4);
        // Debug.Log(HP);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(horizontal, vertical).normalized;
        body.velocity = new Vector2(move.x * moveMod,move.y * moveMod);
    }
}
