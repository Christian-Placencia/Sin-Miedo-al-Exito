using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Singleton pattern
    public static UIController instance;
    [SerializeField] private ModalWindow _modalWindow;
    public ModalWindow modalWindow => _modalWindow;

    private void Awake()
    {
        instance = this;
    }

}
