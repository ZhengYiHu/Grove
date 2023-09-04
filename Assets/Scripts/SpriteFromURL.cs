using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Take images from Streaming asset folder and load it into an Image
/// </summary>
[RequireComponent(typeof(Image))]
public class SpriteFromURL : MonoBehaviour
{
    [SerializeField]
    public Image img;
    [SerializeField, ValidateInput("ValidateImage", "Image name cannot be empty")]
    public string imageName;
   
    async void Start()
    {
#if UNITY_EDITOR
        string targetUrl = Path.Combine(Application.dataPath, GameConstats.WEBGLBUILD_STREAMING_ASSETS_PATH, imageName);
        targetUrl = "file://" + targetUrl + ".png";
#else
        string targetUrl = System.IO.Path.Combine(Application.streamingAssetsPath, imageName) + ".png";
#endif

        img.sprite = await SpritesRepository.GetSprite(targetUrl);
    }

#if UNITY_EDITOR
    private void Reset()
    {
        if (img == null)
            img = GetComponent<Image>();
        imageName = img.sprite.name;
    }

    bool ValidateImage()
    {
        return !string.IsNullOrEmpty(imageName);
    }

    [Button]
    void SetImageName()
    {
        imageName = img.sprite.name;
    }
#endif
}
