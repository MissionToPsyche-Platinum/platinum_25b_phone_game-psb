using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC005 
{
    private class TestPowerUpManager : PowerUpManager
    {
        public GameObject lastCreated;

        protected override GameObject CreatePowerUp(GameObject prefab, Vector3 pos)
        {
            lastCreated = new GameObject("SpawnedPowerUp");
            return lastCreated;
        }
    }

    [Test]
    public void SpawnPowerUp()
    {
        // set up game object and manager
        var go = new GameObject();
        var manager = go.AddComponent<TestPowerUpManager>();

        manager.powerUpList = new GameObject[]
        {
            // three power-ups 0-2
            new GameObject("PU0"), 
            new GameObject("PU1"),
            new GameObject("PU2"),
        };

        // checks if spawned
        manager.SpawnPowerUp();
        Assert.IsNotNull(manager.lastCreated, "SpawnPowerUp did not create a power-up");
    }
}
