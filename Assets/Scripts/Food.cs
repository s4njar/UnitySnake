using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Food : MonoBehaviour
    {
        public UnityEvent foodEatenEvent;

        //void Start()
        //{
        //    if (m_MyEvent == null)
        //        m_MyEvent = new UnityEvent();

        //    m_MyEvent.AddListener();
        //}

        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);

            foodEatenEvent.Invoke();
            //if (other.CompareTag("Food"))
            //{
            //    Destroy(other.gameObject);
            //    var newBodyPart = Instantiate(_bodyPartPrefab);
            //    newBodyPart.transform.position = transform.position;
            //    newBodyPart.transform.parent = transform.parent;
            //    _bodyParts.Add(newBodyPart.transform);
            //    _score++;
            //    _scoreText.text = "Score: " + _score;
            //    CreateNewFood();
            //}
            //else
            //{
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //}
        }
    }
}