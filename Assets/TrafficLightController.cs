using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public Renderer redLightRenderer;
    public Renderer greenLightRenderer;
    public float redDuration = 10f;
    public float greenDuration = 10f;

    private float timer;
    private bool isGreen = false;

    private void Start()
    {
        // Ýlk baþta kýrmýzý ýþýðý etkinleþtirin
        SetGreenLight();
        timer = redDuration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (isGreen)
            {
                SetGreenLight();
                timer = greenDuration;
                
            }
            else
            {
                SetRedLight();
                timer = redDuration;
            }

            isGreen = !isGreen;
        }
    }

    private void SetRedLight()
    {
        redLightRenderer.material.color = Color.red;
        greenLightRenderer.material.color = Color.black;
    }

    private void SetGreenLight()
    {
        redLightRenderer.material.color = Color.black;
        greenLightRenderer.material.color = Color.green;
    }
}
