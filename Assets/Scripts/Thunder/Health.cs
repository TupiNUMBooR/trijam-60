using Utils.Properties.Float;

namespace Thunder
{
    public class Health : FloatFromMinMax
    {
        public FloatProperty property;
        
        protected override void Awake()
        {
            base.Awake();
            property = target;
        }
    }
}