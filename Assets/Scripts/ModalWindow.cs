using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalWindow : MonoBehaviour
{
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

    private Action onButton1Callback;
    private Action onButton2Callback;
    private Action onButton3Callback;

    public void button1Action()
    {
        onButton1Callback?.Invoke();
        //Close();
    }
    public void button2Action()
    {
        onButton2Callback?.Invoke();
        //Close();
    }
    public void button3Action()
    {
        onButton3Callback?.Invoke();
        //Close();
    }

    public void StoryEvent(string title, Sprite image, string message, string button1message, Action button1action, string button2message = null, Action button2action = null, string button3message = null, Action button3action = null, string input = null)
    {
        // Title
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(!hasTitle);
        _titleText.text = title;

        // Input box
        bool hasInput = string.IsNullOrEmpty(input);
        _inputArea.gameObject.SetActive(!hasInput);
        _inputText.text = input;

        // Content
        _eventImage.sprite = image;
        _eventText.text = message;

        // Buttons
        onButton1Callback = button1Action;
        _button1Text.text = button1message;

        bool hasButton2 = (button2action != null);
        _button2.gameObject.SetActive(hasButton2);
        _button2Text.text = button2message;
        onButton2Callback = button2Action;

        bool hasButton3 = (button3action != null);
        _button3.gameObject.SetActive(hasButton3);
        _button3Text.text = button3message;
        onButton3Callback = button3Action;
    }
}
