using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IppaiMain : MonoBehaviour
{

  [SerializeField] private GameObject sukiyaPrefab;
  private List<GameObject> dishes;
	void Start () {
	  dishes = new List<GameObject>();


	  var param = new TweenParams().SetEase(Ease.OutExpo).SetLoops(-1, LoopType.Yoyo);
	  for (int y = 0; y < 10; y++)
	  {
	    for (int x = 0; x < 10; x++)
	    {
	      var xx = x * 0.5f;
	      var yy = y * 0.5f;
	      var obj = Instantiate(sukiyaPrefab, new Vector3(xx, 0, yy), Quaternion.identity);
	      dishes.Add(obj);

	      obj.transform.DOLocalMoveY(-1f, 0.5f).SetAs(param).SetDelay(x * 0.03f);
//	      obj.transform.DORotate(new Vector3(-40f, 60f, 30f), 1.5f).SetAs(param).SetDelay(x * 0.03f);
	    }
	  }


	}

  void Update()
  {
    foreach (var dish in dishes)
    {

      dish.transform.Rotate(new Vector3(1f, 0.2f, -0.1f), 10f);
    }
  }
	
}
