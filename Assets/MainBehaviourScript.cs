using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainBehaviourScript : MonoBehaviour {

	// Globals
	public Text DayText;
	public Text HourText;
	public Text MinuteText;
	public Text SecondText;

	public Text StartText;
	public Text EndText;

	public DateTime EndDate = new DateTime(2016,5,9);
	private DateTime StartDate = DateTime.Now;


	// Use this for initialization
	void Start () {		
		UpdateEndDay ();
	}

	void UpdateStartDay(){
		StartText.text = "Start: " + StartDate.ToString("MM:dd:hh:mm:ss");
	}

	void UpdateEndDay(){
		EndText.text = "End: " + EndDate.ToString("MM:dd:hh:mm:ss");
	}

	// Calculate the difference between today and end date
	private DateTime DateDiff(DateTime t){
		double s = EndDate.Subtract (t).TotalSeconds;
		TimeSpan ts = TimeSpan.FromSeconds(s);
		DateTime dt = DateTime.Today.Add(ts);
		// Return a new DateTime value for extraction
		return dt;
	}

	void UpdateCountdown(){
		//Extract the DateTime Values
		SecondText.text = (DateDiff (DateTime.Now)).ToString ("ss");
		MinuteText.text = (DateDiff (DateTime.Now)).ToString ("mm");
		HourText.text = (DateDiff (DateTime.Now)).ToString ("hh");
		//Having the same method produces an undesirable result so...yeah - make it unique
		DayText.text = Math.Round(EndDate.Subtract (DateTime.Now).TotalDays,0).ToString();
	}

	public void AddADay(){
		EndDate = EndDate.AddDays (1);
		UpdateEndDay ();
	}

	public void SubtractADay(){
		EndDate = EndDate.AddDays (-1);
		UpdateEndDay ();
	}

	
	// Update is called once per frame
	void Update () {
		UpdateStartDay ();
		UpdateCountdown ();
	}
}
