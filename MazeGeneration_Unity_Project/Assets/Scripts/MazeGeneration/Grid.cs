using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Made by Oscar Oosterling
 * 
 * Grid class is used by Maze.cs
 * 
 * This script creates a grid of Cells and prepares those cells by adding neighbours
 * */
public class Grid
{
    public Cell[,] cells;

    public Grid(Vector2Int gridSize)
    {
        cells = new Cell[gridSize.x, gridSize.y];
        CreateGrid();
        AddNeighbours();        
    }
    // CreateGrid fills every cells index with a Cell, this Cell will get a unique x and y.
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
    // DrawGrid calls for every cell the function DrawCell().
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
    // AddNeighbours calls for every cell the function SetNeighbours().
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
    // DestroyGrid calls for every cell the function DestroyCell().
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
