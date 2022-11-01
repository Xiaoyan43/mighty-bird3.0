using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Goods : MonoBehaviour
{
    public int needCoin;

    public Text coinTex;

    public Color buyColor = Color.blue;
    public Color cantBuyColor = Color.red;

    protected int _curCoin;

    protected virtual void Awake()
    {
        coinTex.enabled = needCoin > 0;
        coinTex.text = needCoin.ToString();
    }

    protected bool Buy()
    {
        int total = GameContainer.Instance.goldCoin;
        if (needCoin > total)
        {
            return false;
        }

        total -= needCoin;
        GameContainer.Instance.goldCoin = total;
        OnBuy();
        return true;
    }

    protected virtual void Update()
    {
        _curCoin = GameContainer.Instance.goldCoin;
        if (needCoin != _curCoin)
        {
            coinTex.color = _curCoin < needCoin ? cantBuyColor : buyColor;
        }
    }

    protected abstract void OnBuy();

}
