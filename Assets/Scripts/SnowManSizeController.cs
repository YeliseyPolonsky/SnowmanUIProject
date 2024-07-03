using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ball
{
    public Transform Transform;
    [HideInInspector] public Vector3 StartScale;
    [HideInInspector] public Vector3 StartLocalPosition;
}

public class SnowManSizeController : MonoBehaviour
{
    [SerializeField] private List<Ball> _balls = new List<Ball>();
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        foreach (Ball ball in _balls)
        {
            ball.StartScale = ball.Transform.localScale;
            ball.StartLocalPosition = ball.Transform.localPosition;
        }
    }

    private void OnEnable() => _slider.onValueChanged.AddListener(SlideScale);

    public void SlideScale(float value)
    {
        foreach (Ball ball in _balls)
        {
            ball.Transform.localScale = ball.StartScale * value;
            ball.Transform.localPosition = ball.StartLocalPosition * value;
        }

        _text.text = "Размер снеговика: " + value.ToString("0.00");
    }

    private void OnDisable() => _slider.onValueChanged.RemoveAllListeners();
}