using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class TexturesRepository : AssetRepository<Texture2D>
{
   static Dictionary<string, Texture2D> repository = new Dictionary<string, Texture2D>();

   public async static UniTask<Texture2D> GetTexture(string targetUrl)
   {
        if(repository.TryGetValue(targetUrl, out Texture2D assetOut))
        {
            return assetOut;
        }
        else
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
}
