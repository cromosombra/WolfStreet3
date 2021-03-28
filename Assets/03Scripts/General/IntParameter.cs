using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntParameter : ModelParameters<int>
{
    protected override bool Equals(int other)
    {
        return data == other;
    }
}
