using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotNameGen : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
           print( FirstName(Enums.Gender.Male) + " " + LastName());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            print(FirstName(Enums.Gender.Female) + " " + LastName());
        }
    }
    public static string LastName()
    {
        string names = File.ReadAllText(Application.dataPath + "/06names/lastNames.json");
        string[] separatedNames = names.Split(',');

        char[] remove = { '"' };

        string quotesName = separatedNames[Random.Range(0, separatedNames.Length)].Trim();
        var lastName = quotesName.Trim('"');
        return lastName;
    }

    public static string FirstName(Enums.Gender gender)
    {
        string names;
        if (gender == Enums.Gender.Male)
        {
             names = File.ReadAllText(Application.dataPath + "/06names/malenames.json");
        }
        else
        {
            names = File.ReadAllText(Application.dataPath + "/06names/femalenames.json");
        }

        string[] separatedNames = names.Split(',');
        char[] remove = { '"' };
        string quotesName = separatedNames[Random.Range(0, separatedNames.Length)].Trim();
        var firstName = quotesName.Trim('"');
        return firstName;
    }

   
}


