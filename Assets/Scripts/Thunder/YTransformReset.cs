using UnityEngine;

namespace Thunder
{
    public class YTransformReset : MonoBehaviour
    {
        void Update()
        {
            var p = transform.position;
            if (p.y < -10) p.y = 10;
            transform.position = p;
        }
    }
}