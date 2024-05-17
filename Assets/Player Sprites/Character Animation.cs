using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour

{
    [SerializeField] GameObject Player;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Player.GetComponent<Rigidbody2D>().velocity!= Vector2.zero)
        {
            animator.SetBool("Walking", true);
        }
        else 
        { 
            animator.SetBool("Walking", false);
        }

    }
}
