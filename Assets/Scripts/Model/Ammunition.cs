using UnityEngine;

namespace Geekbrains
{
    public abstract class Ammunition : BaseObjectScene
    {
        [SerializeField] private AmmunitionData _data;
        [SerializeField] private float _timeToDestruct => _data.TimeToDestruct;
        [SerializeField] private float _baseDamage => _data.Damage;
        protected float _curDamage;
        private float _lossOfDamageAtTime = 0.2f;

        public AmmunitionType Type = AmmunitionType.Bullet;

        protected override void Awake()
        {
            base.Awake();
            _curDamage = _baseDamage;
        }

        private void Start()
        {
            DestroyAmmunition(_timeToDestruct);
            InvokeRepeating(nameof(LossOfDamage), 0, 1);
        }

        public void AddForce(Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        private void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;
        }

        protected void DestroyAmmunition(float timeToDestruct = 0)
        {
            Destroy(gameObject, timeToDestruct);
            CancelInvoke(nameof(LossOfDamage));
        }
    }
}
