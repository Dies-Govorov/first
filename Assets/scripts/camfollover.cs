using UnityEngine;

public class camfollover : MonoBehaviour {

	public Transform player;

	
	// Update is called once per frame
	public void FixedUpdate () {
		transform.position = new Vector3 (player.position.x, player.position.y,transform.position.z);
	}
}
