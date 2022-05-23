using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalWindow : MonoBehaviour
{
    // References to UI elements.
    [Header("Header")]
    [SerializeField] private Transform _headerArea;
    [SerializeField] private TextMeshProUGUI _titleText;

    [Header("Content")]
    [SerializeField] private Transform _contentArea;
    [SerializeField] private Image _eventImage;
    [SerializeField] private TextMeshProUGUI _eventText;

    [Header("Input")]
    [SerializeField] private Transform _inputArea;
    [SerializeField] private TextMeshProUGUI _inputText;

    [Header("Footer")]
    [SerializeField] private Transform _footerArea;
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    [SerializeField] private TextMeshProUGUI _button1Text;
    [SerializeField] private TextMeshProUGUI _button2Text;
    [SerializeField] private TextMeshProUGUI _button3Text;

    // Callbacks
    private Action onButton1Callback;
    private Action onButton2Callback;
    private Action onButton3Callback;

    // Actions
    private Action button1Action;
    private Action button2Action;
    private Action button3Action;

    public void Button1()
    {
        onButton1Callback?.Invoke();
        //Close();
    }
    public void Button2()
    {
        onButton2Callback?.Invoke();
        //Close();
    }
    public void Button3()
    {
        onButton3Callback?.Invoke();
        //Close();
    }

    public void StoryEvent(string title, Sprite image, string message, string button1Tag, Action button1Action, string button2Tag = null, Action button2Action = null, string button3Tag = null, Action button3Action = null, string inputTag = null)
    {
        // Title
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(!hasTitle);
        _titleText.text = title;

        // Input box
        bool hasInput = string.IsNullOrEmpty(inputTag);
        _inputArea.gameObject.SetActive(!hasInput);
        _inputText.text = inputTag;

        // Content
        _eventImage.sprite = image;
        _eventText.text = message;

        // Buttons
        onButton1Callback = button1Action;
        _button1Text.text = button1Tag;

        bool hasButton2 = (button2Action != null);
        _button2.gameObject.SetActive(hasButton2);
        _button2Text.text = button2Tag;
        onButton2Callback = button2Action;

        bool hasButton3 = (button3Action != null);
        _button3.gameObject.SetActive(hasButton3);
        _button3Text.text = button3Tag;
        onButton3Callback = button3Action;
    }

    //public void StoryEvent(string title, Sprite image, string message, Action button1Action, Action button2Action = null, Action button3Action = null)
    //{
    //    // Title
    //    bool hasTitle = string.IsNullOrEmpty(title);
    //    _headerArea.gameObject.SetActive(!hasTitle);
    //    _titleText.text = title;

    //    // Input box
    //    _inputArea.gameObject.SetActive(false);

    //    // Content
    //    _eventImage.sprite = image;
    //    _eventText.text = message;

    //    // Buttons
    //    onButton1Callback = button1Action;
    //    _button1Text.text = "Confirm";

    //    _button2Text.text = "Cancel";
    //    onButton2Callback = button2Action;

    //    bool hasButton3 = (button3Action != null);
    //    _button3.gameObject.SetActive(hasButton3);
    //    _button3Text.text = "Alternate";
    //    onButton3Callback = button3Action;
    //}
}
