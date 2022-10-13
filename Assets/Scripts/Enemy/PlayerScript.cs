using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Animator anim;

        public Transform[] targets;

        int points;

        public Transform playerTransform;
        public int destPoints;


        public StateMachine sm;

        // Add your variables holding the different player states here
        public StandingState standingState;

        public WalkingState walkingState;


        

        // Start is called before the first frame update
        void Start()
        {

            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();

            sm = gameObject.AddComponent<StateMachine>();

            standingState = new StandingState(this, sm);
            walkingState = new WalkingState(this, sm);
            
            
            sm.Init(standingState);
        }
        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();
        }

        public void HandleMoveToPoints()
        {
            if(targets.Length == 0)
            {
                return;
            }

            points = Random.Range(0, targets.Length);
            navMeshAgent.destination = targets[points].transform.position;
        }

        


        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }
    }

}