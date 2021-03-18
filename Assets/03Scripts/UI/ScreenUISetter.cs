using System.Linq;
using TMPro;
using UnityEngine;

//Should be renamed to ScreenView
public class ScreenUISetter : ViewBase
{
    
    [SerializeField]
    TextMeshPro[] nombres;
    [SerializeField]
    TextMeshPro[] cantidades;
    [SerializeField]
    TextMeshPro[] precios;
    [SerializeField]
    SpriteRenderer thelogo;
    [SerializeField]
    SpriteRenderer thelogo2;
    
    public string islandCompany;
    private Company currentData;

    public Company CurrentData
    {
        get => currentData;
        set
        {
            currentData = value;
            ReDraw();
        } 
    }

    void Awake()
    {
        //ParInitializer.companyCreated = SetUI;
    }
    public void SetUIModel(CompanyModel companyModel)
    {
        CurrentData = companyModel.GetData();
        companyModel.modelChanged += ModelChanged;
    }

    private void ModelChanged(Company data)
    {
        CurrentData = data;
    }

    public override void ReDraw()
    {
        foreach (var nombre in nombres)
        {
            nombre.text = currentData.pName;
        }
        foreach (var quantity in cantidades)
        {
            quantity.text = currentData.shares.First().Value.shareQuantity.ToString();
        }
        foreach (var theprice in cantidades)
        {
            theprice.text = currentData.value.ToString();
            thelogo.sprite = currentData.avatar;
            thelogo2.sprite = currentData.avatar;
        }
    }
}
