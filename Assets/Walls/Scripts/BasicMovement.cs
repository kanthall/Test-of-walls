using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    [SerializeField] float speed;
    public Animator animator;
    [SerializeField] GameObject targetPoint;

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


        Vector3 raycastDir = new Vector3(2f, 0f, 0f);
        Vector3 posRay = new Vector3(2f, 0f, 0f);

        Debug.DrawRay(transform.position, raycastDir, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(raycastDir, Vector3.zero);

        //If something was hit, the RaycastHit2D.collider will not be null.
        if (hit.collider != null)
        {
            Debug.Log("Hit");
        } 
        else if (hit.collider.name == "Wall")
            {
            Debug.Log("ściana");
        }


    }
}

