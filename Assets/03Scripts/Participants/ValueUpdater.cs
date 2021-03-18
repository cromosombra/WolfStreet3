using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueUpdater : MonoBehaviour
{
    float timer;

    private void Start()
    {
        timer = GameManager.config.updateInterval;
    }
    void Update()
    {
        if (timer <= 0)
        {
            foreach (var company in GameManager.Instance.modelsController.models)
            {
                var compModel = (CompanyModel)company;
                compModel.SetData(compModel.GetData().SetCompanyValue());
                Debug.Log($"changed {compModel.GetData().pName} stock price to {compModel.GetData().value}");
                compModel.OnModelChanged();
            }
           
            timer = GameManager.config.updateInterval;
        }
        else
            timer -= Time.deltaTime;
    }
}
