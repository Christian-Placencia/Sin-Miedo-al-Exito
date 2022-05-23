using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowTrigger : MonoBehaviour
{
    public string title;
    public Sprite image;
    public string message;
    public bool triggerOnEnable = true;

    public void OnEnable()
    {
        if (!triggerOnEnable) { return; }

        // if (onbutton1Action.GetPErsistentEventCount() > 0 )


        //UIController.instance.modalWindow.ShowModalMessage(title, image, message, null, null);
    }

    public UnityEvent onAction1Callback;
    public UnityEvent onAction2Callback;
}
