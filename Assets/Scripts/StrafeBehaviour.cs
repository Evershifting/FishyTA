using UnityEngine;

internal class StrafeBehaviour : WalkBehaviour
{
    public StrafeBehaviour(float speed, float diagonalDistance, GameObject gameObject, GridManager grid) : base(speed, gameObject, grid)
    {
        _diagonalDistance = diagonalDistance;
    }

    internal override Vector3 GetNewDestination()
    {
        return _gridManager.GetNextCell(gameObject.transform.position, Vector3.back + Vector3.right * _diagonalDistance * Random.Range(-1, 2)).Position;
    }
}