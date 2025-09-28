using UnityEngine;

namespace CommonSolutions.Runtime.AsyncTools
{

    public class WaitForAnimatorStateCompleted : CustomYieldInstruction
    {

        private readonly Animator _animator;
        private readonly string _state;
        private readonly int _layerIndex;

        public WaitForAnimatorStateCompleted(Animator animator, string state, int layerIndex = 0)
        {
            _animator = animator;
            _state = state;
            _layerIndex = layerIndex;
        }

        public override bool keepWaiting => _animator != null &&
                                            (!_animator.isActiveAndEnabled ||
                                            !_animator.GetCurrentAnimatorStateInfo(_layerIndex).IsName(_state) ||
                                            _animator.GetCurrentAnimatorStateInfo(_layerIndex).normalizedTime < 1);

    }

}