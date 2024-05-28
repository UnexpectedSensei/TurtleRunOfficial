using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public Slider slider;
    private bool isRefilling = false;
    public float refillRate = 1f; // Amount to refill per second

    public void SetMaxSprint(float sprint)
    {
        slider.maxValue = sprint;
        slider.value = sprint;
    }

    public void SetSprint(float sprint)
    {
        slider.value = sprint;

        // If sprint is not full and not already refilling, start the refill coroutine
        if (slider.value < slider.maxValue && !isRefilling)
        {
            StartCoroutine(RefillSprint());
        }
    }

    private IEnumerator RefillSprint()
    {
        isRefilling = true;

        while (slider.value < slider.maxValue)
        {
            slider.value += refillRate * Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        slider.value = slider.maxValue; // Ensure it's exactly at max value
        isRefilling = false;
    }

    public float GetCurrentSprint()
    {
        return slider.value;
    }
}

