using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompaniesController : ControllerBase
{
    public List<IModel> models = new List<IModel>();
    [SerializeField] private ValueUpdater _updater;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameManager.config.updateInterval;
        _updater = new ValueUpdater();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = GameManager.config.updateInterval;
            _updater.UpdateCompaniesValues();
            _updater.UpdateCompaniesMoney();
        }
        else
            timer -= Time.deltaTime;
        
        #region TestInteract

        if (Input.GetKeyDown(KeyCode.B))
        {
            var parameter = new IntParameter();
            parameter.SetData(3);
            Interact(CommandsList.BUY.ToString(), models[Random.Range(0, models.Count - 1)], parameter);
        }

        #endregion
    }

    public override void Interact(string command, IModel model, params IModelParameters[] parameters)
    {
        if (command.Equals(CommandsList.BUY.ToString()))
        {
            var compModel = (CompanyModel)model;
            var data = compModel.GetData();
            Debug.Log($"{data.pName} shareQuantity was {data.shares.First().Value.shareQuantity}");
            data.shares.First().Value.shareQuantity -= ((IntParameter) parameters[0]).GetData();
            compModel.SetData(data);
            compModel.OnModelChanged();
            Debug.Log($"{data.pName} shareQuantity changed to {data.shares.First().Value.shareQuantity}");
        }
    }
}
