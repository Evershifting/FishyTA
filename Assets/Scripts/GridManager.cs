using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _sizeX, _sizeY;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField]
    private List<Cell> Cells = new List<Cell>();

    public int SizeX { get => _sizeX; private set => _sizeX = value; }
    public int SizeY { get => _sizeY; private set => _sizeY = value; }


    private void Awake()
    {
        InitiateLevel();
    }

    public void InitiateLevel()
    {
        ClearGrid();
        GenerateField(SizeX, SizeY);
    }

    public void ClearGrid()
    {
        for (int i = Cells.Count; i > 0; i--)
        {
            Destroy(Cells[i - 1].gameObject);
            Cells.RemoveAt(Cells.Count - 1);
        }
    }
    private void GenerateField(int SizeX, int SizeY)
    {
        GameObject gameObject;
        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                gameObject = Instantiate(_cellPrefab, Cell0x0() + Vector3.right * i + Vector3.forward * j, _cellPrefab.transform.rotation, transform);
                gameObject.AddComponent<Cell>().Init(this, new Vector2(i, j));
                Cells.Add(gameObject.GetComponent<Cell>());
            }
        }
    }

    private Vector3 Cell0x0()
    {
        return new Vector3((float)SizeX / 2 - _cellPrefab.transform.localScale.x / 2, 0, (float)SizeY / 2 - _cellPrefab.transform.localScale.y / 2) * (-1);
    }

    public Cell GetNextCell(Cell currentPostion, Vector3 direction)
    {
        Vector2 nextCellPosition = currentPostion.GridPosition + new Vector2((int)direction.x, (int)direction.z);

        if (nextCellPosition.x >= SizeX)
            nextCellPosition.x = SizeX - 2;
        if (nextCellPosition.y >= SizeY)
            nextCellPosition.y = SizeY - 1;

        if (nextCellPosition.x < 0)
            nextCellPosition.x = 1;
        if (nextCellPosition.y < 0)
            nextCellPosition.y = 0;

        return GetCellByVector2(nextCellPosition);
    }
    public Cell GetNextCell(Vector3 currentPostion, Vector3 direction)
    {
        return GetNextCell(GetCellByVector3(currentPostion), direction);
    }
    public Cell GetCellByVector2(Vector2 position)
    {
        return Cells[(int)position.x * SizeY + (int)position.y];
    }

    public Cell GetCellByVector3(Vector3 position)
    {
        position -= Cell0x0();
        return GetCellByVector2(new Vector2(position.x, position.z));
    }
}
