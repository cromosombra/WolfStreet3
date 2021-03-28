using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerBase : MonoBehaviour
{
    public abstract void Interact(string command, IModel model, params IModelParameters[] parameters);
}
