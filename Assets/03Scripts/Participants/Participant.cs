using UnityEngine;
using System.Collections.Generic;
public class Participant 
{
    [System.NonSerialized]
    public string pName;
    [System.NonSerialized]
    public float money;
    [System.NonSerialized]
    public Sprite avatar;
    [System.NonSerialized]
    public Enums.Sector sector;
    [System.NonSerialized]
    public Dictionary<string, ShareBlock> shares = new Dictionary<string, ShareBlock>();
}
