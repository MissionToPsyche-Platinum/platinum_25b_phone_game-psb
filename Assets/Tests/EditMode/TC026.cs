using NUnit.Framework;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class TC026
{
    [Test]
    public void TestSetSkin()
    {
        // Test game object set up
        var obj = new GameObject();
        var gameLevels = obj.AddComponent<GameLevels>();
        // Test sprite set up
        var imageGO = new GameObject();
        var image = imageGO.AddComponent<Image>();
        var redSprite = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 4, 4), Vector2.zero);

        typeof(GameLevels).GetField("spacecraftPreview", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameLevels, image);
        typeof(GameLevels).GetField("redPreview",BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameLevels, redSprite);

        // Set spacecraft skin to color red
        gameLevels.SetSkin("red");

        // Check if skin was correctly set
        Assert.AreEqual(redSprite, image.sprite);
        
        // Clean up
        Object.DestroyImmediate(obj);
        Object.DestroyImmediate(imageGO);
    }
}