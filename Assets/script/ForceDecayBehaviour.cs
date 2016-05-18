using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForceDecayBehaviour : MonoBehaviour {

	public Text debug;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				debug.text = GetInstanceID().ToString();

			}
		}


/*		
		int nbTouches = Input.touchCount;

		if(nbTouches > 0)
		{
			for (int i = 0; i < nbTouches; i++)
			{
				Touch touch = Input.GetTouch(i);

				TouchPhase phase = touch.phase;

				switch(phase)
				{
				case TouchPhase.Began:
					
					break;
				case TouchPhase.Moved:
					
					break;
				case TouchPhase.Stationary:
					
					break;
				case TouchPhase.Ended:
					
					break;
				case TouchPhase.Canceled:
					
					break;
				}
			}
		}
		*/
	}
}
