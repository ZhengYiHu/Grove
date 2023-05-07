using JimmysUnityUtilities;
using NaughtyAttributes;
using UnityEngine;

namespace LogicUI.FancyTextRendering
{
    [RequireComponent(typeof(MarkdownRenderer))]
    public class LoadMarkdownFromResources : MonoBehaviour
    {
        [SerializeField] public TextAsset TextAsset;
        private void Awake()
        {
            LoadMarkdown();
        }

        [Button]
        public void LoadMarkdown()
        {
            GetComponent<MarkdownRenderer>().Source = TextAsset.text;
        }
    }
}