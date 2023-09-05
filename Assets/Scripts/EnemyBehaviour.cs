using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour instance;

    [SerializeField] float speed = 5f;
    [SerializeField] float wanderMinX = -10f; // Rastgele dolaþma sýnýrlarý
    [SerializeField] float wanderMaxX = 10f;
    [SerializeField] float wanderMinY = -9f; // Y eksenindeki sýnýrlar
    [SerializeField] float wanderMaxY = 9f;
    [SerializeField] float cheeseDetectionRadius = 10f; // Peynir algýlama yarýçapý

    public bool death = false;
    private Vector3 targetPosition;
    private bool isEating = false;
    private bool isFacingRight = true; // Karakterin saða dönük olduðunu varsayalým

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
        // Baþlangýçta rastgele bir hedef pozisyonu seçin
        targetPosition = GetRandomWanderPosition();
    }

    void Update()
    {
        if (!death)
        {
            // Peynir algýlamak için belirli bir yarýçap içindeki nesneleri kontrol edin
            Collider[] cheeseColliders = Physics.OverlapSphere(transform.position, cheeseDetectionRadius);

            foreach (var collider in cheeseColliders)
            {
                if (collider.CompareTag("Cheese"))
                {
                    // Peynir algýlandýðýnda doðrudan peynire git
                    targetPosition = collider.transform.position;
                    isEating = true;
                    break; // En yakýn peynire yönlendirildikten sonra dolaþmayý durdurun
                }
            }

            // Eðer yem yeme iþlemi tamamlandýysa, rastgele dolaþma devam etsin
            if (!isEating)
            {
                MoveRandomly();
            }
            else
            {
                // Eðer hedef pozisyonu ulaþýldýysa, yem iþlemi tamamlandý olarak iþaretleyin
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isEating = false;
                }
            }
        }
    }

    private void MoveRandomly()
    {
        // Eðer rastgele dolaþma hedefine ulaþýldýysa, yeni bir rastgele dolaþma hedefi seçin
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomWanderPosition();
        }

        // Düþmaný rastgele dolaþma hedefine yönlendirin
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Yönü kontrol edin ve karakteri çevirin
        if (moveDirection.x > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection.x < 0 && isFacingRight)
        {
            FlipCharacter();
        }
    }

    private Vector3 GetRandomWanderPosition()
    {
        // Rastgele bir dolaþma pozisyonu oluþturun
        float randomX = Random.Range(wanderMinX, wanderMaxX);
        float randomY = Random.Range(wanderMinY, wanderMaxY); // Y eksenindeki rastgele pozisyon
        Vector3 randomPosition = new Vector3(randomX, randomY, transform.position.z);

        return randomPosition;
    }

    private void FlipCharacter()
    {
        // Karakterin yönünü çevirin (saða veya sola dönme)
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !isFacingRight;
    }
}
