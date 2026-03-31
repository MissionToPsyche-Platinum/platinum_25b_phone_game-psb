using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTriviaBank", menuName = "Trivia/Trivia Bank")]
public class TriviaBankSO : ScriptableObject
{
    public List<Trivia> questions;
    [SerializeField] public string selectedBankName;
}
