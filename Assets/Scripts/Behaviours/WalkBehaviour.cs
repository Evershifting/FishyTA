using UnityEngine;

internal class WalkBehaviour : IMoveBehaviour
{
    internal GridManager _gridManager;
    internal GameObject gameObject;
    internal float _speed = 1f, _diagonalDistance = 0f;

    internal bool _isMoving = false;
    internal Vector3 _startPosition, _targetPosition;

    public WalkBehaviour(float speed, GameObject gameObject, GridManager grid)
    {
        _speed = speed;
        this.gameObject = gameObject;
        _gridManager = grid;
    }

    public void Move()
    {
        if (!_isMoving)
        {
            _startPosition = gameObject.transform.position;
            _targetPosition = GetNewDestination();
            _isMoving = true;
        }

        if (Vector3.SqrMagnitude(_targetPosition - gameObject.transform.position) < Mathf.Epsilon)
        {
            gameObject.transform.position = _targetPosition;
            _isMoving = false;
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    internal virtual Vector3 GetNewDestination()
    {
        return _gridManager.GetNextCell(gameObject.transform.position, Vector3.back).Position;
    }

}