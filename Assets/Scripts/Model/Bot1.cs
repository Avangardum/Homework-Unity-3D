using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Bot1 : BaseObjectScene, IDamagable
    {
        [SerializeField] private GameObject _ammo;
        [SerializeField] private GameObject _barrel;
        [SerializeField] private float _shootingForce;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public void Damage(float value)
        {
            if(value <= 0)
                return;
            _health -= value;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void Shoot()
        {
            GameObject bullet = GameObject.Instantiate(_ammo, _barrel.transform.position, _barrel.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * _shootingForce);
        }
    }
}