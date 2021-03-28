using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContainerBase<T> : MonoBehaviour
{
    protected HashSet<T> items = new HashSet<T>();

    internal HashSet<T> GetAllItems()
    {
        return items;
    }

    internal void AddItem(T item)
    {
        if (!items.Contains(item))
            items.Add(item);
    }

    internal void RemoveItem(T item)
    {
        items.Remove(item);
    }
}
