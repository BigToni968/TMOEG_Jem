using MyStateMachine = Patterns.StateMachine;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class EnemyStateRangedCombatAttack : EnemyStateRangedCombatBase
    {
        private protected Coroutine _coroutineAiming;
        private protected Coroutine _coroutineAttack;
        private WaitForSeconds _waiteAiming;
        private WaitForSeconds _delayBeetwenAttack;

        public EnemyStateRangedCombatAttack(MyStateMachine machine) : base(machine)
        {
            _waiteAiming = new(RangeCombatMode.ReadData.Aiming);
            _delayBeetwenAttack = new(RangeCombatMode.ReadData.SpeedAttack);
        }

        public override void Start()
        {
            base.Start();
            _coroutineAiming = Control.Owner.StartCoroutine(Aiming());
        }

        public override void Finish()
        {
            base.Finish();
            if (_coroutineAiming != null)
            {
                Control.Owner.StopCoroutine(_coroutineAiming);
            }
        }

        public override void Update()
        {
            if (Control.Player.PlayerSelf.Health <= 0)
                return;

            base.Update();

            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) > RangeCombatMode.ReadData.RangeAttack)
            {
                Control.Switch(new EnemyStateRangedCombatFollov(Control));
            }

            if (_coroutineAiming == null && _coroutineAttack == null)
            {
                _coroutineAttack = Control.Player.StartCoroutine(Attack());
            }

        }
        public IEnumerator Aiming()
        {
            yield return _waiteAiming;
            _coroutineAiming = null;
        }

        public IEnumerator Attack()
        {
            yield return _delayBeetwenAttack;
            //Spawn prjectile
            EnemyProjectile projectile = GameObject.Instantiate(RangeCombatMode.ReadData.PrjectTile.Model.ReadData.Prefab, Control.Owner.TargetCastProjectile.position, Quaternion.identity);
            projectile.Direction = Control.Owner.transform.forward;
            projectile.Init(RangeCombatMode.ReadData.PrjectTile.Model);
            _coroutineAttack = null;
        }
    }
}