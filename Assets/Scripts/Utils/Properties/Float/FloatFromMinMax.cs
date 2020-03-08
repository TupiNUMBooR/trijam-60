using System;
using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Float
{
    [RequireComponent(typeof(FloatProperty))]
    public class FloatFromMinMax : Modifier<FloatProperty>
    {
        public Vector2 range = new Vector2(0, 1);

        public float Value
        {
            get => target.Value;
            set => target.Value = value;
        }

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
            target.ChangeDiffEvent += OnChange;
            OnChange();
        }

        void OnDestroy()
        {
            target.ChangeDiffEvent -= OnChange;
        }

        void OnChange()
        {
            OnChange(target.Value, target.Value);
        }

        void OnChange(float was, float now)
        {
            var v = Mathf.Clamp(target.Value, Range.x, Range.y);
            if (Math.Abs(Value - v) < float.Epsilon) return;
            Value = v;
            if (!IsMinned(was) && IsMinned(now)) MinEvent?.Invoke();
            if (!IsMaxed(was) && IsMaxed(now)) MaxEvent?.Invoke();
        }

        public bool IsMinned() => IsMinned(target.Value);
        public bool IsMaxed() => IsMaxed(target.Value);
        public bool IsMinned(float value) => value <= range.x;
        public bool IsMaxed(float value) => value >= range.y;
    }
}