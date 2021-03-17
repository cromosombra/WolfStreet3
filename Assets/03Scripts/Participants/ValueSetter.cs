using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ValueSetter  
{
   
    //public static Action<string, int, float, Sprite> 
    
    public static float NewStockValue(Company comp)
    {
        var trend = comp.trend;
        var trendBonus = new float();
        switch (trend)
        {
            case Enums.Trendtype.Up:
                trendBonus = Time.timeSinceLevelLoad * .001f;
                break;

            case Enums.Trendtype.Down:
                trendBonus = -Time.timeSinceLevelLoad * .001f;
                break;

            case Enums.Trendtype.Sine:
                trendBonus = Mathf.Sin(Time.timeSinceLevelLoad);
                break;
            default:
                break;
        }

        var value = comp.value +
            Random.Range(-comp.randomAbsolute * comp.value, comp.randomAbsolute + comp.value) + trendBonus;
        return value;
    }

    public static Enums.Trendtype SetTrendType()
    {
        var trend = (Enums.Trendtype)Random.Range(0, 3);
        return trend;
    }
}
