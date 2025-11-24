using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Base Class to hold Trivia

[System.Serializable]
public class Trivia
{
    public string question;
    public string[] choices;
    // The correct choice goes from 1 to length of choices.
    // DO NOT PUT 0 AS A CORRECT CHOICE.
    public int correctChoice;
}
