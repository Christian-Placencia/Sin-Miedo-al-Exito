using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvent : MonoBehaviour
{
    // Inpsector variables
    [SerializeField] private string message;
    [SerializeField] private string option1;
    [SerializeField] private string option2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager.Instance.ChangeHeader(message);
        //GameManager.Instance.ChangeButton(1, option1);
        //GameManager.Instance.ChangeButton(2, option2);
    }
}
