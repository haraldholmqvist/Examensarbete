using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomNavigation : MonoBehaviour
{
    public Room CurrentRoom;
    GameController controller;
    private void Awake()
    {
        controller = GetComponent<GameController>();
    }
    public void UnpackExistsInRoom()
    {
        for (int i = 0; i < CurrentRoom.exits.Length; i++)
        {
            controller.interactionDescriptionsInRoom.Add(CurrentRoom.exits[i].exitDescription);
        }
    }
}
