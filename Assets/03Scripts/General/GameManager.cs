using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameConfig configobject;
    public static GameConfig config;

    public static GameManager Instance { get => instance; }

    private static GameManager instance;

    public static int shareqty;
    public static float randomA;

    public static List<Company> companies;
    public static List<Broker> bots;
    public static Broker player;

    List<CompanyData> companieslist = new List<CompanyData>();

    public List<ScreenUISetter> islands;



    public ModelsController modelsController;
    public ViewController viewController;

    private void Awake()
    {
        instance = this;
        if (modelsController == null)
            modelsController = GetComponent<ModelsController>();
        if (viewController == null)
            viewController = GetComponent<ViewController>();
        config = Instantiate(configobject);

        companieslist = config.Companies;
    
        while (companieslist.Count>8)
        {
            companieslist.RemoveAt(Random.Range(0, config.Companies.Count));
        }

        for (int i = 0; i < companieslist.Count; i++)
        {
            islands[i].islandCompany = companieslist[i].companyName;
        }

        DontDestroyOnLoad(this);
        SetValues();
        InitializeGame();
    }

   void SetValues()
    {
        shareqty = Random.Range(config.minShareQty, config.maxShareQty);
        randomA = Random.Range(-config.randomA, config.randomA);
    }

    private void InitializeGame()
    {
        /*companies = ParInitializer.InitializeCompanies(companieslist);
        foreach (var company in companies)
        {
            var screenUis = islands.First(x => x.islandCompany.Equals(company.pName));
            //if (screenUis != null)
            //    screenUis.SetUI(company);
        }*/

        foreach (var company in companieslist)
        {
            var companyModel = CompanyModel.CreateCompanyModel(company);
            modelsController.models.Add(companyModel);
            var view = islands.First(x => x.islandCompany == companyModel.GetModelName());
            view.SetUIModel(companyModel);
            viewController.views.Add(view);
        }

        bots = ParInitializer.InitializeBots(config.Bots);
        player = ParInitializer.InitializePlayer(config.player);
    }
}
