using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] Constant.Direction NeedOpenDoor;

    private RoomTemplate templates;
    
    private int rand = 0;
    private bool isSpawned = false;

    public void Start()
    {
        templates = FindObjectOfType<RoomTemplate>();
        Invoke("SpawnRoom", 1f);
    }

    private void SpawnRoom()
    {
        if(isSpawned == false)
        {
            if(NeedOpenDoor == Constant.Direction.Bottom)
            {
            // Need to spawn a room with a BOTTOM door.
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            } 
            else if(NeedOpenDoor == Constant.Direction.Top)
            {
                // Need to spawn a room with a TOP door.
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                
            }
            else if(NeedOpenDoor == Constant.Direction.Left)
            {
                // Need to spawn a room with a LEFT door.
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            } 
            else if(NeedOpenDoor == Constant.Direction.Right)
            {
                // Need to spawn a room with a RIGHT door.
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            isSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().isSpawned == true && isSpawned == false){
				Destroy(gameObject);
			} 
			isSpawned = true;
		}
	}

}
