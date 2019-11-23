using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
    public Vector2Int mazeSize;
    public Grid grid;
    private Cell currentCell;
    public GameObject CellWall;
    private GameObject backGround;
    private Stack<Cell> visitedCells;

    public Slider sliderMazeSizeX;
    public Slider sliderMazeSizeY;

    private Vector2 backGroundOffset = new Vector2(0.5f, 0.5f);

    // Start is called before the first frame update
    void Awake()
    {
        ReloadMaze();
    }

    public void ReloadMaze()
    {     
        mazeSize.x = (int)sliderMazeSizeX.GetComponent<Slider>().value;
        mazeSize.y = (int)sliderMazeSizeY.GetComponent<Slider>().value;
        grid = new Grid(new Vector2Int(mazeSize.x, mazeSize.y));
        MazeGeneration();
        DrawBackground();
        grid.DrawGrid(CellWall);

    }
    public void DestroyMaze()
    {
        Destroy(backGround);
        grid.DestroyGrid();
    }

    void MazeGeneration()
    {
        currentCell = grid.cells[0, 0];
        currentCell.isVisited = true;
        visitedCells = new Stack<Cell>();
        while (HasUnvisitedCells())
        {
            while (HasUnvisitedNeighbours(currentCell))
            {
                string neighbourIndex = PickNeighbour(currentCell);
                RemoveWalls(currentCell, neighbourIndex);
                visitedCells.Push(currentCell);
                currentCell = currentCell.neighbours[neighbourIndex];
                currentCell.isVisited = true;
            }
            BackTrack();
        }

        


        
    }
    void BackTrack()
    {
        currentCell = visitedCells.Pop();
    }
    bool HasUnvisitedCells()
    {
        foreach(Cell cell in grid.cells)
        {
            if (!cell.isVisited)
            {
                return true;
            }
        }
        return false;
    }
    bool HasUnvisitedNeighbours(Cell currentCell)
    {
        foreach (KeyValuePair<string, Cell> entry in currentCell.neighbours)
        {
            if (!(entry.Value.isVisited))
            {
                return true;
            }
        }
        return false;
    }
    string PickNeighbour(Cell currentCell)
    {
        string neighbour = "";
        do
        {
            neighbour = currentCell.neighbours.ElementAt(Random.Range(0, currentCell.neighbours.Count)).Key;
        } while (currentCell.neighbours[neighbour].isVisited);
        return neighbour;
    }
    void RemoveWalls(Cell currentCell, string neighbourIndex)
    {
        currentCell.walls[neighbourIndex] = false;
        currentCell.neighbours[neighbourIndex].walls[currentCell.oppositeWall[neighbourIndex]] = false;
    }

    void DrawBackground()
    {
        backGround = Instantiate(CellWall);
        backGround.transform.localScale = new Vector3(mazeSize.x,mazeSize.y,0);
        if(mazeSize.x % 2 == 0)
        {
            backGroundOffset.x = 0.5f;
        }
        else
        {
            backGroundOffset.x = 0;
        }
        if (mazeSize.y % 2 == 0)
        {
            backGroundOffset.y = 0.5f;
        }
        else
        {
            backGroundOffset.y = 0;
        }
        backGround.transform.position = new Vector3(mazeSize.x / 2 - backGroundOffset.x, mazeSize.y / 2-backGroundOffset.y, 1);
        backGround.GetComponent<SpriteRenderer>().color = Color.black;
    }


}
