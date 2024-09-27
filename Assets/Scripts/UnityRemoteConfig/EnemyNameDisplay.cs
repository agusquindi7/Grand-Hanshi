using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyNameDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Transform enemyTransform;
    public Vector3 offset = new Vector3(0, 2, 0);

    [SerializeField] MyRemoteConfig myRC;

    public void LateStart()
    {
        // Obtén el nombre del enemigo desde MyRemoteConfig
        SetEnemyName(MyRemoteConfig.Instance.enemyName);
        //Debug.Log(MyRemoteConfig.Instance.enemyName);
        Debug.Log("Cambiando el nombre a " + myRC.enemyName);
    }

    void Update()
    {
        if (nameText != null && enemyTransform != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(enemyTransform.position + offset);
            nameText.transform.position = screenPos;
        }
    }

    public void SetEnemyName(string newName)
    {
        if (nameText != null)
        {
            nameText.text = newName;
        }
    }

}