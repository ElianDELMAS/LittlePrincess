using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class InkDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Button[] answerButtons;

    private Story currentStory;
    public TextAsset inkJsonAsset;

    private int selectedChoiceIndex = 0;
    private FirstPersonController firstPersonController;

    private void Start()
    {
        dialoguePanel.SetActive(false);
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    public void StartDialogue()
    {
        if (inkJsonAsset == null)
        {
            Debug.LogError("Aucun fichier Ink trouvé!");
            return;
        }

        firstPersonController.activateFreezePlayer(true);
        currentStory = new Story(inkJsonAsset.text);
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void Update()
    {
        if (dialoguePanel.activeSelf)
        {
            HandleKeyboardInput();
        }
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSelection(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectChoice();
        }
    }

    private void ChangeSelection(int direction)
    {
        int totalChoices = currentStory.currentChoices.Count;
        selectedChoiceIndex = (selectedChoiceIndex + direction + totalChoices) % totalChoices;

        UpdateButtonSelection();
    }

    private void UpdateButtonSelection()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            ColorBlock colors = answerButtons[i].colors;
            colors.normalColor = (i == selectedChoiceIndex) ? Color.yellow : Color.white;
            answerButtons[i].colors = colors;
        }
    }

    private void SelectChoice()
    {
        answerButtons[selectedChoiceIndex].onClick.Invoke();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            EndDialogue();
            return;
        }

        DisplayChoices();
    }

    private void DisplayChoices()
    {
        int choiceCount = currentStory.currentChoices.Count;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < choiceCount)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentStory.currentChoices[i].text;
                int choiceIndex = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => ChooseOption(choiceIndex));
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }

        selectedChoiceIndex = 0;
        UpdateButtonSelection();
    }

    public void ChooseOption(int index)
    {
        currentStory.ChooseChoiceIndex(index);
        ContinueStory();
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        firstPersonController.activateFreezePlayer(false);
    }
}
