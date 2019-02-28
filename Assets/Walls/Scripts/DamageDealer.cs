using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] GameObject particle;
    private Vector3 particlePosition;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
        particlePosition = new Vector3(transform.position.x, transform.position.y, -3);
        GameObject part = Instantiate(particle, particlePosition, Quaternion.identity);
        Destroy(part, 1f);
    }
}
