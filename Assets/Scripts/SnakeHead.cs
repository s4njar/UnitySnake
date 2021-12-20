using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPartPrefab;
    private Vector2 _direction = Vector2.right;
    private List<Transform> _bodyParts;

    private void Start()
    {
        _bodyParts = new List<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        var previousHeadPosition = this.transform.position;
        this.transform.position = new Vector3(this.transform.position.x + _direction.x, this.transform.position.y + _direction.y);
        MoveBodyParts(previousHeadPosition);
    }

    private void MoveBodyParts(Vector3 previousHeadPosition)
    {
        for (int i = _bodyParts.Count -1 ; i >= 0; i--)
        {
            _bodyParts[i].transform.position = (i == 0 ) ? previousHeadPosition : _bodyParts[i - 1].transform.position;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            var newBodyPart = Instantiate(_bodyPartPrefab);
            //newBodyPart.transform.position = transform.position;
            newBodyPart.transform.position = new Vector3(0, 0, -99);
            newBodyPart.transform.parent = transform.parent;
            _bodyParts.Add(newBodyPart.transform);
        }
        else
        {
            // DIE
        }
    }

    private void CreateNewFood()
    {
        var newBodyPart = Instantiate(_bodyPartPrefab);
    }
}
