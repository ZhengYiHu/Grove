using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Cache repository that fetches an asset from the URL if it didn't exist, and retrieve if it does
/// </summary>
public static class SpritesRepository
{
    static Dictionary<string, Sprite> repository = new Dictionary<string, Sprite>();

    public async static UniTask<Sprite> GetSprite(string targetUrl)
    {
        if (!repository.TryGetValue(targetUrl, out Sprite assetOut))
        {
            assetOut = await CreateAsset(targetUrl);
            repository.Add(targetUrl, assetOut);
        }
        return assetOut;
    }

    private async static UniTask<Sprite> CreateAsset(string targetUrl)
    {
        Texture2D myTexture = await TexturesRepository.GetTexture(targetUrl);
        return Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
    }
}
