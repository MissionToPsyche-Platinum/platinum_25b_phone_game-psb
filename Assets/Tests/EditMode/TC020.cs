using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC020
{
    [Test]
    public void IntermediateLevel_ReturnsCorrectSpeedValues()
    {
        // Set up object
        GameObject obj = new GameObject();
        GameLevels gameLevels = obj.AddComponent<GameLevels>();

        // Check that correct values are returned
        gameLevels.SetLevel("intermediate");
        float minSpeed = gameLevels.GetAsteroidMinSpeed();
        float maxSpeed = gameLevels.GetAsteroidMaxSpeed();
        Assert.AreEqual(0.1f, minSpeed);
        Assert.AreEqual(10f, maxSpeed);

        Object.DestroyImmediate(obj);
    }
}
