using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Agus Add-Ons
using UnityEngine.SceneManagement;

public class StaminaSystem : MonoBehaviour
{
    DateTime _nextStaminaTime;
    DateTime _lastStaminaTime;

    [SerializeField] GameObject panel;

    [SerializeField] int _maxStamina = 10;
    public int currentStamina = 10;

    [SerializeField] float _timerToRecharge = 10f;

    [SerializeField] TextMeshProUGUI _staminaText, _timerText;

    bool _recharging;

    TimeSpan notifTimer;
    //int id;

    private void Start()
    {
        LoadGame();
        StartCoroutine(ChargingStamina());
    }

    IEnumerator ChargingStamina()
    {
        UpdateStamina();
        UpdateTimer();
        _recharging = true;

        while (currentStamina < _maxStamina)
        {
            DateTime current = DateTime.Now;
            DateTime nextTime = _nextStaminaTime;

            bool addingStamina = false;

            while(current > nextTime)
            {
                if (currentStamina >= _maxStamina) break;

                currentStamina++;
                addingStamina = true;
                UpdateStamina();

                DateTime timeToAdd = nextTime;

                if (_lastStaminaTime > nextTime) timeToAdd = _lastStaminaTime;

                nextTime = AddDuration(timeToAdd, _timerToRecharge);
            }

            if (addingStamina)
            {
                _nextStaminaTime = nextTime;
                _lastStaminaTime = DateTime.Now;
            }

            UpdateTimer();
            UpdateStamina();
            SaveGame();

            yield return new WaitForEndOfFrame();
        }
        _recharging = false;
    }

    DateTime AddDuration(DateTime timeToAdd, float duration) => timeToAdd.AddSeconds(duration);

    public bool HasEnoughStamina(int stamina) => currentStamina - stamina >= 0;

    public void UseStamina(int quantityOfUsage)
    {
        if (HasEnoughStamina(quantityOfUsage))
        {
            currentStamina -= quantityOfUsage;
            UpdateStamina();

            if(!_recharging)
            {
                _nextStaminaTime = AddDuration(DateTime.Now, _timerToRecharge);
                StartCoroutine(ChargingStamina());
                //Agus Add-Ons
                SceneManager.LoadSceneAsync("FirstDojo");
                //
            }
            else
            {
                //Agus Add-Ons
                panel.SetActive(true);
                //
                Debug.Log("No stamina!");
            }
        }
    }

    void UpdateTimer()
    {
        if(currentStamina >= _maxStamina)
        {
            _timerText.text = "Full stamina!";
            return;
        }

        notifTimer = _nextStaminaTime - DateTime.Now;

        _timerText.text = $"{notifTimer.Minutes.ToString("00")} : {notifTimer.Seconds.ToString("00")}";
    }

    void UpdateStamina()
    {
        _staminaText.text = $"{currentStamina} / {_maxStamina}";
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("_currentStamina", currentStamina);
        PlayerPrefs.SetString("_nextStaminaTime", _nextStaminaTime.ToString());
        PlayerPrefs.SetString("_lastStaminaTime", _lastStaminaTime.ToString());
    }

    void LoadGame()
    {
        currentStamina = PlayerPrefs.GetInt("_currentStamina", _maxStamina);
        _nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("_nextStaminaTime"));
        _lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("_lastStaminaTime"));

        UpdateStamina();
    }

    DateTime StringToDateTime(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.Now;
        else
            return DateTime.Parse(date);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) SaveGame();
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
