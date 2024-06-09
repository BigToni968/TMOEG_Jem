using UnityEngine;
using Game.Data;

namespace Game.UI
{
    public class WindowGalery : MonoBehaviour, IInitialization
    {
        [field: SerializeField] public GaleryResources GaleryResources { get; private set; }
        [field: SerializeField] public Transform Content { get; private set; }
        [field: SerializeField] public UI_GaleryCard UI_GaleryCardPrefab { get; private set; }

        private int _index = 0;
        private GameObject _modelView;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            foreach (GaleryBox box in GaleryResources.Resources)
            {
                UI_GaleryCard card = Instantiate(UI_GaleryCardPrefab, Content);
                GaleryCardData data = new() { Name = box.Character.Name, Description = box.Character.Description };
                if (box.Character.Portrate != null)
                {
                    data.Portraite = box.Character.Portrate.texture;
                }
                card.Init(data);
            }

            InstanceModel();
        }

        public void InstanceModel()
        {
            if (_modelView != null)
            {
                GameObject.Destroy(_modelView);
            }

            _modelView = Instantiate(GaleryResources.Resources[_index].Model, Vector3.one, Quaternion.identity);

            if (_modelView.TryGetComponent<UnitEnemy>(out UnitEnemy enemy))
            {
                Destroy(enemy);
            }

            if (_modelView.TryGetComponent<Player>(out Player player))
            {
                Destroy(player);
            }


            _modelView.transform.localScale = Vector3.one * GaleryResources.Resources[_index].Scale;
            _modelView.transform.Rotate(GaleryResources.Resources[_index].Rotate);
        }

        public void Leafing(int axis)
        {
            _index += axis;
            _index = Mathf.Clamp(_index, 0, GaleryResources.Resources.Length - 1);
            InstanceModel();
        }
    }
}