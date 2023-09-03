using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isCatching", false);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // player death

            anim.SetBool("isCatching", true);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour.instance.death = true;
            Destroy(collision.gameObject);

            // Ölme animasyonunu göster ve düþmaný yok et
            // ölme animasyonu.SetActive(true);
        }
    }
}
