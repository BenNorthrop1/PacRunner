
using UnityEngine;
namespace Player
{
    public class StandingState : State
    {


        // constructor
        public StandingState(PlayerScript player, StateMachine sm) : base(player, sm)
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

            if(!player.navMeshAgent.pathPending && player.navMeshAgent.remainingDistance < 0.5f)
            {
                sm.ChangeState(player.walkingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }
    }
}