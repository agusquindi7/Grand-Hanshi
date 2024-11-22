using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerPrefsSave : MonoBehaviour
{
    public static PlayerPrefsSave instance;

    [SerializeField] int _currency, _dragonGems;
    [SerializeField] TextMeshProUGUI _currencyText, _gemsText;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGame();
    }

    private void Update()
    {
        _currencyText.text = $"Yuans: { _currency}";
        _gemsText.text = $"Jade pieces: {_dragonGems}";
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Data_Currency", _currency);
        PlayerPrefs.SetInt("Data_Gems", _dragonGems);

        PlayerPrefs.Save();
        Debug.Log("Saving game...");
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Data_Currency"))
            _currency = PlayerPrefs.GetInt("Data_Currency", 100);
        if (PlayerPrefs.HasKey("Data_Gems"))
            _dragonGems = PlayerPrefs.GetInt("Data_Gems", 0);

        Debug.Log("Loading data...");
    }

    public void CompleteLevel(int pointsToAdd, int gemsToAdd)
    {
        int currentCurrency = PlayerPrefs.GetInt("Data_Currency");
        int currentGems = PlayerPrefs.GetInt("Data_Gems");

        currentCurrency += pointsToAdd;
        currentGems += gemsToAdd;

        PlayerPrefs.SetInt("Data_Currency", currentCurrency);
        PlayerPrefs.SetInt("Data_Gems", currentGems);

        PlayerPrefs.Save();
    }

    public void DeleteGame()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Deleting game...");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) SaveGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
