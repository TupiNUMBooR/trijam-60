namespace Utils.Properties.Bool
{
    public class BoolProperty : AbstractProperty<bool>
    {
        public override bool Value
        {
            get => base.Value;
            set
            {
                if (Value == value) return;
                base.Value = value;
            }
        }
    }
}