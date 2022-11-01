using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Create GameContainer", fileName = "GameContainer")]
public class GameContainer : ScriptableObject
{
    private static GameContainer _instance;
    public static GameContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<GameContainer>("GameContainer");
            }
            return _instance;
        }
    }

    public enum SwitchType
    {
        Bird, Bg
    }

    public enum BirdColor
    {
        Y,
        R,
        B,
    }

    public event Action OnValueChanged;

    public bool muteState;

    public int goldCoin;
    public int resurrectionCoin;

    public int bgSkinIndex = 0;

    public int birdSkinIndex = 0;

    public List<BirdColor> birdList;

    public int GetSwitchIndex(SwitchType type)
    {
        switch (type)
        {
            case SwitchType.Bird:
                return birdSkinIndex;
            case SwitchType.Bg:
                return bgSkinIndex;
        }
        return 0;
    }

    public void SetSwitchIndex(SwitchType type, int value)
    {
        switch (type)
        {
            case SwitchType.Bird:
                birdSkinIndex = value;
                break;
            case SwitchType.Bg:
                bgSkinIndex = value;
                break;
        }
    }

    public void SwitchBg()
    {
        bgSkinIndex++;
        OnValueChanged?.Invoke();
    }

    public void SwitchBird(BirdColor color)
    {
        birdSkinIndex = (int) color;
        OnValueChanged?.Invoke();
    }

    public bool IsBoughtBird(BirdColor birdColor)
    {
        return birdList.Contains(birdColor);
    }

    public void BuyBird(BirdColor birdColor)
    {
        if (!birdList.Contains(birdColor))
        {
            birdList.Add(birdColor);
        }
    }

    private void OnDestroy()
    {
        OnValueChanged = null;
    }

}
