
using UnityEngine;
namespace Player
{
    public class WalkingState : State
    {


        // constructor
        public WalkingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.HandleMoveToPoints();
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

            
            if(!player.navMeshAgent.pathPending && player.navMeshAgent.remainingDistance < 0.5f)
            {
                sm.ChangeState(player.standingState);
            }

            if(player.navMeshAgent.remainingDistance < .2f)
            {
                player.navMeshAgent.destination = player.playerTransform.position;

            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }

    }
}