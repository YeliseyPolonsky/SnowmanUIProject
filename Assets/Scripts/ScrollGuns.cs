using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GunSlot
{
    public Transform Transform;
    public Texture Texture;
}

public class ScrollGuns : MonoBehaviour
{
    [SerializeField] private List<GunSlot> _gunSlots;

    [Header("Icon")] [SerializeField] private RectTransform _iconParentTransform;
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private float _distanceBetweenIcons;
    [SerializeField] private float _scrollSpeed;

    [Header("Buttons")] [SerializeField] private Button _rightScrollButton;
    [SerializeField] private Button _leftScrollButton;

    private int _currentIndex = 0;
    private float _xPosition = 0;

    private void Start() => CreateGunIcons();

    private void OnEnable()
    {
        _rightScrollButton.onClick.AddListener(ScrollToRight);
        _leftScrollButton.onClick.AddListener(ScrollToLeft);
    }

    private void Update()
    {
        _xPosition = Mathf.MoveTowards(
            _xPosition, -_distanceBetweenIcons * _currentIndex,
            _scrollSpeed * Time.deltaTime);
        
        _iconParentTransform.anchoredPosition = new Vector3(_xPosition, 0, 0);
    }

    private void CreateGunIcons()
    {
        for (int i = 0; i < _gunSlots.Count; i++)
        {
            GameObject newIcon = Instantiate(
                _iconPrefab, Vector2.zero, 
                Quaternion.identity, _iconParentTransform);

            newIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * _distanceBetweenIcons,0);
            newIcon.GetComponent<RawImage>().texture = _gunSlots[i].Texture;
        }
    }

    public void ScrollToRight()
    {
        int maxIndex = _gunSlots.Count - 1;

        if (_currentIndex < maxIndex)
        {
            _gunSlots[_currentIndex].Transform.gameObject.SetActive(false);
            _currentIndex++;
            _gunSlots[_currentIndex].Transform.gameObject.SetActive(true);
        }
    }

    public void ScrollToLeft()
    {
        int minIndex = 0;

        if (_currentIndex > minIndex)
        {
            _gunSlots[_currentIndex].Transform.gameObject.SetActive(false);
            _currentIndex--;
            _gunSlots[_currentIndex].Transform.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        _rightScrollButton.onClick.RemoveAllListeners();
        _leftScrollButton.onClick.RemoveAllListeners();
    }
}