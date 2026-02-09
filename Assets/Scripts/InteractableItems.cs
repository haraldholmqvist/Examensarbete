using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string,string> examnineDictionary = new Dictionary<string,string>();
    [HideInInspector] public List<string> nounsInRoom = new List<string>();
    List<string> nounsInInventory = new List<string>();
    public string GetObjectNotInInventory(Room currentRoom, int i) {
        InteractableObject interactableInRoom = currentRoom.interactbleObjectsInRoom[i];
        if (!nounsInInventory.Contains(interactableInRoom.noun))
        { 
        nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }
        return null;
    }
    public void ClearCollections() { 
    examnineDictionary.Clear();
        nounsInRoom.Clear();
    }
}
