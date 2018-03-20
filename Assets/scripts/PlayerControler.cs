using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerControler : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
    


    public int count;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		updateText (count);
	}

	void FixedUpdate ()
	{
		float moveHorizontail = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontail, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
         

    }

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("pickup"))
		{
			other.gameObject.SetActive (false);
			count++;
			updateText (count);
		}

	}

	public void updateText(int counter){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}
}
