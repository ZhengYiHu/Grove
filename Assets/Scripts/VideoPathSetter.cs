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
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] TextMeshProUGUI text3;
    void Start()
    {
        if(videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        text2.text = $"videoClip null: {videoClip == null}";
        text3.text = $"Name: {videoClip.name}";
        text.text = $"{Application.streamingAssetsPath}/{videoClip.name}.mp4";
#if UNITY_EDITOR
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.url = AssetDatabase.GetAssetPath(videoClip);
#else
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoClip.name) + ".mp4";
#endif
        videoPlayer.Play();
    }
}
