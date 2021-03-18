using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyModel : ModelBase<Company>
{
    public CompanyModel(Company data, string name) : base(data, name)
    {
        
    }

    public static CompanyModel CreateCompanyModel(CompanyData data)
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
        var companyModel = new CompanyModel(acompany, acompany.pName);
        return companyModel;
    }

    public override void OnModelChanged()
    {
        base.OnModelChanged();
    }
}
