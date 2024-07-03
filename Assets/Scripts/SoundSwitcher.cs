using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private Button _buttonOnSound;
    [SerializeField] private Button _buttonOffSound;

    public void OnSound()
    {
        SoundManager.Instance.UnMuteAllSound();
        _buttonOffSound.gameObject.SetActive(false);
        _buttonOnSound.gameObject.SetActive(true);
    }

    public void OffSound()
    {
        SoundManager.Instance.MuteAllSound();
        _buttonOffSound.gameObject.SetActive(true);
        _buttonOnSound.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _buttonOnSound.onClick.AddListener(OffSound);
        _buttonOffSound.onClick.AddListener(OnSound);
    }

    private void OnDisable()
    {
        _buttonOffSound.onClick.RemoveListener(OnSound);
        _buttonOnSound.onClick.RemoveListener(OffSound);
    }
}