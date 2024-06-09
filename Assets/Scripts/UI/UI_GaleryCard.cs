using UnityEngine.UI;
using UnityEngine;
using Patterns;
using TMPro;

namespace Game.UI
{
    public class UI_GaleryCard : ViewController, IInitialization<GaleryCardData>
    {
        [field: SerializeField] public RawImage Portraite { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Description { get; private set; }

        public void Init(GaleryCardData data)
        {
            Portraite.texture = data.Portraite;
            Name.SetText(data.Name);
            Description.SetText(data.Description);
        }
    }

    public struct GaleryCardData
    {
        public Texture Portraite;
        public string Name;
        public string Description;
    }
}