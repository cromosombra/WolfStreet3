﻿using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public event Action<int> HotkeyPressed;
    public event Action MoveModeTogglePressed;
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");

    public float MouseX => Input.GetAxis("Mouse X");

    public bool PausePressed => Input.GetKeyDown(KeyCode.Escape);
    public Vector2 MousePosition => Input.mousePosition;
    public bool GetKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);


    private void Update()
    {
        Tick();
    }

    public void Tick()
    {
        if (MoveModeTogglePressed != null && Input.GetKeyDown(KeyCode.Minus))
            MoveModeTogglePressed();
        
        if (HotkeyPressed == null)
            return;

        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                HotkeyPressed(i);
            }
        }
    }
}