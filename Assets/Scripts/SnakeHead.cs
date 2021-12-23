using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPartPrefab;
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private TextMesh _scoreText;
    private int _score = 0;
    private Vector3? _direction = null;
    private List<Transform> _bodyParts;

    private void Start()
    {
        _bodyParts = new List<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _direction = new Vector3(0, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = new Vector3(0, 0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            _direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        if (_direction == null) return;
        var previousHeadPosition = this.transform.position;
        this.transform.position = new Vector3(this.transform.position.x + _direction.Value.x, this.transform.position.y + _direction.Value.y, this.transform.position.z + _direction.Value.z);
        MoveBodyParts(previousHeadPosition);
    }

    private void MoveBodyParts(Vector3 previousHeadPosition)
    {
        if (_direction == null) return;
        for (int i = _bodyParts.Count -1 ; i >= 0; i--)
        {
            _bodyParts[i].transform.position = (i == 0 ) ? previousHeadPosition : _bodyParts[i - 1].transform.position;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            var newBodyPart = Instantiate(_bodyPartPrefab);
            newBodyPart.transform.position = transform.position;
            //newBodyPart.transform.position = new Vector3(0, 0, -99);
            newBodyPart.transform.parent = transform.parent;
            _bodyParts.Add(newBodyPart.transform);
            _score++;
            _scoreText.text = "Score: " + _score;
            CreateNewFood();
        }
        else
        {
            // DIE
        }
    }

    private void CreateNewFood()
    {
        var newFoodOptions = new List<Vector3>();

        for (int i = 1; i < 30; i++)
        {
            for (int j = 1; j < 30; j++)
            {
                newFoodOptions.Add(new Vector3(i, 0, j));
            }
        }

        newFoodOptions.Remove(this.transform.position);

        for (int i = 0; i < this._bodyParts.Count; i++)
        {
            newFoodOptions.Remove(_bodyParts[i].position);
        }
        System.Random rnd = new System.Random();
        int newFoodIndex = rnd.Next(newFoodOptions.Count);

        Instantiate(_foodPrefab, newFoodOptions[newFoodIndex], new Quaternion());
    }
}
