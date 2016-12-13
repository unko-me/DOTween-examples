using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  // Grab a free Sequence to use
	  Sequence mySequence = DOTween.Sequence();
	  // Add a movement tween at the beginning
	  mySequence.Append(transform.DOMoveX(45, 1));
	  // Add a rotation tween as soon as the previous one is finished
	  mySequence.Append(transform.DORotate(new Vector3(0,180,0), 1));
	  // Delay the whole Sequence by 1 second
	  mySequence.PrependInterval(1);
	  // Insert a scale tween for the whole duration of the Sequence
	  mySequence.Insert(0, transform.DOScale(new Vector3(3,3,3), mySequence.Duration()));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
