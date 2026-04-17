using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TC024
{
    [Test]
    public void GetTrivia_AdvancedLevel_ReturnsAdvancedBank()
    {
        // Set up
        var obj = new GameObject();
        var gameLevels = obj.AddComponent<GameLevels>();

        var advBank = ScriptableObject.CreateInstance<TriviaBankSO>();
        advBank.selectedBankName = "advanced"; // set level of difficulty label

        // Add to list of possible trivia banks
        var field = typeof(GameLevels).GetField("triviaBanks", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(gameLevels, new List<TriviaBankSO> { advBank });

        // Set level to beginner
        gameLevels.SetLevel("advanced");

        // GetTrivia( )
        var result = gameLevels.GetTrivia();

        // Check that correct values are returned
        Assert.AreSame(advBank, result);

        Object.DestroyImmediate(advBank);
        Object.DestroyImmediate(obj);
    }
}