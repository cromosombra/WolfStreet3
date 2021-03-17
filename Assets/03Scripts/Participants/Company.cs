using UnityEngine;

public class Company : Participant
{
    [System.NonSerialized]
    public string tickerSymbol;
    [System.NonSerialized]
    public float value = GameManager.config.startValue;
    [System.NonSerialized]
    public Enums.Trendtype trend;
    [System.NonSerialized]
    public float randomAbsolute;
}

public static class CompanyExtension
{
    //public delegate void ValueSetterDelegate(Company comp);
    //public static ValueSetterDelegate valuesetterdelegate;
    public static Company SetCompanyValue(this Company comp)
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
        comp.value = value;
        //valuesetterdelegate(comp);
        return comp;
    }
}
