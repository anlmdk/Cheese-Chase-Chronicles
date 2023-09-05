using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    Animator anim;

    Rigidbody rb;

    EnemyBehaviour enemyBehaviour;

    [SerializeField] float collisionForce = 5f; // Ýttirme gücü miktarý

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            EnemyBehaviour.instance.death = true;

            anim.SetTrigger("isDying");

            enemyBehaviour.enabled = false;

            Invoke("OnDestroy", 2f);
        }
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("isWhacking", true);

            // Rigidbody bileþenini kontrol et
            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                // Ýki düþman birbirine çarparsa hareket yönünü tersine çevir
                Vector2 reverseDirection = -otherRb.velocity;
                otherRb.velocity = reverseDirection;

                // Ýttirme gücü uygula
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
                otherRb.AddForce(pushDirection * collisionForce, ForceMode2D.Impulse);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.HitEnemy();
            anim.SetBool("isWhacking", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("isWhacking", false);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isWhacking", false);
        }
    }
}
