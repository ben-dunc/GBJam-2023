using UnityEngine;

public class RainbowColor : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f; // Adjust the speed of color change as needed
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("This script requires a SpriteRenderer component on the GameObject.");
            enabled = false; // Disable the script if there's no SpriteRenderer
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // Calculate a new color based on time elapsed
        float t = Mathf.PingPong(timeElapsed * colorChangeSpeed, 1f);
        Color newColor = Color.Lerp(Color.red, Color.blue, t); // You can modify the colors as needed

        // Apply the new color to the SpriteRenderer
        spriteRenderer.color = newColor;
    }
}
