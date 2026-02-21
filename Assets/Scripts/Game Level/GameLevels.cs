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

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
