﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private GameObject corridor;
    [SerializeField] private int numberOfRooms = 10;
    [SerializeField] private int spaceBeetwen = 10;
    private Queue<Node> roomToMake = new Queue<Node>();
    private int _gridX;
    private int _gridY;
    private Node[,] nodeGrid; 
    void Start()
    {
        _gridX = numberOfRooms + 4;
        _gridY = numberOfRooms + 4;
        int roomsCreated = 0;
        nodeGrid = new Node[_gridX, _gridY];
        nodeGrid[_gridX/2, _gridY/2] =  new Node(_gridX/2, _gridY/2, Direction.none);
        roomToMake.Enqueue(nodeGrid[_gridX/2, _gridY/2]);

        while(roomsCreated < numberOfRooms)
        {
            var currentRoom = roomToMake.Dequeue();
            currentRoom.Initalized = true;
            Instantiate(room, new Vector2
                        ((currentRoom.X - _gridX/2) * room.transform.lossyScale.x + (currentRoom.X - _gridX/2) * spaceBeetwen, 
                        (currentRoom.Y - _gridY/2) * room.transform.lossyScale.y + (currentRoom.Y - _gridY/2) * spaceBeetwen), 
                        Quaternion.identity);
            CheckNeighbours(currentRoom);
            roomsCreated++;
        }

        for(int x = 0; x < _gridX; x++)
        {
            for(int y = 0; y < _gridY; y++)
            {
                if (nodeGrid[x, y] != null)
                {
                    MakeCorridor(nodeGrid[x, y]);
                }
            }
        }
    }

    private void CheckNeighbours(Node node)
    {
        int randomNumber = Random.Range(1, 3);
        if (nodeGrid[node.X + 1, node.Y] == null && randomNumber == 1)
        {
            nodeGrid[node.X + 1, node.Y] = new Node(node.X + 1, node.Y, Direction.North);
            node.AddNeighbours(nodeGrid[node.X + 1, node.Y]);
            roomToMake.Enqueue(nodeGrid[node.X + 1, node.Y]);
        }
        randomNumber = Random.Range(1, 3);
        if (nodeGrid[node.X - 1, node.Y] == null && randomNumber == 1)
        {
            nodeGrid[node.X - 1, node.Y] = new Node(node.X - 1, node.Y, Direction.South);
            node.AddNeighbours(nodeGrid[node.X - 1, node.Y]);
            roomToMake.Enqueue(nodeGrid[node.X - 1, node.Y]);
        }
        randomNumber = Random.Range(1, 3);
        if (nodeGrid[node.X, node.Y + 1] == null && randomNumber == 1)
        {
            nodeGrid[node.X, node.Y + 1] = new Node(node.X, node.Y + 1, Direction.East);
            node.AddNeighbours(nodeGrid[node.X, node.Y + 1]);
            roomToMake.Enqueue(nodeGrid[node.X, node.Y + 1]);
        }
        randomNumber = Random.Range(1, 3);
        if (nodeGrid[node.X, node.Y - 1] == null && randomNumber == 1)
        {
            nodeGrid[node.X, node.Y - 1] = new Node(node.X, node.Y - 1, Direction.West);
            node.AddNeighbours(nodeGrid[node.X, node.Y - 1]);
            roomToMake.Enqueue(nodeGrid[node.X, node.Y - 1]);
        }
        if (roomToMake.Count == 0)
        {
            CheckNeighbours(node);
        }
    }
    private void MakeCorridor(Node node)
    {
        foreach(Node neighbourNode in node.listOfNeighbours)
        {
            if (neighbourNode.Initalized)
            {
                if (neighbourNode.DirNeighbour == Direction.North)
                {
                    Instantiate(corridor, new Vector2(
                        (node.X - _gridX/2) * room.transform.lossyScale.x + (node.X - _gridX/2) * spaceBeetwen + 30, 
                        (node.Y - _gridY/2) * room.transform.lossyScale.y + (node.Y - _gridY/2) * spaceBeetwen), 
                        Quaternion.Euler(0,0,0));
                }
                else if (neighbourNode.DirNeighbour == Direction.South)
                {
                    Instantiate(corridor, new Vector2(
                        (node.X - _gridX/2) * room.transform.lossyScale.x + (node.X - _gridX/2) * spaceBeetwen - 30, 
                        (node.Y - _gridY/2) * room.transform.lossyScale.y + (node.Y - _gridY/2) * spaceBeetwen), 
                        Quaternion.Euler(0,0,0));
                }
                else if (neighbourNode.DirNeighbour == Direction.East)
                {
                    Instantiate(corridor, new Vector2(
                        (node.X - _gridX/2) * room.transform.lossyScale.x + (node.X - _gridX/2) * spaceBeetwen, 
                        (node.Y - _gridY/2) * room.transform.lossyScale.y + (node.Y - _gridY/2) * spaceBeetwen + 30), 
                        Quaternion.Euler(0,0,90));
                }
                else if (neighbourNode.DirNeighbour == Direction.West)
                {
                    Instantiate(corridor, new Vector2(
                        (node.X - _gridX/2) * room.transform.lossyScale.x + (node.X - _gridX/2) * spaceBeetwen, 
                        (node.Y - _gridY/2) * room.transform.lossyScale.y + (node.Y - _gridY/2) * spaceBeetwen - 30), 
                        Quaternion.Euler(0,0,90));
                }
            }
        }
    }
}