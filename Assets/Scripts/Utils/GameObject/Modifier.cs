using UnityEngine;

namespace Utils.GameObject
{
    public class Modifier<T> : MonoBehaviour
    {
        protected T target;

        protected virtual void Awake()
        {
            target = GetComponent<T>();
        }
    }
}