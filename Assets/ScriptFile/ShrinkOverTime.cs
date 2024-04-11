using UnityEngine;

public class ShrinkOverTime : MonoBehaviour
{
    public float shrinkDuration = 5f; // Time in seconds for the prefab to shrink
    public Vector3 finalScale = Vector3.zero; // The final scale of the prefab when it shrinks to its smallest size

    private float startTime;
    private Vector3 initialScale;

    private void Start()
    {
        startTime = Time.time;
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Calculate the current time elapsed since the start
        float elapsedTime = Time.time - startTime;

        // Calculate the lerp value between the initial scale and the final scale based on the elapsed time
        float lerpValue = Mathf.Clamp01(elapsedTime / shrinkDuration);

        // Update the local scale of the prefab by lerping between the initial scale and the final scale
        transform.localScale = Vector3.Lerp(initialScale, finalScale, lerpValue);

        // Check if the prefab has reached its final scale
        if (lerpValue >= 0.5f)
        {
            // Destroy the prefab or perform any other desired action
            Destroy(gameObject);
        }
    }
}
