using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParInitializer 
{
    public List<CompanyData> companydatas = new List<CompanyData>();
    public List<BrokerData> bots = new List<BrokerData>();
    public CompanyData player;

    public static Action<Company> companyCreated;
 
    public static List<Company> InitializeCompanies (List<CompanyData> cdatas)
    {
        var companies = new List<Company>();
        foreach (var data in cdatas)
        {
            var acompany = new Company();
            acompany.pName = data.companyName;
            acompany.avatar = data.avatar;
            acompany.money = 0;
            acompany.tickerSymbol = data.companyName.Substring(0, 3);
            acompany.sector = data.sector;
            acompany.SetCompanyValue();
            acompany.trend = ValueSetter.SetTrendType();
            acompany.randomAbsolute = GameManager.randomA;
            var share = new ShareBlock
            {
                company = acompany,
                shareQuantity = GameManager.shareqty
            };
            acompany.shares.Add(data.companyName, share);
            companies.Add(acompany);
            //Debug.Log($"{data.companyName} has {acompany.shares.Count} shares with amount of {acompany.shares.First().Value.shareQuantity} quantity");
            companyCreated?.Invoke(acompany);
        }
        return companies;
    }

    public static List<Broker> InitializeBots(List<BrokerData> bdatas)
    {

        var bots = new List<Broker>();
        foreach (var data in bdatas)
        {
            var bot = new Broker();
            bot.pName = BotNameGen.FirstName(data.gender) + BotNameGen.LastName();
            bot.avatar = data.avatar;
            bot.money = 0;
            bot.sector = data.sector;
            bots.Add(bot);
        }
        return bots;
    }

    public static Broker InitializePlayer(BrokerData pdata)
    {
        var player = new Broker();
        //player.pName = ;
        player.avatar = pdata.avatar;
        player.money = 0;
        player.sector = pdata.sector;
        return player;
    }

}
