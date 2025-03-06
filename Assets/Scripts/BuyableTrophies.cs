using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dimple's Trophy", menuName = "Buyable Trophies")]
public class BuyableTrophies : ScriptableObject
{
    public string trophyName;
    public int costYuans, costJades;
    //public bool isBought = false;
    public Sprite sprite;
}
