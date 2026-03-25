using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC006 
{
    private class TestPowerUpManager : PowerUpManager
    {
        public Vector3 lastPosition;

        public override GameObject CreatePowerUp(GameObject prefab, Vector3 pos)
        {
            lastPosition = pos;
            return new GameObject("SpawnedPowerUp");
        }
    }

    [Test]
    public void SpawnedInBounds()
    {
        //// set up a fake camera
        var camGO = new GameObject("MainCamera");
        camGO.tag = "MainCamera";
        var cam = camGO.AddComponent<Camera>();
        cam.orthographic = true;
        // test values are same as project settings
        cam.orthographicSize = 5f;      
        cam.aspect = 10f / 16f;
        // save values
        float ortho = cam.orthographicSize;
        float aspect = cam.aspect;
        float minX = -ortho * aspect;
        float maxX = ortho * aspect;
        float minY = -ortho;
        float maxY = ortho;

        // set up manager
        var go = new GameObject("PowerUpManager");
        var manager = go.AddComponent<TestPowerUpManager>();

        var boundsObject = new GameObject("Bounds");
        var boundsCollider = boundsObject.AddComponent<BoxCollider2D>();
        boundsCollider.size = new Vector2(10f, 10f);

        manager.gameplayBounds = boundsCollider;

        manager.powerUpList = new GameObject[]
        {
            // five power-ups 0-4
            new GameObject("PU0"),
            new GameObject("PU1"),
            new GameObject("PU2"),
            new GameObject("PU3"),
            new GameObject("PU4")
        };

        manager.SpawnPowerUp();
        Vector3 p = manager.lastPosition;

        // test if x and y are in bounds
        Assert.That(p.x, Is.InRange(minX, maxX), $"X out of bounds: {p.x}");
        Assert.That(p.y, Is.InRange(minY, maxY), $"Y out of bounds: {p.y}");
        Assert.AreEqual(0f, p.z, "Z is expected to be 0");
    }
}
