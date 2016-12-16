using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Main : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private Transform target2;
  [SerializeField] private Transform target3;
  [SerializeField] private Transform target4;

	// Use this for initialization
	void Start () {
	  // Grab a free Sequence to use
//	  DOTween.timeScale
	  Sequence mySequence = DOTween.Sequence();
	  mySequence.SetLoops(-1);

	  // Add a movement tween at the beginning
	  mySequence.Append(target.DOMoveX(0.5f, 1));
	  mySequence.Append(target.DOMoveX(-0.5f, 1));
	  // Add a rotation tween as soon as the previous one is finished
	  mySequence.Append(target.DORotate(new Vector3(0,180,0), 1));
	  // Delay the whole Sequence by 1 second
	  mySequence.PrependInterval(1);
//	  // Insert a scale tween for the whole duration of the Sequence
	  mySequence.Insert(0, target.DOScale(new Vector3(3,3,3), 2f));
///

	  var xx = 2.5f;
	  var duration = 1.0f;
//
//	  target.transform.DOLocalMoveX(xx, duration).SetEase(Ease.OutQuad).SetLoops(-1).SetDelay(0.5f);
//	  target2.transform.DOLocalMoveX(xx, duration).SetEase(Ease.OutQuint).SetLoops(-1).SetDelay(0.5f);
//	  target3.transform.DOLocalMoveX(xx, duration).SetEase(Ease.OutExpo).SetLoops(-1).SetDelay(0.5f);
//	  target4.transform.DOLocalMoveX(xx, duration).SetEase(Ease.OutElastic).SetLoops(-1).SetDelay(0.5f);

	  target2.transform.DOLocalPath(new Vector3[]
	  {
	    new Vector3 (0.2f, 1f), Vector3.zero, new Vector3 (-3f, 2f)
	  }, 3f, PathType.CatmullRom).SetLoops(-1).SetDelay(0.5f).SetRelative();
	  target3.transform.DOLocalPath(new Vector3[]
	  {
	    new Vector3 (0.2f, 1f), Vector3.zero, new Vector3 (-3f, 2f)
	  }, 3f).SetLoops(-1).SetDelay(0.5f).OnWaypointChange(OnWayPointChange);

	  var param = new TweenParams().SetEase(Ease.OutElastic).SetDelay(1.0f);
//	  target3.transform.DOLocalMoveX(xx, duration).SetAs(param);
	  target4.transform.DOLocalMoveX(xx, duration).SetAs(param).From();


//	  DOVirtual.Float(0f, 1f, 5f, value =>
//	  {
//      Debug.Log("value: " + value);
//	  });

	}

  private void OnWayPointChange(int value)
  {
    Debug.Log("OnWayPointChange: " + value);
  }

  // Update is called once per frame
	void Update () {
		
	}
}
