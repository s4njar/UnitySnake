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


        private Vector3 GetNewFoodPosition()
        {
            var newFoodOptions = new List<Vector3>();

            for (int i = 1; i < 30; i++)
            {
                for (int j = 1; j < 30; j++)
                {
                    newFoodOptions.Add(new Vector3(i + 1, 0, j + 1));
                }
            }

            var snakeHeads = FindObjectsOfType<SnakeHead>();

            foreach (var head in snakeHeads)
            {
                head.GetPartsPositions().ForEach(position => newFoodOptions.Remove(position));
            }

            System.Random rnd = new System.Random();
            int newFoodIndex = rnd.Next(newFoodOptions.Count);

            return newFoodOptions[newFoodIndex];
        }

        public void CreateNewFood()
        {
            foodEatenEvent.Invoke();
            var newFood = Instantiate(_foodPrefab);
            newFood.GetComponent<Food>().foodEatenEvent.AddListener(CreateNewFood);
            System.Random rnd = new System.Random();
            newFood.gameObject.transform.position = GetNewFoodPosition();
        }
    }
}