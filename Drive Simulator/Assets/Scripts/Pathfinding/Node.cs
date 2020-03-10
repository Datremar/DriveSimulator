using UnityEngine;
using System.Collections;

public class Node
{

    private bool walkable;
    private Vector3 worldPosition;
    private int gridX;
    private int gridY;

    private int gCost;
    private int hCost;
    private Node parent;

    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public bool Walkable { get => walkable; set => walkable = value; }
    public Vector3 WorldPosition { get => worldPosition; set => worldPosition = value; }
    public int GridX { get => gridX; set => gridX = value; }
    public int GridY { get => gridY; set => gridY = value; }
    public int GCost { get => gCost; set => gCost = value; }
    public int HCost { get => hCost; set => hCost = value; }
    public Node Parent { get => parent; set => parent = value; }
}