using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSliderBar : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue) // whether the slider is too small
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled) // change to the health bar
        {
            fillImage.enabled = true;
        }
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        if (slider.value <= slider.maxValue / 2)
        {
            fillImage.color = Color.red;   // for a change in color
        }
        else if (fillValue > slider.maxValue / 2)
        {
            fillImage.color = Color.green;
        }
        slider.value = fillValue;
        //  this renders the player health bar
    }
}
