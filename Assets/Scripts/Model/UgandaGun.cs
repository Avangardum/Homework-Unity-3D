﻿using UnityEngine;

namespace Geekbrains
{
    public class UgandaGun : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);//todo Pool object
            temAmmunition.AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechargeTime);
        }
    } 
}
