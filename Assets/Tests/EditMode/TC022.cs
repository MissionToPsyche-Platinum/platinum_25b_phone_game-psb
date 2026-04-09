using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC022
{
    [Test]
    public void AdvancedLevel_ReturnsCorrectAsteroidSpawnTimes()
    {
        // Set up object
        GameObject obj = new GameObject();
        GameLevels gameLevels = obj.AddComponent<GameLevels>();

        // Check that correct values are returned
        gameLevels.SetLevel("advanced");
        float minTime = gameLevels.GetAsteroidSpawnTimeMin();
        float maxTime = gameLevels.GetAsteroidSpawnTimeMax();
        Assert.AreEqual(1.5f, minTime);
        Assert.AreEqual(3f, maxTime);

        Object.DestroyImmediate(obj);
    }
}
