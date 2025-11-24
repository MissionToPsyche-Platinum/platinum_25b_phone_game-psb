using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardEntryUI : MonoBehaviour
{
    public TextMeshProUGUI entryScoreText = null;

    public void Initialize(ScoreboardEntryData scoreboardEntryData)
    {
        entryScoreText.text = scoreboardEntryData.entryScore.ToString();
    }
}


