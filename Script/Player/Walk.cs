using System;
using GameSystem.Component.FiniteStateMachine;

namespace Actor.Attach.Player;

public partial class Walk : StaticState
{
	public PlayerBody Target { get; set; }
	public override void _EnterTree()
	{
		base._EnterTree();
		Target = StateMachine.GetParent<PlayerBody>();
	}
	public override void _Ready()
	{
		base._Ready();
		var _inputManager = Target.InputManager;
		_inputManager.MovementKeyPressed += SetCondition;
		_inputManager.ActionKeyPressed += ResetCondition;
	}

	// public override void SetCondition(bool condition){
	// 	base.SetCondition(condition);
	// 	if (Target.Velocity.IsZeroApprox() && !StateController.PreviousState.IsState(this)){
	// 		Condition = false;
	// 		}
	// 	}
	public override void RunningState(double delta)
	{
		base.RunningState(delta);
		Target.Velocity = Target.Velocity.MoveToward(Target.InputManager.TopDownVector(Target.Velocity) * MaxSpeed,
			Acceleration * Convert.ToSingle(delta));
	}
}