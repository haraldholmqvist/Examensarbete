using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;

    List<string> actionLog = new List<string>();

    void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }
    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }
    public void DisplayRoomText()

    {
        ClearCollectionsForNewRoom();
        UnpackRoom();
        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.CurrentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }
    void UnpackRoom() {
        roomNavigation.UnpackExistsInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.CurrentRoom);
    }
    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactbleObjectsInRoom.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectNotInInventory(currentRoom, i);
            if (descriptionNotInInventory != null)
            {
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }
        }
    }
    void ClearCollectionsForNewRoom() { 
    interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
