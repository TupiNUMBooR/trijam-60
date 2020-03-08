using System;
using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Float
{
    [RequireComponent(typeof(FloatProperty))]
    public class FloatFromMinMax : Modifier<FloatProperty>
    {
        public Vector2 range = new Vector2(0, 1);

        public bool IsMinned => target.Value <= range.x;
        public bool IsMaxed => target.Value >= range.y;

        public Vector2 Range
        {
            get => range;
            set
            {
                if ((range - value).sqrMagnitude < KMathUtils.floatError) return;
                range = value;
                OnChange();
                RangeChangeEvent?.Invoke(range);
            }
        }

        public event Action MinEvent;
        public event Action MaxEvent;
        public event Action<Vector2> RangeChangeEvent;

        protected override void Awake()
        {
            base.Awake();
            target.ChangeEvent += OnChange;
        }

        void OnDestroy()
        {
            target.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            var wasMinned = IsMinned;
            var wasMaxed = IsMaxed;
            var v = Mathf.Clamp(target.Value, Range.x, Range.y);
            if (Math.Abs(target.Value - v) < float.Epsilon) return;
            target.Value = v;
            if (!wasMinned && IsMinned) MinEvent?.Invoke();
            if (!wasMaxed && IsMaxed) MaxEvent?.Invoke();
        }
    }
}