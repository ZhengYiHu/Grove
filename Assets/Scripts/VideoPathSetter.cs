#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPathSetter : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] string videoClipName;
    void Start()
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
        videoPlayer.Play();
    }
}
