using UnityEngine;

namespace Thunder.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        PlayerData _playerData;
        bool _playerInRange;
        public float delay = 1;
        float _nextAttack;
        public float damage = .3f;

        void OnTriggerEnter(Collider other)
        {
            var pd = other.GetComponent<PlayerData>();
            if (pd == null) return;
            _playerInRange = true;
            _playerData = pd;
        }

        void OnTriggerExit(Collider other)
        {
            var pd = other.GetComponent<PlayerData>();
            if (pd == null) return;
            _playerInRange = false;
            _playerData = null;
        }


        void FixedUpdate()
        {
            if (!_playerInRange || Time.time < _nextAttack) return;
            _playerData.health.Value -= damage;
            _nextAttack = Time.time + delay;
        }
    }
}