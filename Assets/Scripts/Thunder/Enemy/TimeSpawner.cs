using UnityEngine;
using Utils.GameObject;

namespace Thunder.Enemy
{
    [RequireComponent(typeof(Spawner))]
    public class TimeSpawner : Modifier<Spawner>
    {
        public float period = 1;
        public float periodMultiplier = 0.99f;
        float _nextSpawn;

        protected override void Awake()
        {
            base.Awake();
            _nextSpawn = Time.time;
        }

        void FixedUpdate()
        {
            if (Time.time < _nextSpawn) return;
            _nextSpawn += period;
            period *= periodMultiplier;
            target.Spawn();
        }
    }
}