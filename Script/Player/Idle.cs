using GameSystem.Component.FiniteStateMachine;

namespace  Actor.Attach.Player;
	public partial class Idle : DynamicState{
		public override void _Ready(){
			base._Ready();
			var _inputManager = Object.InputManager;
			_inputManager.MovementKeyPressed += this.SetCondition;
			}
		public override void SetCondition(bool condition){
			if (!this.IsInitialized){
				return;
				}
			Condition = !condition;
			}
		}
