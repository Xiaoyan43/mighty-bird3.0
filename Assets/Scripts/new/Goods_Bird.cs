using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods_Bird : Goods
{
    private Toggle _toggle;
    private Image _image;

    [Space(10)]
    public GameContainer.BirdColor color;
    public Color selectColor = Color.red;
    public Color unselectColor = Color.white;

    private bool _isBuy;

    protected override void Awake()
    {
        base.Awake();
        _toggle = GetComponentInChildren<Toggle>(true);
        _image = GetComponent<Image>();
        _isBuy = GameContainer.Instance.IsBoughtBird(color);
        if (_isBuy)
        {
            coinTex.enabled = false;
        }

        if (needCoin == 0)
        {
            GameContainer.Instance.BuyBird(color);
        }

        int index = GameContainer.Instance.birdSkinIndex;
        index %= System.Enum.GetNames(typeof(GameContainer.BirdColor)).Length;

        _toggle.isOn = (GameContainer.BirdColor)index == color;
        _image.color = _toggle.isOn ? selectColor : unselectColor;
    }


    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(OnValueChange);
    }

    protected override void Update()
    {
        base.Update();
        _toggle.interactable = _curCoin >= needCoin || _isBuy;
    }

    private void OnValueChange(bool value)
    {
        if (!_isBuy)
        {
            Buy();
        }
        _image.color = value ? selectColor : unselectColor;
        if (value && _isBuy)
        {
            GameContainer.Instance.birdSkinIndex = (int)color;
            GameContainer.Instance.SwitchBird(color);
        }
    }

    protected override void OnBuy()
    {
        _isBuy = true;
        coinTex.enabled = false;
        GameContainer.Instance.BuyBird(color);
    }

}
