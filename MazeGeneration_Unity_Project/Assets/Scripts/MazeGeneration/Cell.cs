using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Made by Oscar Oosterling
 * 
 * Cell class is used by Grid.cs and Maze.cs
 * This script Creates a Cell and assigns other Cells as its neighbours.
 * */
public class Cell : MonoBehaviour
{
    private static float offset = 0.5f;
    public Vector2Int coordinates;
    public Dictionary<string, Cell> neighbours = new Dictionary<string, Cell>();
    public Dictionary<string, bool> walls = new Dictionary<string, bool>();
    public Dictionary<string, string> oppositeWall = new Dictionary<string, string>();
    public List<GameObject> wallObjects = new List<GameObject>();
    public bool isVisited = false;


    public Cell(Vector2Int _coordinates)
    {
        this.coordinates = _coordinates;
        AssignWalls();
    }
    // AssignWalls prepares the Cell to disable and enable walls.
    void AssignWalls()
    {
        walls.Add("LeftWall", true);
        walls.Add("UpperWall", true);
        walls.Add("RightWall", true);
        walls.Add("LowerWall", true);
        oppositeWall.Add("LeftWall", "RightWall");
        oppositeWall.Add("RightWall", "LeftWall");
        oppositeWall.Add("UpperWall", "LowerWall");
        oppositeWall.Add("LowerWall", "UpperWall");
    }

    //SetNeigbours adds neighbouring Cells to Current Cell
    public void SetNeighbours(Cell[,] cells)
    {
        if (IsInBounds(new Vector2(coordinates.x - 1, coordinates.y), cells))
        {
            neighbours.Add("LeftWall", cells[coordinates.x - 1, coordinates.y]);
        }
        if (IsInBounds(new Vector2(coordinates.x, coordinates.y - 1), cells))
        {
            neighbours.Add("UpperWall", cells[coordinates.x, coordinates.y - 1]);
        }
        if (IsInBounds(new Vector2(coordinates.x + 1, coordinates.y), cells))
        {
            neighbours.Add("RightWall", cells[coordinates.x + 1, coordinates.y]);
        }
        if (IsInBounds(new Vector2(coordinates.x, coordinates.y + 1), cells))
        {
            neighbours.Add("LowerWall", cells[coordinates.x, coordinates.y + 1]);
        }
    }
    // IsInBounds checks if the given coordinate is within bounds
    private bool IsInBounds(Vector2 neighbourCoordinate, Cell[,] cells)
    {
        if (neighbourCoordinate.x >= 0 && neighbourCoordinate.x < cells.GetLength(0) &&
           neighbourCoordinate.y >= 0 && neighbourCoordinate.y < cells.GetLength(1))
        {
            return true;
        }
        return false;
    }
    // DrawCell checks if a wall exists and instantiates it.
    public void DrawCell(GameObject cellWall)
    {
        if (walls["LeftWall"])
        {
            GameObject leftWall = Instantiate(cellWall, new Vector2(coordinates.x - offset, coordinates.y), Quaternion.identity);
            leftWall.name = "leftWall";
            wallObjects.Add(leftWall);
        }
        if (walls["UpperWall"])
        {
            GameObject upperWall = Instantiate(cellWall, new Vector2(coordinates.x, coordinates.y - offset), Quaternion.Euler(0, 0, 90));
            upperWall.name = "UpperWall";
            wallObjects.Add(upperWall);
        }
        if (walls["RightWall"])
        {
            GameObject rightWall = Instantiate(cellWall, new Vector2(coordinates.x + offset, coordinates.y), Quaternion.identity);
            rightWall.name = "RightWall";
            wallObjects.Add(rightWall);
        }
        if (walls["LowerWall"])
        {
            GameObject lowerWall = Instantiate(cellWall, new Vector2(coordinates.x, coordinates.y + offset), Quaternion.Euler(0, 0, 90));
            lowerWall.name = "LowerWall";
            wallObjects.Add(lowerWall);
        }
    }
    // Destroy Cell removes all walls from current cell.
    public void DestroyCell()
    {
        for (int i = 0; i < wallObjects.Count; i++)
        {
            Destroy(wallObjects[i]);
        }
    }
}
