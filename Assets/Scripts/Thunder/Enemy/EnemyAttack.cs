using UnityEngine;

namespace Thunder.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public Health playerHealth;
        public Collider playerCollider;
        bool _playerInRange;
        public float delay = 1;
        float _nextAttack;
        public float damage = .3f;

        void OnTriggerEnter(Collider other)
        {
            if (other != playerCollider) return;
            print("enter");
            _playerInRange = true;
        }


        void OnTriggerExit(Collider other)
        {
            if (other != playerCollider) return;
            print("exit");
            _playerInRange = true;
        }


        void FixedUpdate()
        {
            if (!_playerInRange || Time.time < _nextAttack) return;
            playerHealth.property.Value -= damage;
            _nextAttack = Time.time + delay;
        }
    }
}