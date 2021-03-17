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
            foreach (var company in GameManager.companies)
            {
                company.SetCompanyValue();

                print(company.value);
            }
           
            timer = GameManager.config.updateInterval;
        }
        else
            timer -= Time.deltaTime;
    }
}
