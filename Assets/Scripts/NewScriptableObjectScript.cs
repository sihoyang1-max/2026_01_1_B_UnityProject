using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class DialogueDaraso : ScriptableObject
{
    [Header("캐릭터 정보")]
    public string characterName = "캐릭터";
    public Sprite charaterImage;

    [Header("대화 내용")]
    [TextArea(3, 10)]
    public List<string> dialogueLines = new List<string>();
}
