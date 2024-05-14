using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveMod = 5;
    public Vector2 move;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        transform.position = Input.mousePosition;
    }

    void FixedUpdate()
    {
        move = new Vector2(horizontal, vertical).normalized;
        body.velocity = new Vector2(move.x * moveMod,move.y * moveMod);
    }
}
