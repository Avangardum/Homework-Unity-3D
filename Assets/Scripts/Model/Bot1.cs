using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains
{
    public class Bot1 : BaseObjectScene, IDamagable
    {
        private enum State
        {
            Patrolling,
            Attacking
        }

        [SerializeField] private GameObject _ammo;
        [SerializeField] private GameObject _barrel;
        [SerializeField] private float _shootingForce;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _shootingCooldown;
        [SerializeField] private float _waypointDistance = 1;

        private NavMeshAgent _navMeshAgent;
        private float _currentShootingCooldown = 0;
        private State _state = State.Attacking;

        protected override void Awake()
        {
            base.Awake();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

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

        private void Update()
        {
            switch (_state)
            {
                case State.Patrolling:
                    Patrolling();
                    break;
                case State.Attacking:
                    Attacking();
                    break;
            }
        }

        private void Patrolling()
        {
            
        }

        private void Attacking()
        {
            GameObject player = TagManager.GetObjectWithTag(TagManager.Tag.Player);
            transform.LookAt(player.transform);
            if (_currentShootingCooldown == 0)
            {
                Shoot();
                _currentShootingCooldown = _shootingCooldown;
            }
            _currentShootingCooldown -= Time.deltaTime;
            if (_currentShootingCooldown < 0)
            {
                _currentShootingCooldown = 0;
            }
            _navMeshAgent.SetDestination(transform.position + Random.onUnitSphere * _waypointDistance);
        }
    }
}