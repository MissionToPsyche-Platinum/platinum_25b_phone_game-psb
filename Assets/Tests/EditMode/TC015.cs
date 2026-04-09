using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC015
{
    [Test]
    public void SetLevel_SetsLevelCorrectly()
    {
        GameObject obj = new GameObject();
        GameLevels gameLevels = obj.AddComponent<GameLevels>();

        // Verify logic for setting level
        gameLevels.SetLevel("beginner");
        Assert.AreEqual("beginner", gameLevels.GetLevel());
    }
}
