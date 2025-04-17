using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject textbackground;
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject continueButton;

    private UnityEngine.Events.UnityAction currentContinueAction;
    private bool isContinueButtonVisible = false;

    void Start()
    {
        if (continueButton != null)
        {
            continueButton.SetActive(false);
        }
        textMeshProUGUI.text = "";
    }

    public void showUI(bool showUI)
    {
        this.textbackground.SetActive(showUI);
    }

    void Update()
    {
        if (isContinueButtonVisible && Input.GetKeyDown(KeyCode.Return))
        {
            currentContinueAction?.Invoke();
        }
    }

    public void UpdateLapText(string message)
    {
        textMeshProUGUI.text = message;
    }

    public void ShowContinueButton(UnityEngine.Events.UnityAction onClickAction)
    {
        if (continueButton != null)
        {
            continueButton.SetActive(true);
            isContinueButtonVisible = true;
            currentContinueAction = onClickAction;

            Button btn = continueButton.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(onClickAction);
        }
    }

    public void hideContinueButton()
    {
        if (continueButton != null)
        {
            continueButton.SetActive(false);
            isContinueButtonVisible = false;
            currentContinueAction = null;
        }

        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = "";

            Transform background = textMeshProUGUI.transform.parent.Find("TextBackground");
            if (background != null)
            {
                background.gameObject.SetActive(false);
            }
        }
    }
}
