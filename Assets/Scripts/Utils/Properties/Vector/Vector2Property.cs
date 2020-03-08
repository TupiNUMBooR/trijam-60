using UnityEngine;

namespace Utils.Properties.Vector
{
    public class Vector2Property : AbstractProperty<Vector2>
    {
        public override Vector2 Value
        {
            get => base.Value;
            set
            {
                if ((value - Value).sqrMagnitude > KMathUtils.floatError)
                    base.Value = value;
            }
        }
    }
}