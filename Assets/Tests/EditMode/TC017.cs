using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC017
{
    [Test]
    public void BeginnerLevel_ReturnsCorrectSpeedValues()
    {
        // Set up object
        GameObject obj = new GameObject();
        GameLevels gameLevels = obj.AddComponent<GameLevels>();

        // Check that correct values are returned
        gameLevels.SetLevel("beginner");
        float minSpeed = gameLevels.GetAsteroidMinSpeed();
        float maxSpeed = gameLevels.GetAsteroidMaxSpeed();
        Assert.AreEqual(0.1f, minSpeed);
        Assert.AreEqual(6f, maxSpeed);

        Object.DestroyImmediate(obj);
    }
}