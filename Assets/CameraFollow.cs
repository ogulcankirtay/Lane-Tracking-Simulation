using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne
    public Vector3 offset; // Kamera ve nesne aras�ndaki mesafe ofseti

    void Update()
    {
        // Hedefin pozisyonunu takip et
        transform.position = target.position + offset;

        // Hedefin y�n�n� takip et
        transform.rotation = target.rotation;
    }
}
