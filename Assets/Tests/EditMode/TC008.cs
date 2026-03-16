using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC008
{
    public GameObject joystickObject;
    public Joystick joystick;

    [SetUp]
    public void Setup()
    {
        // * joystick component setup *
        joystickObject = new GameObject("Joystick");
        joystick = joystickObject.AddComponent<Joystick>();
        // background and handle
        var bgObj = new GameObject("Background", typeof(RectTransform));
        var handleObj = new GameObject("Handle", typeof(RectTransform));
        joystick.background = bgObj.GetComponent<RectTransform>();
        joystick.handle = handleObj.GetComponent<RectTransform>();
        // set size
        joystick.background.sizeDelta = new Vector2(200, 200);

        joystick.Start();
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(joystickObject);
    }

    [Test]
    public void CanDetectJoystickDrag()
    {
        // Simulate drag to the right
        joystick.SetDirectionForTest(Vector2.right);
        // Test if movement vectors were correctly updated with drag
        Assert.AreEqual(1f, joystick.Direction.x, 0.01f, "Joystick should register movement to the right");
        Assert.AreEqual(0f, joystick.Direction.y, 0.01f);

        // Simulate release
        // Test if movement vectors were correctly updated upon release
        joystick.SetDirectionForTest(Vector2.zero); // release
        Assert.AreEqual(0f, joystick.Direction.x, 0.01f, "Joystick should reset after release");
        Assert.AreEqual(0f, joystick.Direction.y, 0.01f);
    }
}
