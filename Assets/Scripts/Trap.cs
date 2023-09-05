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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isCatching", true);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("isCatching", true);

            Invoke("OnDestroy", 2f);
        }
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
