using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun, particleDeath;
        //prefab;
    [SerializeField] AudioClip projectileSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] int health = 1;
    [SerializeField] GameObject rateGreen;

    public Animator animator;
    private AudioSource audioSource;
    private Vector3 particlePosition;
    public bool isDead = false;
    Vector3 minus = new Vector3(1F, 0, 0);

    void Start()
    {
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Fire();
            animator.SetTrigger("Shoot");
        }

        if (health == 0 && !isDead)
        {
            StartCoroutine("Death");
            isDead = true;
        }
    }

    public void Fire()
    {
        var newObject = Instantiate(projectile, gun.transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(projectileSound, new Vector3(0, 0, 0));
        Debug.Log("Fire");
    }

    private IEnumerator Death()
    {
        isDead = true;
        audioSource.PlayOneShot(hitSound, 0.9F);
        audioSource.PlayOneShot(deathSound, 0.5F);
        animator.SetTrigger("Die");
        particlePosition = new Vector3(transform.position.x, transform.position.y, -10);
        GameObject part = Instantiate(particleDeath, particlePosition, Quaternion.identity);
        Destroy(part, 1f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("4Death");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        animator.SetTrigger("Hit");

        if (rateGreen == null)
        {
            return;
        }

        rateGreen.transform.localScale -= minus;

        if (rateGreen.transform.localScale.x < 0)
        {
            Destroy(rateGreen);
        }
    }
}
