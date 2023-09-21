using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HideButtonsWithTimeout : MonoBehaviour
{
    [SerializeField] private List<Button> buttonsToHide;
    [SerializeField] private float hideTimeout = 3.0f; // Time in seconds before hiding buttons

    private float currentTimeout;
    private bool isTimerRunning = false;

    private void Start()
    {
        currentTimeout = hideTimeout;
    }

    private void Update()
    {
        // Check for any input (e.g., mouse click or touch input)
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            // Reset the timer on input
            ShowButtons();
            currentTimeout = hideTimeout;
            isTimerRunning = true;
        }

        // If no input detected, start counting down the timer
        if (isTimerRunning)
        {
            currentTimeout -= Time.deltaTime;

            if (currentTimeout <= 0)
            {
                // Hide the buttons when the timer reaches zero
                HideButtons();
                isTimerRunning = false;
            }
        }
    }

    private void SetActiveButtons(bool value)
    {
        foreach (Button button in buttonsToHide)
        {
            if (button.gameObject.activeSelf == value)
            {
                continue;
            }

            button.gameObject.SetActive(value);
        }
    }

    private void ShowButtons()
    {
        SetActiveButtons(true);
    }

    private void HideButtons()
    {
        SetActiveButtons(false);
    }
}
