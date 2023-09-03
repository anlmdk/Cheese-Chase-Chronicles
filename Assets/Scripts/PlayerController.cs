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
        // Herhangi bir yön tuþuna basýlýp basýlmadýðýný kontrol et
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

        // Eðer herhangi bir yön tuþuna basýldýysa yürüme animasyonunu baþlat
        anim.SetBool("isWalking", isMoving);

        Debug.Log(isMoving);

        // Yön tuþlarýna basýldýðýnda karakteri hareket ettir
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


        // Yatay girdiye göre karakterin yüzünü döndürün
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Saða doðru bakýyor
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Sola doðru bakýyor
        }
    }
}
