using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLightColor : MonoBehaviour
{
    public Spotlight_controller spotlightController; // Reference to the SpotlightController
    public Color[] colors; // Array of colors for the spotlight

    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Avoids closure issues in the lambda expression
            buttons[i].onClick.AddListener(() => ChangeSpotlightColor(index));
            buttons[i].GetComponent<Image>().color = colors[i];
        }
    }

    private void ChangeSpotlightColor(int index)
    {
        if (spotlightController != null && index >= 0 && index < colors.Length)
        {
            spotlightController.ChangeSpotlightColor(colors[index]);
        }
    }
}