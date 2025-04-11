using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject continueButton;

    void Start()
    {
        if (continueButton != null)
        {
            continueButton.SetActive(false);
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
