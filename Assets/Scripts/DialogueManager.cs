using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Rendering;

public class DialogueManager : MonoBehaviour
{
    [Header("UI 요소 - 인스펙터 창에서 연결")]
    public GameObject DialoguePanel;
    public Image characterImage;
    public TextMeshProUGUI characternameText;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;

    [Header("기본 설정")]
    public Sprite deiaultCharacterImage;

    [Header("타이핑 효과 설정")]
    public float typingSpeed = 0.05f;
    public bool skipTypingOnClick = true;

    private DialogueDaraso currentDialogue;
    private int currentDialogueIndex = 0;
    private bool isDialogueActive = false;
    private bool isTyping = false;
    private Coroutine typingCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerable TypeText(string textTOType)
    {
        isTyping = true;
        dialogueText.text = "";

        for(int i = 0; i < textTOType.Length; i++)
        {
            dialogueText.text += textTOType[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
    private void CompleteTyping()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        isTyping=false;

        if (currentDialogue != null && currentDialogueIndex < currentDialogue.dialogueLines.Count)
        {
            dialogueText.text = currentDialogue.dialogueLines[currentDialogueIndex];
        }
    }
    void ShowCurrentLine()
    {
        if (currentDialogue !=null && currentLineIndex < currentDialogue.dialogueLines.Count)
        {
            if(typingCoroutine !=null)
            {
                StopCoroutine (typingCoroutine);
            }

            string currentText = currentDialogue.dialogueLines[currentDialogueIndex];
            typingCoroutine = StartCoroutine(TypeText(currentText));
        }
    }
    public void ShowNextLine()
    {
        currentLineIndex++;

        if (currentLineIndex >= currentDialogue.dialogueLines.Count)
        {
            EndDialogue();
        }
        else
        {
            ShowCurrentLine();
        }
    }
    void EndDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        isDialogueActive = false;
        isTyping = false;
        DialoguePanel.SetActive(false);
        currentLineIndex = 0;
    }
    public void HandleNextlnupt()
    {
        if (isTyping && skipTypingOnClick)
        {
            CompleteTyping();
        }
        else if (!isTyping)
        {
            ShowCurrentLine();
        }
    }
    public void Skintkrewertwerrttrttrtrtrt
        
}
