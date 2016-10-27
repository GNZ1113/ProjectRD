using UnityEngine;
using HutongGames.PlayMaker;
namespace HutongGames.PlayMaker.Actions {
    [ActionCategory(ActionCategory.Animation)]
    [Tooltip("Observe an animation finished and send the event.")]
    public class AnimationFinishedEvent : FsmStateAction {

        [RequiredField]
        [CheckForComponent(typeof(UnityEngine.Animator))]
        [Tooltip("The GameObject to be observed.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [Tooltip("Send this event when animation finished.")]
        public FsmEvent sendEvent;

        [RequiredField]
        [Tooltip("The name of the animation to be observed.")]
        public FsmString animationName;

        private Animator animator;

        public override void Reset() {
            gameObject = null;
            sendEvent = null;
            animationName = null;
        }

        // Code that runs on entering the state.
        public override void OnEnter() {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            animator = go.GetComponent<Animator>();
        }

        // Code that runs every frame.
        public override void OnUpdate() {
            var a = animator.GetCurrentAnimatorStateInfo(0);
            if (a.IsName(animationName.Value) && a.normalizedTime >= 1f) {
                Fsm.Event(sendEvent);
            }
        }
    }
}