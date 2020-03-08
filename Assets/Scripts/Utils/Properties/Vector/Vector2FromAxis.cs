using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Vector
{
    [RequireComponent(typeof(Vector2Property))]
    public class Vector2FromAxis : Modifier<Vector2Property>
    {
        public string xAxis = "Horizontal";
        public string yAxis = "Vertical";

        void FixedUpdate()
        {
            target.Value = new Vector2(Input.GetAxisRaw(xAxis), Input.GetAxisRaw(yAxis));
        }
    }
}