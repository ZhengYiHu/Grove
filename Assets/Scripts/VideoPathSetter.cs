using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPathSetter : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip videoClip;
    void Start()
    {
        if(videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
#if UNITY_EDITOR
        videoPlayer.source = VideoSource.VideoClip;

        videoPlayer.url = AssetDatabase.GetAssetPath(videoClip);
#elif UNITY_WEBGL
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoClip.name) + ".mp4";
        Debug.Log(videoPlayer.url);
#endif
        videoPlayer.Play();
    }
}
