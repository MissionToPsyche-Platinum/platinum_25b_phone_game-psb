using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC019
{
    [Test]
    public void IntermediateLevel_ReturnsCorrectAsteroidSpawnTimes()
    {
        // Set up object
        GameObject obj = new GameObject();
        GameLevels gameLevels = obj.AddComponent<GameLevels>();

        // Check that correct values are returned
        gameLevels.SetLevel("intermediate");
        float minTime = gameLevels.GetAsteroidSpawnTimeMin();
        float maxTime = gameLevels.GetAsteroidSpawnTimeMax();
        Assert.AreEqual(3f, minTime);
        Assert.AreEqual(6f, maxTime);

        Object.DestroyImmediate(obj);
    }
}
