using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    [SerializeField] float speed;
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), (Input.GetAxis("Vertical")), 0f);
        transform.position = transform.position + move * Time.deltaTime * speed;

        Vector3 targetMovePosition = transform.position + move * speed * Time.deltaTime;
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, move, speed * Time.deltaTime);

        Vector3 right = transform.TransformDirection(Vector3.right) * 10;

        if (raycastHit.collider == null)
        {
            transform.position = targetMovePosition;
            Debug.DrawRay(transform.position, right, Color.red);
        }
        else
        { 

        }
    }
}
