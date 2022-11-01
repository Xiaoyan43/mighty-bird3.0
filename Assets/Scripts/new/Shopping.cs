using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour
{
    public Text goldCoinTex;
    public Text resurrectionCoinTex;

    private void Awake()
    {
        UpdateGoldCoin();
        UpdateResurrectionCoin();
    }

    private void Update()
    {
        UpdateGoldCoin();
        UpdateResurrectionCoin();
    }

    private void UpdateGoldCoin()
    {
        goldCoinTex.text = GameContainer.Instance.goldCoin.ToString();
    }

    private void UpdateResurrectionCoin()
    {
        resurrectionCoinTex.text = GameContainer.Instance.resurrectionCoin.ToString().ToString();
    }

    public void AddGoldCoin(int value)
    {
        GameContainer.Instance.goldCoin += value;
        UpdateGoldCoin();
    }

    //  ¸´»î
    public void Resume()
    {
        GameContainer.Instance.resurrectionCoin -= 1;
        UpdateResurrectionCoin();
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }


}
