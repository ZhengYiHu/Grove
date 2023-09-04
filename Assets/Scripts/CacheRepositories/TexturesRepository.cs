using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Cache repository that fetches an asset from the URL if it didn't exist, and retrieve if it does
/// </summary>
public static class TexturesRepository
{
   static Dictionary<string, Texture2D> repository = new Dictionary<string, Texture2D>();

   public async static UniTask<Texture2D> GetTexture(string targetUrl)
   {
        if(!repository.TryGetValue(targetUrl, out Texture2D assetOut))
        {
            assetOut = await CreateAsset(targetUrl);
            repository.Add(targetUrl, assetOut);
        }
        return assetOut;
   }

    private async static UniTask<Texture2D> CreateAsset(string targetUrl)
    {
        //Generate Unity web request
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(targetUrl);
        await textureRequest.SendWebRequest();

        if (textureRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"{textureRequest.error} at {targetUrl}: {textureRequest.downloadHandler.error}");
            return null;
        }
        else
        {
            //If requested succeded, create a sprite from the texture and assign it to the image
            Texture2D myTexture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
            return myTexture;
        }
    }
}
