using GameSystem.Component.Manager;
using GameSystem.Component.Object.Composition;
using GameSystem.Utils;

public partial class PlayerBody : Creature
{
	public InputManager InputManager { get; protected set; }
	public override void _EnterTree()
	{
		base._EnterTree();
		InputManager = this.GetFirstChildOfType<InputManager>();
	}
}
