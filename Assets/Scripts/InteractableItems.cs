using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string,string> examnineDictionary = new Dictionary<string,string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
    [HideInInspector] public List<string> nounsInRoom = new List<string>();
    List<string> nounsInInventory = new List<string>();
    GameController controller;
    private void Awake()
    {
        controller = GetComponent<GameController>();
    }
    public string GetObjectNotInInventory(Room currentRoom, int i) {
        InteractableObject interactableInRoom = currentRoom.interactbleObjectsInRoom[i];
        if (!nounsInInventory.Contains(interactableInRoom.noun))
        { 
        nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }
        return null;
    }
    public void DisplayInventory()
    {
        controller.LogStringWithReturn("You look in your backpack, inside you have: ");
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(nounsInInventory[i]);
        }
    }
    public void ClearCollections() { 
    examnineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }
    public Dictionary<string, string> Take(string[] separatedInputWords) { 
    string noun = separatedInputWords[1];
        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        else controller.LogStringWithReturn("There is no " + noun + " here to take");
        return null;
    }
}
