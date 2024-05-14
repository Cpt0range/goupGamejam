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
        Vector3 Pos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += Pos * moveMod * Time.deltaTime;
        Vector3 direction = Pos.normalized;

        if (Pos != Vector3.zero)
        {
            transform.up = direction;
        }
    }

    void FixedUpdate()
    {
        move = new Vector2(horizontal, vertical).normalized;
        body.velocity = new Vector2(move.x * moveMod,move.y * moveMod);
    }
}
