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

    // public���� �����Ͽ� �ܺο��� ���� �����ϵ��� ��
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
                float delay = 2f; // ��ȭ�� ǥ�õ� �� 2�ʰ� ��� (���ϴ� �ð����� ���� ����)

                while (timer < delay)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
            }
        }
        dialogueText.text = dialogueObject.dialogueLines[0].dialogue;

        // ���� ��ȭ ǥ��
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
            // ��� ��ȭ�� ������ ���ϴ� ���� ����
            Debug.Log("��� ��ȭ�� ����Ǿ����ϴ�.");
            dialogueBox.SetActive(false);
        }
    }
}
