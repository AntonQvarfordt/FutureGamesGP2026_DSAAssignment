using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;
using NUnit.Framework;
using System.Collections.Generic;

public class ComputerInput : MonoBehaviour {
    public InputAction SubmitAction;
    public bool IsOpen = false;
    public int TextLineHeight = 20;
    public GameObject TextPrefab;
    public TMP_InputField Input;
    public TMP_Text TextPrint;
    public Transform TextLineContrainer;
    public List<TextLine> TextLines = new List<TextLine>();
    public RectTransform TextLinesRect;
    public bool AllowInput;

    private void OnEnable() {
        // Input.onEndEdit.AddListener(SubmitInput);
        SubmitAction.Enable();

    }
    private void OnDisable() {
        //  Input.onEndEdit.RemoveAllListeners();
        SubmitAction.Disable();
    }

    private void Awake() {
        Debug.Log(TextLinesRect.GetScreenRect().height);
        SubmitAction.performed += SubmitInput;
    }

    public void Open () {
        gameObject.SetActive(true);
        Input.ActivateInputField();

        GameManager.Instance.DisablePlayerInput();
        IsOpen = true;
    }

    public void Close() {
        gameObject.SetActive(false);
        IsOpen = false;
        GameManager.Instance.EnablePlayerInput();
    }

    public void SubmitInput(InputAction.CallbackContext cb) {
        var subString = Input.text;
        if(string.IsNullOrEmpty(subString))
            return;

        if (subString.ToLower() == "close") {
            Close();
            Input.text = "";
            return;
        }

        Debug.Log(subString);
        AddLine(subString);
        Input.ActivateInputField();
    }

    private void AddLine(string line) {
        var newLine = Instantiate(TextPrefab);
        newLine.transform.SetParent(TextLineContrainer, false);
        var rect = newLine.GetComponent<RectTransform>();
        //rect.SetLocalTop(GetYPosForText());
        var txtComp = newLine.GetComponent<TextLine>();
        txtComp.Line = line;
        newLine.GetComponent<TextMeshProUGUI>().text = line;
        TextLines.Add(txtComp);
        var yPos = GetYPosForText();
        Debug.Log(yPos);
        rect.anchoredPosition = new Vector2(0, yPos);
        Input.text = "";

    }

    private float GetActiveHeight() {
        return (TextLines.Count-1) * TextLineHeight;
    }

    private float GetYPosForText() {
        var linesHeight = GetActiveHeight();
        var maxHeight = TextLinesRect.GetScreenRect().height - TextLineHeight;
        Debug.Log("MaxHeight: " + maxHeight);
        if(linesHeight > maxHeight) {
            MoveAllUp();
            return -maxHeight;
        }
        return -GetActiveHeight();
    }

    private void MoveAllUp() {
        Debug.Log("MoveUp");
        foreach(TextLine txtObj in TextLines) {
            var anchorPos = txtObj.GetComponent<RectTransform>().anchoredPosition;
            anchorPos.y += TextLineHeight;
            txtObj.GetComponent<RectTransform>().anchoredPosition = anchorPos;
        }
    }
}
