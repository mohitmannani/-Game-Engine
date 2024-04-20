using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight_controller : MonoBehaviour
{
    public Light spotlight; // Reference to the spotlight

    private bool isSpotlightEnabled = false;

    public void ToggleSpotlight()
    {
        isSpotlightEnabled = !isSpotlightEnabled;
        spotlight.enabled = isSpotlightEnabled;
    }

    public void ChangeSpotlightColor(Color newColor)
    {
        if (spotlight != null)
        {
            spotlight.color = newColor;
        }
    }
}
