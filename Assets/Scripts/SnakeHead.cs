using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPartPrefab;
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
        if (!other.CompareTag("Food"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddNewBodyPart()
    {
        var newBodyPart = Instantiate(_bodyPartPrefab);
        newBodyPart.transform.position = transform.position;
        newBodyPart.transform.parent = transform.parent;
        _bodyParts.Add(newBodyPart.transform);
    }
    public List<Vector3> GetPartsPositions()
    {
        var res = new List<Vector3>();
        res.Add(this.transform.position);
        _bodyParts.ForEach(part => res.Add(part.position));
        return res;
    }
}
