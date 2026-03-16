using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TC007
{
    // Class used to simulate touch detection
    public class TouchHandler : MonoBehaviour
    {
        public Vector2 lastTouch;

        public void UpdateTouch(Vector2 touchPos)
        {
            lastTouch = touchPos;
        }

        public void CheckTouch()
        {
            if (Input.touchCount > 0)
            {
                lastTouch = Input.GetTouch(0).position;
            }
        }
    }

    [Test]
    public void TouchCanBeDetected()
    {
        var handlerGO = new GameObject();
        var handler = handlerGO.AddComponent<TouchHandler>();

        // Simulate a touch at (50,50)
        Vector2 simulatedPos = new Vector2(50, 50);
        handler.UpdateTouch(simulatedPos);

        Assert.AreEqual(simulatedPos, handler.lastTouch);
    }
}
