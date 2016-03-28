using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace ArenaGame
{
    public class PlayerController : MonoBehaviour
    {	

		private static PlayerController instance;
		private PlayerController() {
		}
		public static PlayerController Instance {
			get {
				if (instance == null) {
					instance = GameObject.FindObjectOfType (typeof(PlayerController)) as PlayerController;
				}
				return instance;
			}
		}


        [HideInInspector] public GameObject _gameObject;
        [HideInInspector] public Animator _animator;
        [HideInInspector] public Transform _transform;
        [HideInInspector] public Rigidbody2D _rigidbody;
		public Scrollbar hpScroll;


        [Header("Bool")]
        public bool isIdle = true;
        public bool isWalk = false;
        public bool isAttack = false;
        public bool facingRight = true;
		public bool canMove = true;
		public bool isShieldOn = false;


		[Header("Player Stats")]
		public static int MaxHP = 100;
        private int currentHP;
        public int CurrentHP
        {
			get { return currentHP = MaxHP; }
        }

		private PlayerAttack playerAttS=null;
		private PlayerDefense playerDefS=null;

		public PlayerAttack PlayerAttS {
			get {
				if (playerAttS == null)
					playerAttS = this.GetComponent<PlayerAttack> ();
				return playerAttS;
			}
		}
		public PlayerDefense PlayerDefS {
			get {
				if (playerDefS == null)
					playerDefS = this.GetComponent<PlayerDefense> ();
				return playerDefS;
			}
		}


		//public PlayerDefense playDefS;

        [Header("Speed")]
        [Range(0,5f)]
        public float maxSpeed = 2f;
        [Range(0,10)]   
        public int attackDamage = 2;

        //-----------------------------------------------------------------------UNITY FUNCTIONS-------------------------------------------------------------------------------//
        public virtual void Awake()
        {	
            _gameObject = this.gameObject;
            _animator = this.gameObject.GetComponent<Animator>();
            _transform = this.gameObject.GetComponent<Transform>();
            _rigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        }

        void Start()
		{	instance = null;
            isIdle = true;
            isWalk = false;
            isAttack = false;
            Play_Idle();
			UIStats ();
        }

        void FixedUpdate()
        {
			if (Input.GetKey (KeyCode.F)) {
				isAttack = true;
				PlayerAttS.Play_Attack ();
			} 
			else if (Input.GetKey (KeyCode.G)) {
				isShieldOn = true;
				PlayerDefS.Play_Defense ();
			}
			else if(canMove == true) {
				float move = Input.GetAxisRaw ("Horizontal");
				_rigidbody.velocity = new Vector2 (move * maxSpeed, _rigidbody.velocity.y);
				_animator.SetFloat ("HorizontalMove", Mathf.Abs (move));

				if (move > 0)
					_gameObject.GetComponent<SpriteRenderer> ().flipX = true;
				else if (move < 0)
					_gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			}
		
			}

            
        

        void OnTriggerStay2D(Collider2D col) {
			if (col.gameObject.tag == "Enemy" && isAttack == true) {
            }
        }

        //----------------------------------------------------------------------- FUNCTIONS-------------------------------------------------------------------------------//

        void Play_Idle()
        {
            if (isIdle == true && isWalk == false && isAttack == false)
                _animator.SetBool("isIdle", true);
        }
		void UIStats() {
			hpScroll.GetComponent<Scrollbar>().size = CurrentHP/MaxHP;
		}

    

    }
}
