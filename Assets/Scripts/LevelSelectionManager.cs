using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    // This should be set from your save data or game logic
    public Button[] levelButtons; // Array to hold all level selection buttons

    void Start()
    {
        int highestLevel = HighestCurrentLevel.GetHighestLevel();
        // Loop through each button and disable if its index is greater than highestLevel
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > highestLevel - 1)
            {
                levelButtons[i].interactable = false; // Disable the button
            }
        }
    }
    void Update()
    {
        int highestLevel = HighestCurrentLevel.GetHighestLevel();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > highestLevel - 1)
            {
                levelButtons[i].interactable = false; // Disable the button
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }
    }
}