using UnityEngine;

public class GameLevels : MonoBehaviour
{
    public static GameLevels Instance { get; private set; }

    private GameObject levelsPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private string level; // can be beginner, intermediate or advanced

    public void SetLevel(string level)
    {
        this.level = level;
    }

    // Returns walk speed corresponding to level chosen by user.
    public float GetWalkSpeed()
    {
        switch (level)
        {
            case "beginner": return 3f;
                break;
            case "intermediate": return 6f;
                break;
            case "advanced": return 9f;
                break;
            default: return 6f;
        }
    }

    // Returns run speed corresponding to level chosen by user.
    public float GetRunSpeed()
    {
        switch (level)
        {
            case "beginner":
                return 9f;
                break;
            case "intermediate":
                return 15f;
                break;
            case "advanced":
                return 21f;
                break;
            default: return 15f;
        }
    }

    public void HidePanel()
    {
        levelsPanel = GameObject.Find("Levels Panel");
        levelsPanel.SetActive(false);
    }
}
