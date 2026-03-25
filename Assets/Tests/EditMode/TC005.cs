using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC005 
{
    private class TestPowerUpManager : PowerUpManager
    {
        public GameObject lastCreated;

        public override GameObject CreatePowerUp(GameObject prefab, Vector3 pos)
        {
            Debug.Log("CreatePowerUp WAS CALLED");

            lastCreated = new GameObject("SpawnedPowerUp");
            Debug.Log("lastCreated is null? " + (lastCreated == null));
            return lastCreated;
        }
    }

    [Test]
    public void SpawnPowerUp()
    {
        var go = new GameObject();
        var manager = go.AddComponent<TestPowerUpManager>();

        var boundsObject = new GameObject("Bounds");
        var boundsCollider = boundsObject.AddComponent<BoxCollider2D>();
        boundsCollider.size = new Vector2(10f, 10f);

        manager.gameplayBounds = boundsCollider;

        manager.powerUpList = new GameObject[]
        {
        new GameObject("PU0"),
        new GameObject("PU1"),
        new GameObject("PU2"),
        };

        try
        {
            manager.SpawnPowerUp();
        }
        catch (System.Exception ex)
        {
            Assert.Fail("SpawnPowerUp threw an exception: " + ex);
        }

        Debug.Log("Before assert, lastCreated is null? " + (manager.lastCreated == null));
        Assert.IsNotNull(manager.lastCreated, "SpawnPowerUp did not create a power-up");
    }
}
