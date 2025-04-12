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

    public void UpdateLapText(string message)
    {
        textMeshProUGUI.text = message;
    }

    public void ShowContinueButton(UnityEngine.Events.UnityAction onClickAction)
    {
        if (continueButton != null)
        {
            continueButton.SetActive(true);
            Button btn = continueButton.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(onClickAction);
        }
    }
}
