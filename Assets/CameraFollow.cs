using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne
    public Vector3 offset; // Kamera ve nesne arasýndaki mesafe ofseti

    void Update()
    {
        // Hedefin pozisyonunu takip et
        transform.position = target.position + offset;

        // Hedefin yönünü takip et
        transform.rotation = target.rotation;
    }
}
