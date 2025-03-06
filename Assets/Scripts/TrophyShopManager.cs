using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class TrophyShopManager : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    public Image[] sprites;
    public BuyableTrophies[] trophies;

    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            sprites[i].sprite = trophies[i].sprite;

            if (trophies[i].costYuans != 0)
                texts[i].text = $"{trophies[i].trophyName} YUANS {trophies[i].costYuans}";
            else
                texts[i].text = $"{trophies[i].trophyName} JADES {trophies[i].costJades}";
        }
    }

    public void BuyThisItemWithYuans(int index)
    {
        if (trophies[index].costYuans != 0)
        {
            if(trophies[index].costYuans <= PlayerPrefs.GetInt("Data_Currency") && !texts[index].text.Contains("BOUGHT")) //Pregunto si el coste es menor o igual los yuanes
            {
                texts[index].text = $"{trophies[index].trophyName} BOUGHT!"; //CAMBIO EL COSTO DE LOS YUANES POR BOUGHT OSEA COMPRADO

                Debug.Log($"COMPRE CON YUANES {trophies[index].trophyName}");

                int yuans = PlayerPrefs.GetInt("Data_Currency"); //Creo un int yuans y le pido a PlayerPrefs que me pase currency
                PlayerPrefs.SetInt("Data_Currency", yuans - trophies[index].costYuans); //Setteo el currency a los yuans que tengo en el momento menos el costo de trophies
                PlayerPrefs.Save(); //Guardo el nuevo valor de currency
                Debug.Log("Nuevo valor de Yuanes: " + PlayerPrefs.GetInt("Data_Currency"));
            }
        }
    }

    public void BuyThisItemWithJades(int index)
    {
        if (trophies[index].costJades != 0)
        {
            if (trophies[index].costJades <= PlayerPrefs.GetInt("Data_Gems") && !texts[index].text.Contains("BOUGHT")) //Pregunto si el coste es menor o igual los jades
            {
                texts[index].text = $"{trophies[index].trophyName} BOUGHT!"; //CAMBIO EL COSTO DE LOS JADES POR BOUGHT OSEA COMPRADO

                Debug.Log($"COMPRE CON JADES {trophies[index].trophyName}");

                int jades = PlayerPrefs.GetInt("Data_Gems"); //Creo un int jades y le pido a PlayerPrefs que me pase gems
                PlayerPrefs.SetInt("Data_Gems", jades - trophies[index].costJades); //Setteo el currency a los yuans que tengo en el momento menos el costo de trophies
                PlayerPrefs.Save(); //Guardo el nuevo valor de currency
                Debug.Log("Nuevo valor de Jades: " + PlayerPrefs.GetInt("Data_Gems"));
            }
        }
    }
}
