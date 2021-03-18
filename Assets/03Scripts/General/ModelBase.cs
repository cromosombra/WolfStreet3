using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelBase<T> : IModel
{
    public ModelBase(T value)
    {
        data = value;
    }

    public ModelBase(T value, string name)
    {
        this.data = value;
        modelName = name;
    }

    private string modelName;
    public Action<T> modelChanged;
    private T data;

    public void SetData(T data)
    {
        this.data = data;
    }

    public T GetData()
    {
        return data;
    }

    public virtual void OnModelChanged()
    {
        modelChanged?.Invoke(this.data);
    }

    public string GetModelName()
    {
        return modelName;
    }

    public void SetModelName(string name)
    {
        modelName = name;
    }
}
