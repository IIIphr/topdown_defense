using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float movement_speed = 1f;
    [SerializeField] float sprint_speed = 1.5f;
    [SerializeField] Animator animator;
    [SerializeField] float camera_distance = 5f;
    [SerializeField] float min_camera_distance = 2f;
    [SerializeField] float max_camera_distance = 8f;
    string anim_state;
    int facing_dir = 0;
    // 0 : down
    // 1 : up
    // 2 : right
    // 3 : left

    // Start is called before the first frame update
    void Start()
    {
        anim_state = "idle";
        animator.CrossFade("idle", 0, 0);
    }

    string dir_to_str()
    {
        return
            facing_dir == 0 ? "down" :
            facing_dir == 1 ? "up" :
            facing_dir == 2 ? "right" :
            "left";
    }

    int str_to_dir(string str)
    {
        return
            str == "down" ? 0 :
            str == "up" ? 1 :
            str == "right" ? 2 :
            3;
    }

   void anim_change(string state)
    {
        bool is_slashing = Input.GetAxis("Jump") > 0;
        if (state == "idle")
        {
            if (is_slashing)
            {
                state = "slash " + dir_to_str();
            }
            else
            {
                state = dir_to_str() + " idle";
            }
            if (state != anim_state)
            {
                animator.CrossFade(state, 0, 0);
                anim_state = state;
            }
        }
        else if(anim_state != state || is_slashing)
        {
            if (is_slashing)
            {
                if(anim_state != "slash " + state)
                {
                    animator.CrossFade("slash " + state, 0, 0);
                    anim_state = "slash " + state;
                }
            }
            else
            {
                animator.CrossFade(state, 0, 0);
                anim_state = state;
            }
            facing_dir = str_to_dir(state);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_vector = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0);
        rb.velocity = move_vector * 
            ( Input.GetAxis("Fire3") > 0 ? sprint_speed : movement_speed );
        if(move_vector.x > 0)
        {
            anim_change("right");
        }
        else if(move_vector.x < 0)
        {
            anim_change("left");
        }
        else if (move_vector.y > 0)
        {
            anim_change("up");
        }
        else if (move_vector.y < 0)
        {
            anim_change("down");
        }
        else
        {
            anim_change("idle");
        }
        camera_distance = Mathf.Max(min_camera_distance,
            Mathf.Min(max_camera_distance, camera_distance - Input.GetAxis("Mouse ScrollWheel")));
        Camera.main.transform.position = new Vector3(
            transform.position.x, transform.position.y, -1 * camera_distance);
    }
}
