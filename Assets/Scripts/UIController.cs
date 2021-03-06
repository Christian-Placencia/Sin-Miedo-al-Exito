using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Singleton pattern
    public static UIController instance;
    [SerializeField] private ModalWindow _storyWindow;
    public ModalWindow storyWindow => _storyWindow;

    //[SerializeField] private ModalWindow _modalWindow;
    //public ModalWindow modalWindow => _modalWindow;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);

        //instance.storyWindow.StoryEvent("UI Controller Test", null, "The UI Controller Works", "Okay", null, "Cancel", null, "Revise", null, "Input also works");
    }
}
