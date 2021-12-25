using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Food : MonoBehaviour
    {
        public UnityEvent foodEatenEvent;

        private void OnTriggerEnter(Collider other)
        {
            foodEatenEvent.Invoke();
            Destroy(this.gameObject);
        }
    }
}