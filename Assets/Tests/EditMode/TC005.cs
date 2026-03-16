using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections.Generic; // for use of HashSet

public class TC005
{
    private class TestPowerUpManager : PowerUpManager
    {
        public GameObject lastPrefab; // tracks created power-ups

        protected override GameObject CreatePowerUp(GameObject prefab, Vector3 pos)
        {
            lastPrefab = prefab;
            return new GameObject("SpawnedPowerUp");
        }
    }

    [Test]
    public void TypeChangesAcrossCalls()
    {
        // set up manager
        var go = new GameObject("PowerUpManager");
        var manager = go.AddComponent<TestPowerUpManager>();

        manager.powerUpList = new GameObject[]
        {
            // five power-ups 0-4
            new GameObject("PU0"),
            new GameObject("PU1"),
            new GameObject("PU2"),
            new GameObject("PU3"),
            new GameObject("PU4")
        };

        HashSet<GameObject> pUTypes = new HashSet<GameObject>();

        // Spawn PUs 10 times to check for different types
        // Add types to hashset for testing
        for (int i = 0; i < 20; i++)
        {
            manager.SpawnPowerUp();
            pUTypes.Add(manager.lastPrefab);
        }

        // Test if more than one type of PU was spawned
        Assert.Greater(pUTypes.Count, 1, $"Expected more than one power-up type to appear, but only saw {pUTypes.Count} type(s).");

    }
}
