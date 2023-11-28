using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // This script sets how the healthbar works

    // Reference to the UI slider component
    public Slider slider;

    // Set the maximum health for the health bar
    public void SetMaxHealth(int health) 
    {
        // Set the maximum value of the slider to the provided health value
        slider.maxValue = health;
        // Set the current value of the slider to the maximum health value
        slider.value = health; 
    }

    // Update the health bar with the current health value
    public void SetHealth(int health) 
    {
        // Set the current value of the slider to the provided health value
        slider.value = health; 
    }

}
