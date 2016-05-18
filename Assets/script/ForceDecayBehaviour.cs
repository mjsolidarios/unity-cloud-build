using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForceDecayBehaviour : MonoBehaviour {
	// Globals
	public Text debug;
	Rigidbody2D itemRigidBody;
	Collider2D itemCollider = null;
	public Vector2 touchStartPos;
	public Vector2 touchDirection;
	public bool directionChosen;
	bool appliedForce = false;

	// Use this for initialization
	void Start () {
		itemRigidBody = GetComponent<Rigidbody2D>();
		itemCollider = gameObject.GetComponent<Collider2D>();

	}		
	
	// Update is called once per frame
	void Update () {

		int nbTouches = Input.touchCount;

		if (nbTouches > 0) {
			for (int i = 0; i < nbTouches; i++) {
				Touch touch = Input.GetTouch(i);
				TouchPhase phase = touch.phase;
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
				{		
					switch(phase)
					{
					// Record initial touch position
					case TouchPhase.Began:
						touchStartPos = touch.position;
						directionChosen = false;
						break;

						// Determine direction by comparing the current touch position with the initial one
					case TouchPhase.Moved:
						touchDirection = touch.position - touchStartPos;
						// Check if the force has been applied so that it can only fire once
						if (!appliedForce) {
							// Apply force using the touch direction.
							itemRigidBody.AddForce (touchDirection * 500);
							// Apply a small force decay per frame
							itemRigidBody.drag += 0.01f;
							// Display what object was touched
							debug.text = "Touched object: " + GetInstanceID().ToString();
							// Report that the force has been applied
							appliedForce = true;
						}
						break;

						// Report that a direction has been chosen when the finger is lifted
					case TouchPhase.Ended:
						directionChosen = true;
						break;
					}
				}
			}
		}

	}
}