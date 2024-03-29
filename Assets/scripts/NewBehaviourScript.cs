using UnityEngine;
using UnityEngine.UI;
using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;


public class NewBehaviourScript : MonoBehaviour {

	public int health = 10;
	public Slider healthSlider;

	private Animator anim;
	public float speed = 20f;
	private Rigidbody2D rb;
	// Use this for initialization
	bool facingLeft = false;
	public float jumpForce = 200f;

	public Text score;
	public int playerScore;
	public string playerName;

	public InputField nameText;

	private System.Random random = new System.Random ();
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = this.GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {
		healthSlider.value = health;
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (new Vector2 (0, 300f));
			jumpForce = 200f;
			if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (new Vector2 (0, jumpForce));{
				//float moveX = Input.GetAxis("Horizontal");
				//rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
				}
			}
		}
	}


	 void FixedUpdate () {
		float moveX = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector3 (moveX * speed, rb.velocity.y);
		anim.SetFloat ("speed", Mathf.Abs (moveX));
	}
		
void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (null != collision) {
			Bomb bombObj = collision.gameObject.GetComponent<Bomb>();
			if (null != bombObj) {
				bombObj.ifCollision ();	
			}
			Debug.Log ("Collision");
		}
	}
	public void onSubmit(){
		playerName = nameText.text;
		PostToDB ();
	}
	private void PostToDB(){
		Firebase firebase = Firebase.CreateNew("https://budemdelatbazudannihiproverat.firebaseio.com","");
		FirebaseQueue firebaseQueue = new FirebaseQueue(true, 3, 1f);
		firebaseQueue.AddQueuePush (firebase.Child (playerName, true), "{ \"score\": " + playerScore + "}", true);
	}
}