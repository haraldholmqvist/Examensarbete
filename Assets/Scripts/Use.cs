using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.interactableItems.UseItem(seperatedInputWords);
    }
}
