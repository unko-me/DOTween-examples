using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EaseList : MonoBehaviour {

  [SerializeField] private GameObject sukiyaPrefab;
  private List<GameObject> dishes;
  void Start () {
    dishes = new List<GameObject>();

    var easeList = new List<Ease>();
    easeList.Add(Ease.InSine);
    easeList.Add(Ease.OutSine);
    easeList.Add(Ease.InOutSine);

    easeList.Add(Ease.InQuad);
    easeList.Add(Ease.OutQuad);
    easeList.Add(Ease.InOutQuad);

    easeList.Add(Ease.InQuart);
    easeList.Add(Ease.OutQuart);
    easeList.Add(Ease.InOutQuart);

    easeList.Add(Ease.InQuint);
    easeList.Add(Ease.OutQuint);
    easeList.Add(Ease.InOutQuint);

    easeList.Add(Ease.InExpo);
    easeList.Add(Ease.OutExpo);
    easeList.Add(Ease.InOutExpo);

    easeList.Add(Ease.InBack);
    easeList.Add(Ease.OutBack);
    easeList.Add(Ease.InOutBack);

    easeList.Add(Ease.InElastic);
    easeList.Add(Ease.OutElastic);
    easeList.Add(Ease.InOutElastic);

    easeList.Add(Ease.InBounce);
    easeList.Add(Ease.OutBounce);
    easeList.Add(Ease.InOutBounce);


    var param = new TweenParams().SetEase(Ease.OutExpo).SetLoops(-1, LoopType.Restart).SetDelay(1.5f);


    int i = 0;
    for (int y = 0; y < 4; y++)
    {
      for (int x = 0; x < 6; x++)
      {
        var xx = x * 4.5f;
        var yy = y * 3.0f;
        if (x > 2)
          xx += 2f;
        var obj = Instantiate(sukiyaPrefab, new Vector3(xx, yy, 0), Quaternion.identity);
        dishes.Add(obj);
        obj.transform.localScale = obj.transform.localScale * 2.5f;

        var path = GetPath(obj.transform.position);

        obj.transform.DOLocalPath(path.ToArray(), 3f, PathType.CatmullRom)
          .SetAs(param)
          .SetEase(easeList[i]);
      }
      i++;
    }


  }

  private List<Vector3> GetPath(Vector3 pos)
  {
    List<Vector3> path = new List<Vector3>();

    float angle = 0;
    float rad = 0.2f;
    float radInc = 0.07f;
    float angleInc = Mathf.PI * 0.3f;
    int max = 30;
    float y = 0.05f;



    for (int i = 0; i < max; i++)
    {
      path.Add(new Vector3(Mathf.Sin(angle) * rad,  y * (max - i) - max * y, Mathf.Cos(angle) * rad) + pos);
      rad += radInc;
      angle += angleInc;
    }
    return path;

  }

}
