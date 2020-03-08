using UnityEngine;
using Utils.GameObject;
using Utils.Properties.Float;

namespace Thunder.Enemy
{
    [RequireComponent(typeof(Health))]
    public class DeathToFloat : Modifier<Health>
    {
        public FloatProperty score;

        protected override void Awake()
        {
            base.Awake();
            target.MinEvent += OnDie;
        }

        void OnDestroy()
        {
            target.MinEvent -= OnDie;
        }

        void OnDie()
        {
            score.Value += target.range.y;
        }
    }
}