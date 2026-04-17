using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TC021
{
    [Test]
    public void GetTrivia_IntermediateLevel_ReturnsIntermediateBank()
    {
        // Set up
        var obj = new GameObject();
        var gameLevels = obj.AddComponent<GameLevels>();

        var intBank = ScriptableObject.CreateInstance<TriviaBankSO>();
        intBank.selectedBankName = "intermediate"; // set level of difficulty label

        // Add to list of possible trivia banks
        var field = typeof(GameLevels).GetField("triviaBanks", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(gameLevels, new List<TriviaBankSO> { intBank });

        // Set level to beginner
        gameLevels.SetLevel("intermediate");

        // GetTrivia( )
        var result = gameLevels.GetTrivia();

        // Check that correct values are returned
        Assert.AreSame(intBank, result);

        Object.DestroyImmediate(intBank);
        Object.DestroyImmediate(obj);
    }
}