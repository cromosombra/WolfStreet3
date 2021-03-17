using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Default Game Config", menuName = "WolfStreet/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int minShareQty;
    public int maxShareQty;
    public float randomA;

    [SerializeField]
    List<CompanyData> companies;
    public List<BrokerData> Bots;
    public BrokerData player;

    public float startValue;

    public float updateInterval = 5f;

    public float PlayerSpeed = 4f;
    public float PlayerTurnSmooth = 0.1f;
    public int PlayerStartingMoney = 100;
    public string PlayerStartingName = "TestPlayer";

    public List<CompanyData> Companies
    {
        get { return companies; }
    }
}
