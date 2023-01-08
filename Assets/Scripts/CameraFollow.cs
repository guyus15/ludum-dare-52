using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;

    [SerializeField] private float _lookAheadFactor = 3;
    [SerializeField] private float _damping;

    [SerializeField] private Transform _target;

    private Vector2 _lastTargetPosition;
    private Vector2 _currentVelocity;
    private Vector2 _lookAheadPosition;

    private void Start()
    {
        _lastTargetPosition = _target.position;
    }

    private void Update()
    {
        if (_target == null) return;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moveDelta = mousePosition - _lastTargetPosition;

        bool updateLookAheadFactor = moveDelta.x > 0 || moveDelta.y > 0;

        if (updateLookAheadFactor)
        {
            float[] deltas;
            deltas = new float[] { moveDelta.x, moveDelta.y };

            _lookAheadPosition = _lookAheadFactor * mousePosition.normalized * Mathf.Sign(deltas.Max());
        }

        Vector2 aheadTargetPos = (Vector2)_target.position + _lookAheadPosition;
        aheadTargetPos = new Vector2(aheadTargetPos.x + _offsetX, aheadTargetPos.y + _offsetY);
        Vector2 newPos = Vector2.SmoothDamp(transform.position, aheadTargetPos, ref _currentVelocity, _damping);

        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

        _lastTargetPosition = _target.position;
    }
}