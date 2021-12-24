using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] private GameObject _foodPrefab;
        public UnityEvent foodEatenEvent;


        public void CreateNewFood()
        {
            foodEatenEvent.Invoke();
            var newFood = Instantiate(_foodPrefab);
            newFood.GetComponent<Food>().foodEatenEvent.AddListener(CreateNewFood);
            System.Random rnd = new System.Random();
            newFood.gameObject.transform.position = new Vector3(rnd.Next(29) + 1, 0, rnd.Next(30) + 1);
            

            //var newFoodOptions = new List<Vector3>();

            //for (int i = 1; i < 30; i++)
            //{
            //    for (int j = 1; j < 30; j++)
            //    {
            //        newFoodOptions.Add(new Vector3(i, 0, j));
            //    }
            //}

            //newFoodOptions.Remove(this.transform.position);

            //for (int i = 0; i < this._bodyParts.Count; i++)
            //{
            //    newFoodOptions.Remove(_bodyParts[i].position);
            //}
            //System.Random rnd = new System.Random();
            //int newFoodIndex = rnd.Next(newFoodOptions.Count);

            //Instantiate(_foodPrefab, newFoodOptions[newFoodIndex], new Quaternion());
        }
    }
}