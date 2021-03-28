using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ValueUpdater
{
    internal void UpdateCompaniesValues()
    {
        foreach (var company in GameManager.Instance.companiesController.models)
        {
            var compModel = (CompanyModel)company;
            compModel.SetData(compModel.GetData().SetCompanyValue());
            Debug.Log($"Changed {compModel.GetData().pName} stock price to {compModel.GetData().value}");
            compModel.OnModelChanged();
        }
    }

    internal void UpdateCompaniesMoney()
    {
        foreach (var company in GameManager.Instance.companiesController.models)
        {
            var compModel = (CompanyModel)company;
            var data = compModel.GetData();
            data.money += Random.Range(-1f, 1f);
            compModel.SetData(data);
            Debug.Log($"Changed {compModel.GetData().pName} money to {compModel.GetData().money}");
            compModel.OnModelChanged();
        }
    }
}
