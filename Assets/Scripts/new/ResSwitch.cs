using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResSwitch : MonoBehaviour
{
    public List<GameObject> switchList;

    public GameContainer.SwitchType switchType;


    private void Awake()
    {
        Switch();
    }

    private void OnEnable()
    {
        GameContainer.Instance.OnValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        GameContainer.Instance.OnValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        Switch();
    }

    private void Switch()
    {
        int index = GameContainer.Instance.GetSwitchIndex(switchType);
        if (index >= switchList.Count)
        {
            index %= switchList.Count;
            GameContainer.Instance.SetSwitchIndex(switchType, index);
        }

        for (int i = 0; i < switchList.Count; i++)
        {
            switchList[i].SetActive(i == index);
        }
    }

}
