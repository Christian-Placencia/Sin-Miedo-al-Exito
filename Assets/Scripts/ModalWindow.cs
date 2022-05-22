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
    [SerializeField] private TextMeshProUGUI _titleField;

    [Header("Content")]
    [SerializeField] private Transform _contentArea;
    [SerializeField] private Image _eventImage;
    [SerializeField] private TextMeshProUGUI _eventText;

    [Header("Footer")]
    [SerializeField] private Transform _footerArea;
    [SerializeField] private Button _Button1;
    [SerializeField] private Button _Button2;

    private UnityAction button1Action;
    private UnityAction button2Action;

    public void Action1()
    {
        button1Action?.Invoke();
        //Close();
    }
    public void Action2()
    {
        button2Action?.Invoke();
        //Close();
    }

    public void ShowModalMessage(string title, Sprite image, string message, UnityAction button1Action, UnityAction button2Action = null)
    {
        // Hide header if there's no title
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(hasTitle);

        _eventImage.sprite = image;
        _eventText.text = message;

        // onAction1Callback = button1Action;

        bool hasButon2 = (button2Action != null);
        _Button2.gameObject.SetActive(hasButon2);
        // onAction2Callback = button2Action;
    }
}
