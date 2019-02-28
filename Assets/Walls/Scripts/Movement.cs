using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    private float speed = 5f;
    private Shooter shooter;
    [SerializeField] bool up = false;
    [SerializeField] bool down = false;
    [SerializeField] bool left = false;
    [SerializeField] bool right = false;
    [SerializeField] float padding = 0.01f;

    private void Start()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (shooter.isDead == true)
        {
            return;
        }
        movementWithAnimations();
    }

    private void movementWithAnimations()
    {
        float moveX = 0f, moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow) && up == false)
        {
            down = true;
            left = true;
            right = true;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("RunTop");
            moveY = +1f;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            down = false;
            left = false;
            right = false;
            Debug.Log("UpArrow key was released");
        }
        else if (Input.GetKey(KeyCode.DownArrow) && down == false)
        {
            up = true;
            left = true;
            right = true;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("RunDown");
            moveY = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            up = false;
            left = false;
            right = false;
            Debug.Log("DownArrow key was released");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && left == false)
        {
            up = true;
            down = true;
            right = true;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("RunHorizontal");
            transform.eulerAngles = new Vector3(0, 180, 0);
            moveX = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            up = false;
            down = false;
            right = false;
            Debug.Log("DownArrow key was released");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && right == false)
        {
            up = true;
            down = true;
            left = true;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("RunHorizontal");
            transform.eulerAngles = new Vector3(0, 0, 0);
            moveX = +1f;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            up = false;
            down = false;
            left = false;
            Debug.Log("RightArrow key was released");
        }
        else
        {
            animator.ResetTrigger("RunHorizontal");
            animator.ResetTrigger("RunDown");
            animator.ResetTrigger("RunTop");
            animator.SetTrigger("Idle");
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }
}