using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject projectile, fireplace;
    [SerializeField] AudioClip fireball;
    public Animator animator;
     

    void Update()
    {
        {
            Fireball();
            animator.SetTrigger("Shoot");
        }
    }

    public void Fireball()
    {
        StartCoroutine("Shoot");
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        var newObject = Instantiate(projectile, fireplace.transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(fireball, new Vector3(0, 0, 0));
        //newObject.transform.parent = gameObject.transform;
    }
}
