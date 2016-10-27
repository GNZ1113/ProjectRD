// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.UnityObject)]
    [ActionTarget(typeof(Component), "targetProperty")]
    [ActionTarget(typeof(GameObject), "targetProperty")]
	[Tooltip("Gets the value of any public property or field on the targeted Unity Object and stores it in a variable. E.g., Drag and drop any component attached to a Game Object to access its properties.")]
	public class GetPropertyCUSTOM : FsmStateAction
	{
		[Tooltip("The GameObject that owns the component.")]
		public FsmOwnerDefault gameObject;

		[UIHint(UIHint.Variable)]
		[RequiredField]
		[Tooltip("Store the component in an Object variable.\nNOTE: Set theObject variable's Object Type to get a component of that type. E.g., set Object Type to UnityEngine.AudioListener to get the AudioListener component on the camera.")]
		public FsmObject storeProperty;

		[Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset()
		{
			gameObject = null;
			storeProperty = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoGetProperty();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoGetProperty();
		}

		void DoGetProperty()
		{
			if (storeProperty == null)
			{
				return;
			}

			var targetObject = Fsm.GetOwnerDefaultTarget(gameObject);

			if (targetObject == null)
			{
				return;
			}

			if (storeProperty.IsNone)
			{
				return;
			}

			storeProperty.Value = targetObject.GetComponent(storeProperty.ObjectType);
		}
	}
}