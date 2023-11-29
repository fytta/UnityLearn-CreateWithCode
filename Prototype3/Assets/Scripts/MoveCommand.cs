
using UnityEngine;

public class MoveCommand : ICommand
{
    private PlayerController player;
    private Vector3 movement;

    public MoveCommand(PlayerController player, Vector3 moveVector)
    {
        this.player = player;
        this.movement = moveVector;
    }

    public void Execute()
    {
        player.Move(movement);
    }

    public void Undo()
    {
        player.Move(-movement);
    }
}