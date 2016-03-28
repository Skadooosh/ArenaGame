using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ArenaGame
{
	public class PlayerAttack : MonoBehaviour {

		//public Button attackButton;
		public bool alreadyAttacking = false;

     
		public void Play_Attack() {
			if (PlayerController.Instance.isAttack == true && alreadyAttacking == false && PlayerController.Instance.isShieldOn == false ) {
				alreadyAttacking = true;
				PlayerController.Instance.canMove = false;
				PlayerController.Instance._animator.SetBool("Attack", true);
				PlayerController.Instance._animator.SetTrigger("isAttacking");
				PlayerController.Instance._rigidbody.isKinematic = true;
                Invoke("Play_AttackOver", 0.8f);
	            }  
        }

        void Play_AttackOver() {
			PlayerController.Instance.isAttack = false;
			PlayerController.Instance._animator.SetBool("Attack", false);
			alreadyAttacking = false;
			PlayerController.Instance.canMove = true;
			PlayerController.Instance._animator.SetTrigger("stateComplete");
			PlayerController.Instance._rigidbody.isKinematic = false;

		//	Invoke ("Reset", 3f);
        }
		/*
		void Reset() {
			attackButton.gameObject.GetComponent<Button> ().enabled = true;		
		}
*/


    }
}
