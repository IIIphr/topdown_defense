using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool flag = false;
        if(Input.GetAxis("Vertical") > 0)
        {
            flag = true;
            rb.velocity = new Vector3(rb.velocity.x, 1, 0);
            animator.SetBool("is_walking_up", true);
            animator.SetBool("is_walking_down", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            flag = true;
            rb.velocity = new Vector3(rb.velocity.x, -1, 0);
            animator.SetBool("is_walking_up", false);
            animator.SetBool("is_walking_down", true);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            animator.SetBool("is_walking_up", false);
            animator.SetBool("is_walking_down", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            flag = true;
            rb.velocity = new Vector3(1, rb.velocity.y, 0);
            animator.SetBool("is_walking_right", true);
            animator.SetBool("is_walking_left", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            flag = true;
            rb.velocity = new Vector3(-1, rb.velocity.y, 0);
            animator.SetBool("is_walking_right", false);
            animator.SetBool("is_walking_left", true);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            animator.SetBool("is_walking_right", false);
            animator.SetBool("is_walking_left", false);
        }
        if (!flag)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("is_walking_up", false);
            animator.SetBool("is_walking_down", false);
            animator.SetBool("is_walking_right", false);
            animator.SetBool("is_walking_left", false);
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
