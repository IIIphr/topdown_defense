using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] float movement_speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_vector = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0);
        rb.velocity = move_vector * movement_speed;
        if(move_vector.x > 0)
        {
            animator.SetBool("is_walking_right", true);
            animator.SetBool("is_walking_left", false);
        }
        else if(move_vector.x < 0)
        {
            animator.SetBool("is_walking_right", false);
            animator.SetBool("is_walking_left", true);
        }
        else
        {
            animator.SetBool("is_walking_right", false);
            animator.SetBool("is_walking_left", false);
        }
        if (move_vector.y > 0)
        {
            animator.SetBool("is_walking_up", true);
            animator.SetBool("is_walking_down", false);
        }
        else if (move_vector.y < 0)
        {
            animator.SetBool("is_walking_up", false);
            animator.SetBool("is_walking_down", true);
        }
        else
        {
            animator.SetBool("is_walking_up", false);
            animator.SetBool("is_walking_down", false);
        }
        if(Input.GetAxis("Jump") > 0)
        {
            animator.SetBool("is_slashing", true);
        }
        else
        {
            animator.SetBool("is_slashing", false);
        }
    }
}
