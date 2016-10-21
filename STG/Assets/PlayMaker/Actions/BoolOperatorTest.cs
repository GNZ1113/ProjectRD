using UnityEngine;
namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Logic)]
	[Tooltip("Performs boolean operations on 2 Bool Variables.")]
	public class BoolOperatorTest : FsmStateAction
	{
		public enum Operation
		{
			AND,
			NAND,
			OR,
			XOR
		}

		[RequiredField]
		[Tooltip("The first Bool variable.")]
		public FsmBool bool1;

		[RequiredField]
		[Tooltip("The second Bool variable.")]
		public FsmBool bool2;

		[Tooltip("Boolean Operation.")]
		public Operation operation;

		[Tooltip("Event to send if the Bool variable is True.")]
		public FsmEvent isTrue;

		[Tooltip("Event to send if the Bool variable is False.")]
		public FsmEvent isFalse;

		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a Bool Variable.")]
		public FsmBool storeResult;

		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;

		public override void Reset()
		{
			bool1 = false;
			bool2 = false;
			operation = Operation.AND;
			storeResult = null;
			everyFrame = false;
			isTrue = null;
			isFalse = null;
		}

		public override void OnEnter()
		{
			DoBoolOperator();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoBoolOperator();
		}

		void DoBoolOperator()
		{
			var v1 = bool1.Value;
			var v2 = bool2.Value;

			switch (operation)
			{
			case Operation.AND:
				storeResult.Value = v1 && v2;
				break;

			case Operation.NAND:
				storeResult.Value = !(v1 && v2);
				break;

			case Operation.OR:
				storeResult.Value = v1 || v2;
				break;

			case Operation.XOR:
				storeResult.Value = v1 ^ v2;
				break;
			}

			Fsm.Event(storeResult.Value ? isTrue : isFalse);
		}
	}
}