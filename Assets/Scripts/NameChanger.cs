using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameChanger : MonoBehaviour
{
    [SerializeField] private Transform _canvasName;
    [SerializeField] private Transform _camera;
    
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TMP_InputField _inputField;

    private void Update()
    {
        Vector3 toCamera = _camera.position - _canvasName.position;
        _canvasName.rotation = Quaternion.LookRotation(toCamera);
    }

    private void OnEnable() => _inputField.onValueChanged.AddListener(ChahgeName);
    
    public void ChahgeName(string text) => _name.text = text;

    private void OnDisable() => _inputField.onValueChanged.RemoveAllListeners();
}