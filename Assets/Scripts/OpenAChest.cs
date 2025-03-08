using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class OpenAChest : MonoBehaviour
{
    public Animator chestAnim;
    public GameObject rewardImage;
    public GameObject textButton;
    public TextMeshProUGUI trophyName;
    public BuyableTrophies[] trophies;
    private int chosenIndex;
    //public bool isOpening;

    private void Start()
    {
        //Habilitar boton
        textButton.GetComponent<Button>().interactable = true;
    }

    public void OpenChest()
    {
        textButton.GetComponent<Button>().interactable = false;
        
        chestAnim.SetTrigger("Open"); // Activa la animacion

        Debug.Log("OpenChest");

        GiveReward();
    }

    public void GiveReward()
    {
        float randomValue = Random.Range(0f, 100f);
        int[] rewardIndexes;

        if (randomValue <= 60f) rewardIndexes = new int[] { 0, 1 }; // Gris
        else if (randomValue <= 80f && randomValue >= 60f) rewardIndexes = new int[] { 2, 3 }; // Azul
        else if (randomValue <= 95f && randomValue >= 80f) rewardIndexes = new int[] { 4, 5 }; // Violeta
        else if (randomValue <= 99.5f && randomValue >= 95f) rewardIndexes = new int[] { 6, 7 }; // Rojo
        else rewardIndexes = new int[] { 8 }; // Dorado (solo uno, no hace falta elegir)

        chosenIndex = rewardIndexes[Random.Range(0, rewardIndexes.Length)]; // Elige un índice aleatorio dentro de la rareza
        Debug.Log("Ganaste el objeto con índice: " + chosenIndex);
        Debug.Log("GiveReward");

        ChangeTextAndImage();
    }

    public void ChangeTextAndImage()
    {
        rewardImage.GetComponent<Image>().sprite = trophies[chosenIndex].sprite;
        trophyName.text = trophies[chosenIndex].trophyName;
        Debug.Log("ChangeT&I");
        GetRewardAndSave();
    }

    public void GetRewardAndSave()
    {
        Debug.Log("GetRewardAndSave");
        PlayerPrefsSave.instance._trophies[chosenIndex] = "B";
        PlayerPrefsSave.instance.SaveGame();
        Debug.Log($"FELICIDADES GANASTE EL {trophies[chosenIndex].trophyName}");
    }
}
