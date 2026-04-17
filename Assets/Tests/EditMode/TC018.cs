using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TC018
{
    [Test]
    public void GetTrivia_BeginnerLevel_ReturnsBeginnerBank()
    {
        // Set up
        var obj = new GameObject();
        var gameLevels = obj.AddComponent<GameLevels>();

        var beginnerBank = ScriptableObject.CreateInstance<TriviaBankSO>();
        beginnerBank.selectedBankName = "beginner"; // set level of difficulty label

        // Add to list of possible trivia banks
        var field = typeof(GameLevels).GetField("triviaBanks", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(gameLevels, new List<TriviaBankSO> { beginnerBank });

        // Set level to beginner
        gameLevels.SetLevel("beginner"); 

        // GetTrivia( )
        var result = gameLevels.GetTrivia();

        // Check that correct values are returned
        Assert.AreSame(beginnerBank, result);

        Object.DestroyImmediate(beginnerBank);
        Object.DestroyImmediate(obj);
    }
}