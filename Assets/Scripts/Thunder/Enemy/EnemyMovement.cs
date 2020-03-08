using UnityEngine;
using UnityEngine.AI;
using Utils.GameObject;

namespace Thunder.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : Modifier<NavMeshAgent>
    {
        public Health playerHealth;

        void Update()
        {
            if (playerHealth.IsMinned()) return;
            target.SetDestination(playerHealth.transform.position);
        }
    }
}