using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModel
{
    public void OnModelChanged();
    public string GetModelName();
}
