using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC007 
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
    public void PositionChangesAcrossCalls()
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

        /* Call spawn function twice
         * 1. Verify x and y are in bounds (from TC003).
         * 2. Compare positions.         
         */

        manager.SpawnPowerUp();
        Vector3 p1 = manager.lastPosition;

        // test if x and y are in bounds
        Assert.That(p1.x, Is.InRange(minX, maxX), $"X out of bounds: {p1.x}");
        Assert.That(p1.y, Is.InRange(minY, maxY), $"Y out of bounds: {p1.y}");
        Assert.AreEqual(0f, p1.z, "Z is expected to be 0");

        manager.SpawnPowerUp();
        Vector3 p2 = manager.lastPosition;

        // test if x and y are in bounds
        Assert.That(p2.x, Is.InRange(minX, maxX), $"X out of bounds: {p2.x}");
        Assert.That(p2.y, Is.InRange(minY, maxY), $"Y out of bounds: {p2.y}");
        Assert.AreEqual(0f, p2.z, "Z is expected to be 0");

        // TEST if x and y are different between the two calls
        bool different = !Mathf.Approximately(p1.x, p2.x) || !Mathf.Approximately(p1.y, p2.y);

        Assert.IsTrue(different, $"Got same spawn positions: {p1} and {p2}");
    }
}
