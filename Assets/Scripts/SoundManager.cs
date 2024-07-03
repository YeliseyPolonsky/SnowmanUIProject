using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;

    private List<Button> _buttons = new List<Button>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _buttons.AddRange(FindObjectsOfType<Button>());

        foreach (Button button in _buttons)
        {
            button.onClick.AddListener(()=>_audioSource.PlayOneShot(_clickSound));
        }
    }

    public void MuteAllSound() => _audioSource.mute = true;

    public void UnMuteAllSound() => _audioSource.mute = false;
    
    private void OnDisable()
    {
        foreach (Button button in _buttons)
        {
            button.onClick.RemoveListener(()=>_audioSource.PlayOneShot(_clickSound));
        }
    }
}
