using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        public float ChargePercentage => BatteryChargeCurrent / _batteryChargeMax;

        private Light _light;
        private Transform _goFollow;
        private Vector3 _vecOffset;
        public float BatteryChargeCurrent { get; private set; }
        [SerializeField] private float _speed;
        [SerializeField] private float _batteryChargeMax;
        [SerializeField] private float _batteryRechargeSpeed;

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }

        public void Switch(FlashLightActiveType value)
        {
            switch (value)
            {
                case FlashLightActiveType.On:
                    _light.enabled = true;
                    transform.position = _goFollow.position + _vecOffset;
                    transform.rotation = _goFollow.rotation;
                    break;
                case FlashLightActiveType.None:
                    break;
                case FlashLightActiveType.Off:
                    _light.enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void Rotation()
        {
            transform.position = _goFollow.position + _vecOffset;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                _goFollow.rotation, _speed * Time.deltaTime);
        }

        /// <summary>
        /// Вычитает заряд батареи
        /// </summary>
        /// <returns>Остался ли заряд в батарее</returns>
        public bool RemoveBatteryCharge()
        {
            if (BatteryChargeCurrent > 0)
            {
                BatteryChargeCurrent -= Time.deltaTime;
                return true;
            }
            return false;
        }

        public void AddBatteryCharge()
        {
            if (BatteryChargeCurrent < _batteryChargeMax)
            {
                BatteryChargeCurrent += Time.deltaTime * _batteryRechargeSpeed;
            }
        }
    }
}
