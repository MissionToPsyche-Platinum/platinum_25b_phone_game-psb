using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Returns asteroidSpawnTimeMin corresponding to level chosen by user.
    public float GetAsteroidSpawnTimeMin()
    {
        switch (level)
        {
            case "beginner": return 4f;
            case "intermediate": return 3f;
            case "advanced": return 1.5f;
            default: return 3f;
        }
    }

    // Returns asteroidSpawnTimeMax corresponding to level chosen by user.
    public float GetAsteroidSpawnTimeMax()
    {
        switch (level)
        {
            case "beginner": return 8f;
            case "intermediate": return 6f;
            case "advanced": return 3f;
            default: return 6f;
        }
    }

    // Returns asteroid min speed corresponding to level chosen by user.
    public float GetAsteroidMinSpeed()
    {
        switch (level)
        {
            case "beginner": return 0.1f;
            case "intermediate": return 0.1f;
            case "advanced": return 0.1f;
            default: return 0.1f;
        }
    }

    // Returns asteroid max speed corresponding to level chosen by user.
    public float GetAsteroidMaxSpeed()
    {
        switch (level)
        {
            case "beginner": return 6f;
            case "intermediate": return 10f;
            case "advanced": return 15f;
            default: return 10f;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
