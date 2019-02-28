using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    public float speed;             
    private Rigidbody2D rb2d;
    [SerializeField] Animator animator;

    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

       
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);      
        rb2d.AddForce(movement * speed * Time.deltaTime);
    }
}