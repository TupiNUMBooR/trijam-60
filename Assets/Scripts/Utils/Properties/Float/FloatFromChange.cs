using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Float
{
    [RequireComponent(typeof(FloatProperty))]
    public class FloatFromChange : Modifier<FloatProperty>
    {
        public FloatProperty watch;

        protected override void Awake()
        {
            base.Awake();
            watch.ChangeDiffEvent += OnChange;
        }

        void OnDestroy()
        {
            watch.ChangeDiffEvent -= OnChange;
        }

        void OnChange(float was, float value)
        {
            target.Value += value - was;
        }
    }
}