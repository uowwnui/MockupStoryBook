using UnityEngine;

public class KeepRatio : MonoBehaviour
{
    // The target aspect ratio (16:9)
    private float targetAspectRatio = 16f / 9f;

    // Reference to the Canvas component
    private RectTransform rectTransform;

    private void Start()
    {
        // Get the Canvas component attached to this GameObject
        rectTransform = GetComponent<RectTransform>();

        // Call the function to update the canvas size initially
        UpdateCanvasSize();
    }

    private void UpdateCanvasSize()
    {
        // Calculate the current aspect ratio
        float currentAspectRatio = (float)Screen.width / Screen.height;

        // Calculate the desired width and height for the Canvas
        float canvasWidth, canvasHeight;

        if (currentAspectRatio > targetAspectRatio)
        {
            // If the current aspect ratio is wider than 16:9, set the canvas width to match the screen height
            canvasWidth = Screen.height * targetAspectRatio;
            canvasHeight = Screen.height;
        }
        else
        {
            // If the current aspect ratio is narrower than 16:9, set the canvas height to match the screen width
            canvasHeight = Screen.width / targetAspectRatio;
            canvasWidth = Screen.width;
        }

        // Update the Canvas size
        rectTransform.sizeDelta = new Vector2(canvasWidth, canvasHeight);

        //Debug.Log("Canvas size updated to: " + canvasWidth + "x" + canvasHeight + " Screen size: " + Screen.width + "x" + Screen.height);
    }

#if UNITY_EDITOR
    //because in real situation, the screen resolution won't change, so we don't need to update the canvas size every frame
    private void Update()
    {
        // Call the function to update the canvas size on every frame (useful if the screen resolution changes)
        UpdateCanvasSize();
    }
#endif
}
