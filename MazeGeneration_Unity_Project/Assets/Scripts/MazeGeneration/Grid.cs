using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    public Cell[,] cells;
    public Grid(Vector2Int gridSize)
    {
        cells = new Cell[gridSize.x, gridSize.y];
        CreateGrid();
        AddNeighbours();
        
    }
    private void CreateGrid()
    {
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new Cell(new Vector2Int(x, y));
               
            }
        }
    }
    public void DrawGrid(GameObject cellWall)
    {
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y].DrawCell(cellWall);
            }
        }
    }
    private void AddNeighbours()
    {
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y].SetNeighbours(cells);
                
            }
        }
    }

    public void DestroyGrid()
    {
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y].DestroyCell();
            }
        }
    }

}
