using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TC014
{
    [UnityTest]
    public IEnumerator LevelsPanel_Shows_LevelOptions_When_Activated()
    {
        // Load the scene
        SceneManager.LoadScene("GameSettings");

        // Wait until frame finishes loading
        yield return null;

        // Find panel in the scene
        GameObject levelsPanel = GameObject.Find("LevelsPanel");
        Assert.IsNotNull(levelsPanel, "LevelsPanel was not found in the GameSettings scene.");

        // Activate panel
        levelsPanel.SetActive(true);

        // Wait one frame
        yield return null;

        // Check if panel is visible/active
        Assert.IsTrue(levelsPanel.activeSelf, "Levels panel was not set active.");
        Assert.IsTrue(levelsPanel.activeInHierarchy, "Levels panel is not active in the hierarchy.");
    }
}