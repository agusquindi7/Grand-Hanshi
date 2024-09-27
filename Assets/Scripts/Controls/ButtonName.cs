using UnityEngine;
using TMPro;
public class ButtonName : MonoBehaviour
{
    [SerializeField] ScriptableObject attack;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        text.text = attack.name;
    }
}
