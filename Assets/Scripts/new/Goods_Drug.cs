using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods_Drug : Goods
{
    public int resumeCount;

    private Button _btn;

    protected override void Awake()
    {
        base.Awake();
        _btn = GetComponentInChildren<Button>(true);
    }

    private void OnEnable()
    {
        _btn.onClick.AddListener(() => Buy());
    }

    private void OnDisable()
    {
        _btn.onClick.RemoveListener(() => Buy());
    }

    protected override void OnBuy()
    {
        GameContainer.Instance.resurrectionCoin += resumeCount;
    }


}
