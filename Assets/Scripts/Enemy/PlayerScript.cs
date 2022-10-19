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

        public bool isFollowingTarget;

        public int destPoints;

        public float followDetectionRadius;

        public float playerDistance;

        public StateMachine sm;

        // Add your variables holding the different player states here
        public StandingState standingState;

        public WalkingState walkingState;

        public FollowState followState;


        

        // Start is called before the first frame update
        void Start()
        {

            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();

            sm = gameObject.AddComponent<StateMachine>();

            standingState = new StandingState(this, sm);
            walkingState = new WalkingState(this, sm);
            followState = new FollowState(this, sm);
            
            
            sm.Init(standingState);
        }
        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();

            playerDistance = Vector3.Distance(playerTransform.transform.position, transform.position);
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

        public void HandleFollowPlayer()
        {
            navMeshAgent.destination = playerTransform.transform.position;
        }


        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }
    }

}