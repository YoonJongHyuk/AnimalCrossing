using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    public enum DisplayMode
    {
        MouseClick,
        Auto
    }

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;

    private int currentDialogueIndex = 0;

    // public으로 변경하여 외부에서 접근 가능하도록 함
    public DialogueObject[] dialogueObjects;

    [SerializeField] private DisplayMode displayMode = DisplayMode.MouseClick;

    private void Start()
    {
        ResetDialogue();
    }

    public void ResetDialogue()
    {
        currentDialogueIndex = 0;
        StopAllCoroutines();

        DisplayNextDialogue();
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

            if (displayMode == DisplayMode.MouseClick)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return null;
            }
            else if (displayMode == DisplayMode.Auto)
            {
                float timer = 0f;
                float delay = 2f; // 대화가 표시된 후 2초간 대기 (원하는 시간으로 조절 가능)

                while (timer < delay)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
            }
        }
        dialogueText.text = dialogueObject.dialogueLines[0].dialogue;

        // 다음 대화 표시
        DisplayNextDialogue();
    }

    private void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueObjects.Length)
        {
            DialogueObject nextDialogue = dialogueObjects[currentDialogueIndex];
            currentDialogueIndex++;
            StartCoroutine(MoveThroughDialogue(nextDialogue));
        }
        else
        {
            // 모든 대화가 끝나면 원하는 동작 수행
            Debug.Log("모든 대화가 종료되었습니다.");
            dialogueBox.SetActive(false);
        }
    }
}
