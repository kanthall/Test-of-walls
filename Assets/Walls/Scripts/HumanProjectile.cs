using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanProjectile : MonoBehaviour
{
    float moveSpeed1 = 2f;
    float moveSpeed2 = 3f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float randomSpeed = Random.Range(moveSpeed1, moveSpeed2);
        transform.Translate(Vector3.right * Time.deltaTime * randomSpeed);
    }
}
