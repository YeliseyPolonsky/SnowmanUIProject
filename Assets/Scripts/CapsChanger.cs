using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CapsChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> Caps = new List<GameObject>();

    [SerializeField] private TMP_Dropdown _dropdown;

    private void OnEnable() => _dropdown.onValueChanged.AddListener(SetCap);

    public void SetCap(int index)
    {
        for (int i = 0; i < Caps.Count; i++)
        {
            if (i == index)
                Caps[i].SetActive(true);
            else
                Caps[i].SetActive(false);
        }
    }

    private void OnDisable() => _dropdown.onValueChanged.RemoveAllListeners();
}