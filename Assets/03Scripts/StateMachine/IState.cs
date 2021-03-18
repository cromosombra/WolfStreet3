﻿using System.Collections;
using UnityEngine;

public interface IState
{
    void Tick();
    void OnEnter();
    void OnExit();
}