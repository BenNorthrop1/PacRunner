
using UnityEngine;
namespace Player
{
    public class FollowState : State
    {


        // constructor
        public FollowState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
           
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.HandleFollowPlayer();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }

    }
}