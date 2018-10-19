using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	//private Collider2D myCollider;
	//var Ponpon_die : Animation;
	public bool enemyHit;
	public bool Hit;

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	private float speedMultiplierStore;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoneStore;
	public float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;
	private bool stopJumping;
	private bool canDoubleJump;

	public int health;
	public int numOfHearts;
	public int maxHealth;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;


	private Animator myAnimator;

	public GameManager theGameManager;

	private Rigidbody2D myRigidBody;

	public bool hit;

	private PowerupManager thePowerupManager;




	// Use this for initialization
	void Start () {

		myRigidBody = GetComponent <Rigidbody2D> ();
		//myCollider = GetComponent<Collider2D> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedMultiplierStore = speedMultiplier;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		stopJumping = true;
		myAnimator = GetComponent<Animator> ();
		Hit = false;
		health= Mathf.Clamp(health,0, maxHealth);
		thePowerupManager = FindObjectOfType<PowerupManager> ();
	}


	// Update is called once per frame
	void Update () {
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
//		hit = OnCollisionEnter2D;
		for (int i = 0; i < hearts.Length; i++) {

			if (i < health) {
				hearts [i].sprite = fullHeart;
			} else {
				hearts [i].sprite = emptyHeart;
			}

			if (i < numOfHearts) {
				hearts [i].enabled = true;
			} else {
				hearts [i].enabled = false;
			}
		}

		if (transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;

		}

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);
	
			
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				stopJumping = false;
				canDoubleJump = true;

			}

			if (!grounded && canDoubleJump ) {

				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				stopJumping = false;
				jumpTimeCounter = jumpTime;
				canDoubleJump = false;
			}

		}

		if ( Input.GetKey (KeyCode.Space) && !stopJumping )  {
			if (jumpTimeCounter > 0) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			
			}
		}

	
		if (Input.GetKeyUp (KeyCode.Space))  {
			jumpTimeCounter = 0;
			stopJumping = true;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
		myAnimator.SetBool ("Hit", Hit);
		myAnimator.SetBool ("Powerup", thePowerupManager.powerupActive);
		//myAnimator.SetBool ("Hit", OnCollisionEnter2D);

		//if (EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) return;
		//if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			//if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId)) return;
	}




	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "killbox") {
			
			Hit = true;
			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedMultiplier = speedMultiplierStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			//myAnimator.SetTrigger ("Ponpon_jump");
			//GetComponent<Animator>().SetTrigger("Ponpon_die");
//			gameObject.animation.Play("Ponpon_die");
		}

	if (other.gameObject.tag == "enemybox"){
		//health --;

			Hit = true;
			health=health-1;
			//gameObject.animation.Play("Ponpon_die");
		
		//GetComponent<Animator>().SetTrigger("Ponpon_die");
	//	myAnimator.SetTrigger ("Ponpon_die");

			other.gameObject.SetActive (false);


			if (health <= 0) {
				theGameManager.RestartGame ();
				moveSpeed = moveSpeedStore;
				speedMilestoneCount = speedMilestoneCountStore;
				speedMultiplier = speedMultiplierStore;
				speedIncreaseMilestone = speedIncreaseMilestoneStore;
			}
	}




}

	void LateUpdate(){

		Hit=false;

	}

	/*public void RunOutOfHealth(){
		if (health = 0) {
			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedMultiplier = speedMultiplierStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
	}*/


}
