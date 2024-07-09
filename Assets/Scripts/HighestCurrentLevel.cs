using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighestCurrentLevel : MonoBehaviour
{
    public static int highestLevel = 1;
    public static int currentLevel = 1;

    public static void SaveHighestLevel(int level)
    {
        if (level > highestLevel)
        {
            highestLevel = level;
        }
    }

    public static int GetHighestLevel()
    {
        return highestLevel;
    }
    public static void SaveCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public static int GetCurrentLevel()
    {
        return currentLevel;
    }
}