using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private BoxCollider2D _boundaries;
    [SerializeField] private Transform _fruitThrowTransform;

    private Bounds _bounds;

    private float _topBound;
    private float _bottomBound;

    private float _startingTopBound;
    private float _startingBottomBound;

    private float _offset;

    private void Awake()
    {
        _bounds = _boundaries.bounds;

        _offset = transform.position.y - _fruitThrowTransform.position.y;

        _bottomBound = _bounds.min.y + _offset;
        _topBound = _bounds.max.y + _offset;

        _startingBottomBound = _bottomBound;
        _startingTopBound = _topBound;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position + new Vector3(0f, UserInput.MoveInput.y * _moveSpeed * Time.deltaTime, 0f);
        newPosition.y = Mathf.Clamp(newPosition.y, _bottomBound, _topBound);

        transform.position = newPosition;
    }

    public void ChangeBoundary(float extraHeight)
    {
        _bottomBound = _startingBottomBound;
        _topBound = _startingTopBound;

        _bottomBound += extraHeight; // Adjust these lines according to how you handle boundaries and inputs
        _topBound -= extraHeight;
    }
}
