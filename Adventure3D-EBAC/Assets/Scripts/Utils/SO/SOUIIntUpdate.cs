using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum CollectibleType
{
    Coin,
    RedCoin
}

[CreateAssetMenu]
public class SOUIIntUpdate : MonoBehaviour
{
    public CollectibleType collectibleType;
    public SOint soInt;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    private void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    private void UpdateUI()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
