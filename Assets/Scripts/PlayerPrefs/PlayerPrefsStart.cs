using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrefsStart : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyTXT, gemsTXT;
    void Awake()
    {
        PlayerPrefsSave.instance.LoadGame();
        int currency = PlayerPrefs.GetInt("Data_Currency");
        int gems = PlayerPrefs.GetInt("Data_Gems");

        currencyTXT.text = $"Yuans: {currency}";
        gemsTXT.text = $"Jade pieces: {gems}";
    }

}
