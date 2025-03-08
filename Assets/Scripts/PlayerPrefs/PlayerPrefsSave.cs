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

    public string[] _trophies;
    public int _currency, _dragonGems;
    [SerializeField] TextMeshProUGUI _currencyText, _gemsText;

    private void Awake()
    {
        if (_currencyText == null) _currencyText = GameObject.FindGameObjectWithTag("Currency").GetComponent<TextMeshProUGUI>();
        if (_gemsText == null) _gemsText = GameObject.FindGameObjectWithTag("Gems").GetComponent<TextMeshProUGUI>();
        
        if (instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        _currencyText.text = $"Yuans: { _currency}";
        _gemsText.text = $"Jade pieces: {_dragonGems}";
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Data_Currency", _currency);
        PlayerPrefs.SetInt("Data_Gems", _dragonGems);

        for (int i = 0; i < _trophies.Length; i++)
        {
            PlayerPrefs.SetString($"Data_{i}", _trophies[i]);
        }

        PlayerPrefs.Save();
        Debug.Log("Saving game...");
    }

    public void LoadGame()
    {
        // Cargar valores de Currency y Gems
        _currency = PlayerPrefs.GetInt("Data_Currency", 100);
        _dragonGems = PlayerPrefs.GetInt("Data_Gems", 0);

        // Verificar que _trophies está inicializado
        if (_trophies == null || _trophies.Length == 0)
        {
            Debug.LogError("Error: _trophies no ha sido inicializado o está vacío.");
            return;
        }

        // Cargar los valores de los trofeos
        for (int i = 0; i < _trophies.Length; i++)
        {
            _trophies[i] = PlayerPrefs.GetString($"Data_{i}", "NB");
        }

        // Debugging para verificar datos cargados
        Debug.Log($"Currency: {_currency}, Gems: {_dragonGems}");
        Debug.Log("Trophies: " + string.Join(", ", _trophies));
    }


    public void CompleteLevel(int pointsToAdd, int gemsToAdd)
    {
        int currentCurrency = PlayerPrefs.GetInt("Data_Currency");
        int currentGems = PlayerPrefs.GetInt("Data_Gems");

        Debug.Log($"{currentCurrency} and {currentGems}");

        currentCurrency += pointsToAdd;
        currentGems += gemsToAdd;

        PlayerPrefs.SetInt("Data_Currency", currentCurrency);
        PlayerPrefs.SetInt("Data_Gems", currentGems);

        SaveGame();
    }

    public void DeleteGame()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Deleting game data...");
    }

    public void StartLGWCooldown()
    {
        StartCoroutine(LoadGameWithCooldown());
    }

    private IEnumerator LoadGameWithCooldown()
    {
        LoadGame();

        yield return new WaitForSeconds(1.5f);

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
