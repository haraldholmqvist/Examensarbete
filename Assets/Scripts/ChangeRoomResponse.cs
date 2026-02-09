using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    public Room roomToChangeTo;
    public override bool DoActionResponse(GameController controller)
    {
        if (controller.roomNavigation.CurrentRoom.roomName == requiredString)
        { 
        controller.roomNavigation.CurrentRoom = roomToChangeTo;
            controller.DisplayRoomText();
            return true;
        }
        return false;
    }
}
