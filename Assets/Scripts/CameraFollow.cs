using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetPlayer;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    private Vector3 veolcity = Vector3.zero;
    public float smoothTime = 0.3f;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void LateUpdate()
    {
        targetedPosition = targetPlayer.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref veolcity, smoothTime);

        // Kamera pozisyonunu sýnýrlar içinde tut
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
