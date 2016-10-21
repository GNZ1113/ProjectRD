// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Gets the pressed state of the specified Button and stores it in a Bool Variable. /Custom to Event")]
	public class GetButtonCustom : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName;		

		[Tooltip("Event to send if the button is pressed.")]
		public FsmEvent sendEvent;

		[Tooltip("Set to True if the button is pressed.")]
		[UIHint(UIHint.Variable)]
		public FsmBool storeResult;

		[Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset()
		{
			buttonName = "Fire1";
			sendEvent = null;
			storeResult = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{	
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoGetButton();
			var button = Input.GetButton(buttonName.Value);

			if (button)
			{
				Fsm.Event(sendEvent);
			}
		}

		void DoGetButton()
		{
			storeResult.Value = Input.GetButton(buttonName.Value);
		}
	}
}

