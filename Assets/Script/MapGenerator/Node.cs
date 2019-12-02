using System.Collections;
using System.Collections.Generic;

public class Node
{
    public readonly int X;
    public readonly int Y;

    public bool Initalized = false;
    public readonly Direction DirNeighbour;
    public List<Node> listOfNeighbours { get; private set; }

    public Node(int x, int y, Direction dir)
    {
        listOfNeighbours = new List<Node>();
        DirNeighbour = dir;
        X = x;
        Y = y;
    }

    public void AddNeighbours(Node neighbourNode)
    {
        listOfNeighbours.Add(neighbourNode);
    }
}
