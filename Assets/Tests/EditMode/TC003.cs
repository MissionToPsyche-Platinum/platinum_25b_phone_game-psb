using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC003
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
    public void Test_Movement()
    {
        joystick.SetDirectionForTest(new Vector2(0, 1)); // (0,1)
        Assert.AreEqual(1, joystick.Direction.y, 0.01f);
    }
}
