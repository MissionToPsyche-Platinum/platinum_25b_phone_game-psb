using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC016
{
    [Test]
    public void BeginnerLevel_ReturnsCorrectAsteroidSpawnTimes()
    {
        // Set up object
        GameObject obj = new GameObject();
        GameLevels gameLevels = obj.AddComponent<GameLevels>();

        // Check that correct values are returned
        gameLevels.SetLevel("beginner");
        float minTime = gameLevels.GetAsteroidSpawnTimeMin();
        float maxTime = gameLevels.GetAsteroidSpawnTimeMax();
        Assert.AreEqual(4f, minTime);
        Assert.AreEqual(8f, maxTime);

        Object.DestroyImmediate(obj);
    }
}
