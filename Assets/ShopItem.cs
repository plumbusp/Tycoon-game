using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem: MonoBehaviour
{
    public Button _button;
    public House House;

    private void Start()
    {
        _button.onClick.AddListener(BuyItem);
    }
    private void BuyItem()
    {

    }
}
