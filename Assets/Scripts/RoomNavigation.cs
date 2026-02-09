using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomNavigation : MonoBehaviour
{
    public Room CurrentRoom;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    GameController controller;
    private void Awake()
    {
        controller = GetComponent<GameController>();
    }
    public void UnpackExistsInRoom()
    {
        for (int i = 0; i < CurrentRoom.exits.Length; i++)
        {
            exitDictionary.Add(CurrentRoom.exits[i].keyString, CurrentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(CurrentRoom.exits[i].exitDescription);
        }
    }
    public void AttemptToChangeRooms(string DirectionNoun)
    {
        if (exitDictionary.ContainsKey(DirectionNoun))
        {
            CurrentRoom = exitDictionary[DirectionNoun];
            controller.LogStringWithReturn("You head off to the " + DirectionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no path to the " + DirectionNoun);
        }
    }
    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
