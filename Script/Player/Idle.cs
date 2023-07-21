using GameSystem.Component.FiniteStateMachine;

namespace  Actor.Target.Player;
	public partial class Idle : DynamicState{
		public override void _Ready(){
			base._Ready();
			var _inputManager = Object.ObjectInputManager;
			_inputManager.MovementKeyPressed += this.SetCondition;
			}
		public override void SetCondition(bool condition){
			if (!this.IsInitialized){
				return;
				}
			Condition = !condition;
			}
		}
