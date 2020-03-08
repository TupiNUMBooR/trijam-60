using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Thunder.Player
{
    public class DeathAndRestart : MonoBehaviour
    {
        public Health health;
        public Rigidbody rb;
        public Behaviour[] disables;

        void Awake()
        {
            health.MinEvent += OnDie;
        }

        void OnDestroy()
        {
            health.MinEvent -= OnDie;
        }

        void OnDie()
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForceAtPosition(Vector3.one * 288, -Vector3.down);
            disables.ForEach((b, i) => b.enabled = false);
            StartCoroutine(Restart());
        }

        IEnumerator Restart()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(0);
        }
    }
}