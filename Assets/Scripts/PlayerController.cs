using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    [SerializeField] float speed = 4f;

    private float horizontalInput, verticalInput;

    private Vector3 movement;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Herhangi bir y�n tu�una bas�l�p bas�lmad���n� kontrol et
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

        // E�er herhangi bir y�n tu�una bas�ld�ysa y�r�me animasyonunu ba�lat
        anim.SetBool("isWalking", isMoving);

        Debug.Log(isMoving);

        // Y�n tu�lar�na bas�ld���nda karakteri hareket ettir
        Move();
        Flip();
    }
    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
    void Flip()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();


        // Yatay girdiye g�re karakterin y�z�n� d�nd�r�n
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Sa�a do�ru bak�yor
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Sola do�ru bak�yor
        }
    }
}
