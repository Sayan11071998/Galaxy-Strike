using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] private string[] timelineTextLines;
    [SerializeField] private TMP_Text dialogueText;

    private int currentLine = 0;

    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = timelineTextLines[currentLine];
    }
}