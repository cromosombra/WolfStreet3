using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelParameters<T> : IModelParameters
{
    private T data;
    
    public bool Equals(IModelParameters other)
    {
        if (other is T)
        {
            return ((T)other).Equals(data);
        }
        else
        {
            return false;
        }
    }

    public void SetData(T data)
    {
        this.data = data;
    }

    public T GetData()
    {
        return data;
    }
}
