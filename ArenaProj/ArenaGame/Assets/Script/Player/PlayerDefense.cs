using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ArenaGame {
	
	public class PlayerDefense :MonoBehaviour{

		//public Button defenseButton;
		public bool damageReducedHalf = false;
		public bool canDef = true;

	
	
		public void Play_Defense() {
			if (PlayerController.Instance.isWalk == false && PlayerController.Instance.isAttack == false && canDef == true) {

				PlayerController.Instance.canMove = false;
				canDef = false;
				damageReducedHalf = true;
				PlayerController.Instance._rigidbody.isKinematic = true;

				PlayerController.Instance._animator.SetBool("isShieldOn", true);

				//defenseButton.gameObject.GetComponent<Button> ().enabled = false;

				Invoke("Play_DefenseOver", 1f);
			}
		}

		void Play_DefenseOver() {
			PlayerController.Instance.isShieldOn = false;
			damageReducedHalf = false;
			PlayerController.Instance.canMove = true;
			PlayerController.Instance._rigidbody.isKinematic = false;

			PlayerController.Instance._animator.SetBool("isShieldOn", false);
			PlayerController.Instance._animator.SetTrigger("stateComplete");


			Invoke ("Reset", 2f);
		}
		void Reset() {
			canDef = true;
		//	defenseButton.gameObject.GetComponent<Button> ().enabled = true;

		}

}
}
