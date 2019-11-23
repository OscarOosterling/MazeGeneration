using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject maze;
    Vector2 mazeSize;

    // Start is called before the first frame update
    void Start()
    {
        ReloadCamera();
    }
    public void ReloadCamera()
    {
        mazeSize = new Vector2(maze.GetComponent<Maze>().grid.cells.GetLength(0),
                                maze.GetComponent<Maze>().grid.cells.GetLength(1));
        transform.position = mazeSize / 2;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        Camera.main.orthographicSize = Mathf.Max(mazeSize.x, mazeSize.y) / 2 + 1;
    }
}
