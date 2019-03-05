using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Animator animator;

    private float raycastDistance = 3;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        Vector3 move = new Vector3(horizontal, vertical, 0f);
        transform.position = transform.position + move * Time.deltaTime * moveSpeed;

        if (horizontal == 0 && vertical == 0)
            return;

        Vector3 raycastStart = transform.position;
        Vector3 raycastDirection = Vector3.zero;

        if (horizontal != 0)
        {
            if (horizontal > 0)
                raycastDirection = transform.right * 1;
            else
                raycastDirection = transform.right * -1;
        }

        if (vertical != 0)
        {
            if (vertical > 0)
                raycastDirection = transform.up * 1;
            else
                raycastDirection = transform.up * -1;
        }

        RaycastHit2D hit = Physics2D.Raycast(raycastStart, raycastDirection, raycastDistance);
        Debug.DrawRay(raycastStart, raycastDirection * raycastDistance, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Obstacle")
            {
                Debug.Log("przeszkoda");
            }
        }
    }
}