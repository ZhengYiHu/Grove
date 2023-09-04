#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPathSetter : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage rawImage;
    [SerializeField] string videoClipName;
    async void Start()
    {
        if(videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        
#if UNITY_EDITOR
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.url = System.IO.Path.Combine(Application.dataPath, GameConstats.WEBGLBUILD_STREAMING_ASSETS_PATH, videoClipName)+".mp4";
#else
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoClipName) + ".mp4";
#endif

        await UniTask.WaitUntil(() => videoPlayer.isPrepared);
        //Create render Texture
        var source = videoPlayer.texture;
        var rt = new RenderTexture(source.width, source.height, 16, RenderTextureFormat.ARGB32);
        rt.Create();

        videoPlayer.targetTexture = rt;
        rawImage.texture = rt;
        rt.Release();
        videoPlayer.Play();
    }
}
