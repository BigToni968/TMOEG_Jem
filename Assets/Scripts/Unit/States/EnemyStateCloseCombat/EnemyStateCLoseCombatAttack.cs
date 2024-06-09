using System.Collections;
using UnityEngine;

namespace Game
{
    public class EnemyStateCLoseCombatAttack : EnemyStateCloseCombatBase
    {
        private Coroutine _coroutine;
        private WaitForSeconds _waiteAiming;
        private WaitForSeconds _delayBeetwenAttack;

        public EnemyStateCLoseCombatAttack(Patterns.StateMachine machine) : base(machine)
        {
            _waiteAiming = new(CloseCombatMode.ReadData.Aiming);
            _delayBeetwenAttack = new(CloseCombatMode.ReadData.SpeedAttack);
        }

        public override void Start()
        {
            base.Start();
            _coroutine = Control.Owner.StartCoroutine(Aiming());
        }

        public override void Finish()
        {
            base.Finish();
            if (_coroutine != null)
            {
                Control.Owner.StopCoroutine(_coroutine);
            }
        }

        public override void Update()
        {
            if (Control.Player.PlayerSelf.Health <= 0)
                return;

            base.Update();

            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) > CloseCombatMode.ReadData.Distance)
            {
                Control.Switch(new EnemyStateCloseCombatFollov(Control));
            }

            if (_coroutine == null)
            {
                _coroutine = Control.Player.StartCoroutine(Attack());
            }

        }
        public IEnumerator Aiming()
        {
            yield return _waiteAiming;
            _coroutine = null;
        }

        public IEnumerator Attack()
        {
            yield return _delayBeetwenAttack;

            float health = Control.Player.PlayerSelf.Health - CloseCombatMode.ReadData.Damage;
            Control.Player.PlayerSelf.Health = Mathf.Clamp(health, 0, Control.Player.PlayerSelf.MaxHealth);
            Audio.Instance.Sound.PlayOneShot(Audio.Instance.hit_player[Random.Range(0, Audio.Instance.hit_player.Length)]);

            if (Control.Owner.Character.CombatMode.Gizmo)
            {
                Debug.Log($"Player Take Damage {CloseCombatMode.ReadData.Damage}");
            }

            _coroutine = null;
        }
    }
}