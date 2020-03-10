using UnityEngine;

public class TileGrid : MonoBehaviour
{

    public GameObject wall, roadTile, crossroadsTile;

    public float offset;

    private string[,] grid;
    private GameObject[,] nodeGrid;
    private GameObject[,] objGrid;

    public static bool isAllowed = false;

    void Awake()
    {
        objGrid = new GameObject[40, 40];
        nodeGrid = new GameObject[160, 160];
        grid = GraphBuilder.BuildRoads();

        float x, y, z;

        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {

                x = transform.position.x + j * offset;
                y = transform.position.y;
                z = transform.position.z + i * offset;

                if (grid[i, j] == " V ")
                {
                    objGrid[i, j] = Instantiate(roadTile, new Vector3(x, y, z), transform.rotation).gameObject;
                }
                if (grid[i, j] == " H ")
                {
                    objGrid[i, j] = Instantiate(roadTile, new Vector3(x, y, z), Quaternion.Euler(Vector3.up * 90f)).gameObject;
                }
                if (grid[i, j] == " @ ")
                {
                    objGrid[i, j] = Instantiate(crossroadsTile, new Vector3(x, y, z), transform.rotation).gameObject;
                }
                if (grid[i, j] == " . ")
                {
                    objGrid[i, j] = Instantiate(wall, new Vector3(x, y, z), transform.rotation).gameObject;
                }
            }
        }

        isAllowed = true;
    }

    public GameObject[,] GetObjGrid()
    {
        return objGrid;
    }

    public GameObject[,] GetNodeGrid()
    {
        return nodeGrid;
    }
}