using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSprint(int sprint)
    {
        slider.maxValue = sprint;
        slider.value = sprint;
    }

    public void SetSprint(int sprint)
    {
        slider.value = sprint;
    }
}
