using System.Linq;
using TMPro;
using UnityEngine;

public class ScreenUISetter : MonoBehaviour
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

    void Awake()
    {
       //CompanyExtension.valuesetterdelegate = SetUI;
    }
    public void SetUI(Company company)
    {
        //Debug.Log($"{company.pName} {islandCompany} ");
        foreach (var nombre in nombres)
        {
            nombre.text = company.pName;
        }
        foreach (var quantity in cantidades)
        {
            quantity.text = company.shares.First().Value.shareQuantity.ToString();
        }
        foreach (var theprice in cantidades)
        {
            theprice.text = company.value.ToString();
            thelogo.sprite = company.avatar;
            thelogo2.sprite = company.avatar;
        }
    }

}
