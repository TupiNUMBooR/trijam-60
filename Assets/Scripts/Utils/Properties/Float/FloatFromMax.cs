using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Float
{
    [RequireComponent(typeof(FloatProperty))]
    public class FloatFromMax : Modifier<FloatProperty>
    {
        public FloatProperty currentProperty;

        protected override void Awake()
        {
            base.Awake();
            currentProperty.ChangeEvent += OnChange;
        }

        void OnDestroy()
        {
            currentProperty.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            if (currentProperty.Value > target.Value) target.Value = currentProperty.Value;
        }
    }
}