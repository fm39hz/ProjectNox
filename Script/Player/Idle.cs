using System;
using GameSystem.Component.FiniteStateMachine;

namespace Actor.Attach.Player;

public partial class Idle : DynamicState
{
	public override void _Ready()
	{
		base._Ready();
		var _inputManager = Object.InputManager;
		_inputManager.MovementKeyPressed += SetCondition;
	}

	public override void SetCondition(bool condition)
	{
		if (!IsInitialized)
		{
			return;
		}

		Condition = !condition;
	}

	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Object.Velocity = Object.Velocity.MoveToward(Object.Information.Direction.AsVector * MaxSpeed,
			Friction * Convert.ToSingle(delta));
	}
}