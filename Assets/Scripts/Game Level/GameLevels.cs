using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameLevels : MonoBehaviour
{
    public static GameLevels Instance { get; private set; }

    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private List<TriviaBankSO> triviaBanks;
    [SerializeField] private GameObject skinsPanel;

    // skins panel fields
    [SerializeField] private Image spacecraftPreview;
    [SerializeField] private Sprite defaultPreview; // default = blue
    [SerializeField] private Sprite redPreview;
    [SerializeField] private Sprite greenPreview;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        skinsPanel.SetActive(false); // skins panel is initially inactive
    }

    private string level; // can be beginner, intermediate or advanced
    private string skinColor; // red, blue or green

    public void SetLevel(string level)
    {
        this.level = level;
    }

    public string GetLevel()
    {
        return level;
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

    // Returns correct trivia bank
    public TriviaBankSO GetTrivia()
    {
        TriviaBankSO selectedBank = triviaBanks.Find(bank => bank.selectedBankName == level);

        return selectedBank;
    }

    public void PickSkin()
    {
        // Activate skins panel
        levelsPanel.SetActive(false);
        skinsPanel.SetActive(true);
    }

    public void SetSkin(string color)
    {
        this.skinColor = color;
        switch(color)
        {
            case "red": spacecraftPreview.sprite = redPreview; 
                break;
            case "green":
                spacecraftPreview.sprite = greenPreview;
                break;
            default:
                spacecraftPreview.sprite = defaultPreview;
                break;
        }
    }

    public string GetSkin()
    {
        if (skinColor != null)
        {
            return skinColor;
        }
        return "blue"; // default color is blue
    }
}
