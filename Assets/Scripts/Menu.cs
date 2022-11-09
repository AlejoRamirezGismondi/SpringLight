using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private bool _isOpen;

    public void Start()
    {
        Close();
    }

    public void Open()
    {
        _isOpen = true;
        gameObject.SetActive(true);
        PauseManager.Pause();
    }

    public void Close()
    {
        _isOpen = false;
        gameObject.SetActive(false);
        PauseManager.Resume();
    }
}
