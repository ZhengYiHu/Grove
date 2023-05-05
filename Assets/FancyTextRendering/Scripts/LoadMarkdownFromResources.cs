using JimmysUnityUtilities;
using NaughtyAttributes;
using UnityEngine;

namespace LogicUI.FancyTextRendering
{
    [RequireComponent(typeof(MarkdownRenderer))]
    public class LoadMarkdownFromResources : MonoBehaviour
    {
        [SerializeField] TextAsset TextAsset;
        private void Awake()
        {
            LoadMarkdown();
        }

        [Button]
        private void LoadMarkdown()
        {
            GetComponent<MarkdownRenderer>().Source = TextAsset.text;
        }
    }
}