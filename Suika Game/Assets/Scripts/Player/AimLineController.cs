using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineController : MonoBehaviour
{
    [SerializeField] private Transform _fruitThrowTransform;
    [SerializeField] private Transform _leftTransform;  // Adjusted from _bottomTransform to _leftTransform
    [SerializeField] private Transform _rightTransform; // New Transform to define the right boundary

    private LineRenderer _lineRenderer;

    private float _leftPos;
    private float _rightPos;
    private float _y;  // Now using y instead of x

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _y = _fruitThrowTransform.position.y; // Constant y position
        _leftPos = _leftTransform.position.x; // x-coordinate of the left end
        _rightPos = _rightTransform.position.x; // x-coordinate of the right end

        _lineRenderer.SetPosition(0, new Vector3(_leftPos, _y)); // Left endpoint of the line
        _lineRenderer.SetPosition(1, new Vector3(_rightPos, _y)); // Right endpoint of the line
    }

    private void OnValidate()
    {
        if (!_lineRenderer) _lineRenderer = GetComponent<LineRenderer>();

        _y = _fruitThrowTransform.position.y;
        _leftPos = _leftTransform.position.x;
        _rightPos = _rightTransform.position.x;

        _lineRenderer.SetPosition(0, new Vector3(_leftPos, _y));
        _lineRenderer.SetPosition(1, new Vector3(_rightPos, _y));
    }
}
