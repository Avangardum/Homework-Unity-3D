using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Enemy1 : BaseObjectScene, IDamagable
    {
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;

        public void Damage(int value)
        {
            if (value < 0)
                return;
            _health -= value;
            if (_health < 0)
                _health = 0;
        }
    }

}