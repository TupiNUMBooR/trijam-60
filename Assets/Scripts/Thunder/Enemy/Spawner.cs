using UnityEngine;
using Utils;

namespace Thunder.Enemy
{
    public class Spawner : MonoBehaviour
    {
        public Transform[] points;
        public GameObject prefab;
        public Transform parent;

        public void Spawn()
        {
            var go = Instantiate(prefab, parent);
            go.SetActive(true);
            var p = points.Random();
            go.transform.position = p.position;
            go.transform.rotation = p.rotation;
        }
    }
}