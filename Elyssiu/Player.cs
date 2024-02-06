using Godot;
using Godot.NativeInterop;
using System;
using System.Numerics;

public partial class Player : Sprite2D
{

	[Export] private TileMap tileMap;
	[Export] private Sprite2D sprite;
	Boolean isMoving = false;
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
		if (isMoving == false) {
			return;
		}
		if (GlobalPosition.Equals(sprite.GlobalPosition)) { //Whenever we press a movement key, the actual player object will tp to the tile ahead and the player sprite will catch up to it.
			isMoving = false;
			return;
		}

		sprite.GlobalPosition = sprite.GlobalPosition.MoveToward(GlobalPosition, 2);


    }

    public override void _Process(double delta)
	{
		if (!isMoving) {
			if (Input.IsActionPressed("up")) { //process movement
				Move(Godot.Vector2.Up);
			} else if (Input.IsActionPressed("down")) {
				Move(Godot.Vector2.Down);
			} else if (Input.IsActionPressed("left")) {
				Move(Godot.Vector2.Left);
			} else if (Input.IsActionPressed("right")) {
				Move(Godot.Vector2.Right);
			}
		}
	}

	public void Move(Godot.Vector2 direction) {
		//get current tile position
		Vector2I currentTile = tileMap.LocalToMap(GlobalPosition);
		//get target tile position
		Vector2I targetTile = new Vector2I(
			(int) (currentTile.X + direction.X),
			(int) (currentTile.Y + direction.Y)
		);
		//check if walkable (get custom data layer of tile)
		TileData tileData = tileMap.GetCellTileData(0, targetTile);

		if ((int)tileData.GetCustomData("walkable") == 0) return;
		
		// walk
		isMoving = true;

		GlobalPosition = tileMap.MapToLocal(targetTile);

		sprite.GlobalPosition = tileMap.MapToLocal(currentTile);

	}
}
