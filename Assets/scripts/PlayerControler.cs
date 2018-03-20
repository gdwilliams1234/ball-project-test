using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerControler : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
    


    public int count;
	private Rigidbody rb;

    private bool isGrounded=false;

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
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded) {
            rb.AddForce(new Vector3(0, 500, 0));
            isGrounded = false;
        }

    }

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("pickup"))
		{
			other.gameObject.SetActive (false);
			count++;
			updateText (count);
		}
        if (other.gameObject.CompareTag("cake"))
        {
            winText.text = "You Win!";
        }

	}

	public void updateText(int counter){
		countText.text = "Count: " + count.ToString ();
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<floor>()!=null) {
            isGrounded = true;
        }
    }
}
