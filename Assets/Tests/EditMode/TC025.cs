using System.Collections;
using NUnit.Framework;
using UnityEngine;
using System.Reflection;
using UnityEngine.TestTools;

public class TC025
{
    [Test]
    public void ActivatesSkinsPanel()
    {
        // Game object set up
        var obj = new GameObject();
        var gameLevels = obj.AddComponent<GameLevels>();
        // Panels set up
        var skinsPanel = new GameObject();
        var levelsPanel = new GameObject(); 
        // Assert panel is inactive at game start
        skinsPanel.SetActive(false);

        typeof(GameLevels).GetField("skinsPanel", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameLevels, skinsPanel);
        typeof(GameLevels).GetField("levelsPanel", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameLevels, levelsPanel);

        // Run PickSkin( ) which should active panel
        gameLevels.PickSkin();

        // Check if panel was correctly activated
        Assert.IsTrue(skinsPanel.activeSelf);

        Object.DestroyImmediate(obj);
    }
}
