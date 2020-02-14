using UnityEngine;
using UnityEngine.SceneManagement;

namespace Geekbrains
{
    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public void Damage(float value)
        {
            if(value < 0)
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}