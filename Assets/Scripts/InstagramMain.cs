using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.VR;

public class InstagramMain : MonoBehaviour
{
  [SerializeField] private Transform target;

  void Start()
  {
    var rot = target.transform.eulerAngles;
    var pos = target.transform.position;
    var scale = target.transform.localScale.x;

    Sequence seq = DOTween.Sequence();
    seq.SetLoops(-1);
    seq.Append(target.DOMoveX(-0.5f, 1f).SetEase(Ease.InOutQuint));
    seq.Join(target.DOMoveZ(-1.8f, 1f).SetEase(Ease.InOutQuint).SetRelative());
//    seq.Join(target.DOScale(scale * 1.5f, 1f).SetEase(Ease.InOutQuint));

    seq.AppendInterval(0.4f);
    seq.Append(target.DOMoveX(0.5f, 1f).SetEase(Ease.InOutQuint));
    seq.Join(target.DORotate(new Vector3(45, 150, 0), 1f).SetEase(Ease.InOutQuint));

    seq.AppendInterval(0.4f);
    seq.Append(target.DOMove(pos, 1f).SetEase(Ease.InOutQuint));
    seq.Join(target.DORotate(rot, 1f).SetEase(Ease.InOutQuint));
//    seq.Join(target.DORotate(new Vector3(-39f, 0, 0), 2f));

    seq.AppendInterval(0.4f);
    seq.Append(target.DOShakePosition(1f, new Vector3(0.5f, 0.5f, 0), 300)).SetDelay(1f);
    // Delay the whole Sequence by 1 second
    seq.PrependInterval(1);

//	  // Insert a scale tween for the whole duration of the Sequence
    ///
  }
}