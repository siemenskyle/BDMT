using UnityEngine;
using System.Collections;

public class ResetIndicators : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		if (ScoreCounter.leftScore == 11) {
			Application.LoadLevel (4);
		}
		//if player 2 won, load player 2 win screen
		else if (ScoreCounter.rightScore == 11) {
			Application.LoadLevel (5);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdieSpawn>().isPlaying)
			animator.SetTrigger("serve");
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool ("out", false);
		animator.SetBool ("p1", false);
		animator.SetBool ("p2", false);
		animator.SetBool ("start", false);
		GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent< playermove >().setwait(false);
		GameObject.FindGameObjectWithTag("PlayerRight").GetComponent< playermove >().setwait(false);
		GameObject.FindGameObjectWithTag("Bird").GetComponent< BirdieSpawn >().setwait(false);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
