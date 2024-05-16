using UnityEngine;

public class Leer : MonoBehaviour
{
    // Referenz auf den Animator
    private Animator animator;

    void Start()
    {
        // Den Animator des GameObjects über den spezifischen Namen "EnemyStateControl" holen
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Überprüfen, ob die Leertaste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Den aktuellen Wert des Parameters "angeregt" erhalten
            bool currentValue = animator.GetBool("angeregt");

            // Den Wert des Parameters umkehren (Toggle)
            animator.SetBool("angeregt", !currentValue);
        }
    }
}