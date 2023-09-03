using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour instance;

    [SerializeField] float speed = 5f;
    [SerializeField] float wanderMinX = -10f; // Rastgele dola�ma s�n�rlar�
    [SerializeField] float wanderMaxX = 10f;
    [SerializeField] float wanderMinY = -9f; // Y eksenindeki s�n�rlar
    [SerializeField] float wanderMaxY = 9f;

    public bool death = false;
    private Vector3 targetPosition;
    private bool isEating = false;
    private bool isFacingRight = true; // Karakterin sa�a d�n�k oldu�unu varsayal�m

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Ba�lang��ta rastgele bir hedef pozisyonu se�in
        targetPosition = GetRandomWanderPosition();
    }

    void Update()
    {
        if (!death)
        {
            // E�er yem yeme i�lemi tamamland�ysa, rastgele dola�ma devam etsin
            if (!isEating)
            {
                MoveRandomly();
            }
            else
            {
                // E�er hedef pozisyonu ula��ld�ysa, yem i�lemi tamamland� olarak i�aretleyin
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isEating = false;
                }
            }
        }
    }

    private void MoveRandomly()
    {
        // E�er rastgele dola�ma hedefine ula��ld�ysa, yeni bir rastgele dola�ma hedefi se�in
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomWanderPosition();
        }

        // D��man� rastgele dola�ma hedefine y�nlendirin
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Y�n� kontrol edin ve karakteri �evirin
        if (moveDirection.x > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection.x < 0 && isFacingRight)
        {
            FlipCharacter();
        }

        // Yak�ndaki peyniri kontrol edin ve yeme i�lemi ba�lat�n
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f); // 5 birimlik bir yar��ap i�indeki nesneleri kontrol et

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Cheese"))
            {
                isEating = true;
                targetPosition = collider.transform.position;
                Destroy(collider.gameObject); // Peyniri yok et
                break; // En yak�n peyniri yedikten sonra dola�may� durdurun
            }
        }
    }

    private Vector3 GetRandomWanderPosition()
    {
        // Rastgele bir dola�ma pozisyonu olu�turun
        float randomX = Random.Range(wanderMinX, wanderMaxX);
        float randomY = Random.Range(wanderMinY, wanderMaxY); // Y eksenindeki rastgele pozisyon
        Vector3 randomPosition = new Vector3(randomX, randomY, transform.position.z);

        return randomPosition;
    }

    private void FlipCharacter()
    {
        // Karakterin y�n�n� �evirin (sa�a veya sola d�nme)
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !isFacingRight;
    }
}
