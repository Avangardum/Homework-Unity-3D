using UnityEngine;

namespace Geekbrains
{
    public class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            IDamagable damagable;
            if (collision.gameObject.TryGetComponent<IDamagable>(out damagable))
            {
                damagable.Damage(_curDamage);
            }
            Destroy(gameObject);
        }
    } 
}
