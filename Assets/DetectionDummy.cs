using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
    Animator animator;
    bool currentValue = false; // Initial value of the parameter

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Ensure the Animator component exists
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
            enabled = false; // Disable the script if Animator is not found
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Toggle the boolean parameter "angeregt"
            currentValue = !currentValue;
            animator.SetBool("angeregt", currentValue);
        }
    }
}
