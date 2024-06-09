using UnityEngine;
using Game.Data;

namespace Game
{
    public class EnemyProjectile : MonoBehaviour, IInitialization<ProjectTileModel>
    {
        [field: SerializeField] public float TimeLife { get; private set; } = 1f;
        [field: SerializeField] public Vector3 Direction { get; set; }
        [field: SerializeField] public ProjectTileModel Model { get; private set; }

        public void Init(ProjectTileModel data)
        {
            Model = data;
            TimeLife = Model.ReadData.TimeLife;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                float health = player.PlayerSelf.Health - Model.ReadData.Damage;
                player.PlayerSelf.Health = Mathf.Clamp(health, 0, player.PlayerSelf.MaxHealth);

                if (Model.ReadData.SoundOnDestroy != null)
                {
                    //sound
                }
                Destroy(gameObject);
            }

            if (Model.ReadData.IsFrendlyFire && other.TryGetComponent<IDamageHit>(out IDamageHit hit))
            {
                for (int i = Model.ReadData.frendlyFireLists.Count - 1; i >= 0; i--)
                {
                    if (Model.ReadData.frendlyFireLists[i].Character != null &&
                        Model.ReadData.frendlyFireLists[i].Character.Prefab != null &&
                        hit.GetType().Equals(Model.ReadData.frendlyFireLists[i].Character.Prefab.GetType()))
                    {
                        hit.Take(Model.Data.Damage);
                        if (Model.ReadData.frendlyFireLists[i].SoundOnDestroy != null)
                        {
                            //sound
                        }
                        break;
                    }
                }
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            TimeLife -= Time.deltaTime;

            if (TimeLife < 0f)
            {
                Destroy(gameObject);
            }

            Move();
        }

        public void Move()
        {
            transform.Translate(Direction * Model.ReadData.Speed * Time.deltaTime);
        }
    }
}