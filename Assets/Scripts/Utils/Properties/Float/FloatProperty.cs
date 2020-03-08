using UnityEngine;

namespace Utils.Properties.Float
{
    public class FloatProperty : AbstractProperty<float>
    {
        public override float Value
        {
            get => base.Value;
            set
            {
                if (Mathf.Abs(Value - value) <= Mathf.Abs(Value * KMathUtils.floatError)) return;
                base.Value = value;
            }
        }
    }
}