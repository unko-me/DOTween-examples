using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MakimakiMain : MonoBehaviour {
  [SerializeField] private Transform target;
  [SerializeField] private Transform target2;
  [SerializeField] private Transform target3;

  // Use this for initialization
	void Start () {

	  List<Vector3> path = new List<Vector3>();
	  List<Vector3> path2 = new List<Vector3>();
	  List<Vector3> path3 = new List<Vector3>();

	  float angle = 0;
	  float rad = 0.2f;
	  float radInc = 0.05f;
	  float angleInc = Mathf.PI * 0.3f;
	  int max = 30;
	  float y = 0.1f;
	  var pos = target.position;
	  var pos2 = target2.position;
	  var pos3 = target3.position;
	  target.transform.position = new Vector3(pos.x, y * max, pos.z);
	  target2.transform.position = new Vector3(pos2.x, y * max, pos2.z);
	  target3.transform.position = new Vector3(pos3.x, y * max, pos3.z);


	  for (int i = 0; i < max; i++)
	  {
	    path.Add(new Vector3(Mathf.Sin(angle) * rad,  y * (max - i), Mathf.Cos(angle) * rad) + pos);
	    path2.Add(new Vector3(Mathf.Sin(angle) * rad,  y * (max - i), Mathf.Cos(angle) * rad) + pos2);
	    path3.Add(new Vector3(Mathf.Sin(angle) * rad,  y * (max - i), Mathf.Cos(angle) * rad) + pos3);
	    rad += radInc;
	    angle += angleInc;
	  }

	  target.transform.DOLocalPath(path.ToArray(), 3f, PathType.CatmullRom).SetLoops(-1, LoopType.Restart).SetDelay(1.5f);
	  target2.transform.DOLocalPath(path2.ToArray(), 3f, PathType.CatmullRom).SetLoops(-1, LoopType.Incremental).SetDelay(1.5f);
	  target3.transform.DOLocalPath(path3.ToArray(), 3f, PathType.CatmullRom).SetLoops(-1, LoopType.Yoyo).SetDelay(1.5f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
