using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightMenu : MonoBehaviour
{
    public Light targetLight;
    public InputField posXInput, posYInput, posZInput;
    public InputField rotXInput, rotYInput, rotZInput;
    public InputField scaleXInput, scaleYInput, scaleZInput;
    public Dropdown lightTypeDropdown;
    public Slider intensitySlider, shadowStrengthSlider;
    public Slider lightRangeSlider;

    public void OnPosXEndEdit()
    {
        if (targetLight != null && posXInput != null)
        {
            float posX;
            if (float.TryParse(posXInput.text, out posX))
            {
                Vector3 newPosition = targetLight.transform.position;
                newPosition.x = posX;
                targetLight.transform.position = newPosition;
            }
        }
    }

    // Call this method when the user finishes editing Y position
    public void OnPosYEndEdit()
    {
        if (targetLight != null && posYInput != null)
        {
            float posY;
            if (float.TryParse(posYInput.text, out posY))
            {
                Vector3 newPosition = targetLight.transform.position;
                newPosition.y = posY;
                targetLight.transform.position = newPosition;
            }
        }
    }

    // Call this method when the user finishes editing Z position
    public void OnPosZEndEdit()
    {
        if (targetLight != null && posZInput != null)
        {
            float posZ;
            if (float.TryParse(posZInput.text, out posZ))
            {
                Vector3 newPosition = targetLight.transform.position;
                newPosition.z = posZ;
                targetLight.transform.position = newPosition;
            }
        }
    }







    public void OnRotXEndEdit()
    {
        if (targetLight != null && rotXInput != null)
        {
            float rotX;
            if (float.TryParse(rotXInput.text, out rotX))
            {
                Vector3 newRotation = targetLight.transform.eulerAngles;
                newRotation.x = rotX;
                targetLight.transform.eulerAngles = newRotation;
            }
        }
    }

    public void OnRotYEndEdit()
    {
        if (targetLight != null && rotYInput != null)
        {
            float rotY;
            if (float.TryParse(rotYInput.text, out rotY))
            {
                Vector3 newRotation = targetLight.transform.eulerAngles;
                newRotation.y = rotY;
                targetLight.transform.eulerAngles = newRotation;
            }
        }
    }

    public void OnRotZEndEdit()
    {
        if (targetLight != null && rotZInput != null)
        {
            float rotZ;
            if (float.TryParse(rotZInput.text, out rotZ))
            {
                Vector3 newRotation = targetLight.transform.eulerAngles;
                newRotation.z = rotZ;
                targetLight.transform.eulerAngles = newRotation;
            }
        }
    }





    public void OnLightTypeChange()
    {
        if (targetLight != null && lightTypeDropdown != null)
        {
            int selectedType = lightTypeDropdown.value;

            switch (selectedType)
            {
                case 0: // Example: Spot Light
                    targetLight.type = LightType.Spot;
                    break;
                case 1: // Example: Directional Light
                    targetLight.type = LightType.Directional;
                    break;
                case 2: // Example: Directional Light
                    targetLight.type = LightType.Point;
                    break;
                // Add more cases for other light types as needed
                default:
                    Debug.LogError("Invalid light type selected.");
                    break;
            }
        }
    }





    public void OnIntensityChange()
    {
        if (targetLight != null && intensitySlider != null)
        {
            targetLight.intensity = intensitySlider.value;
        }
    }

    public void OnShadowStrengthChange()
    {
        if (targetLight != null && shadowStrengthSlider != null)
        {
            float sliderValue = shadowStrengthSlider.value;

            // Assuming the slider adjusts the shadow strength directly
            targetLight.shadowStrength = sliderValue;

            // Log the shadow strength for debugging purposes
            Debug.Log("Shadow Strength: " + sliderValue);
        }
    }


    public void OnLightRangeChange()
    {
        if (targetLight != null && lightRangeSlider != null)
        {
            targetLight.range = lightRangeSlider.value;
        }
    }

}
