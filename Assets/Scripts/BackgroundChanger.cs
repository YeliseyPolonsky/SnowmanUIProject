using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextureToToggle
{
    public Toggle Toggle;
    public Texture Texture;
}

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private Material _BGmaterial;
    [SerializeField] private List<TextureToToggle> _texturesToToggles = new List<TextureToToggle>();

    private void Awake()
    {
        foreach (TextureToToggle texturesToToggle in _texturesToToggles)
        {
            texturesToToggle.Toggle.onValueChanged.AddListener(
                delegate {ChangeTexture(texturesToToggle.Texture);});
        }
    }

    private void OnDisable()
    {
        foreach (TextureToToggle texturesToToggle in _texturesToToggles)
        {
            texturesToToggle.Toggle.onValueChanged.RemoveAllListeners();
        }
    }

    public void ChangeTexture(Texture texture) => _BGmaterial.mainTexture = texture;
}
