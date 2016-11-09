using UnityEngine;

public class Hoge : MonoBehaviour
{
    private float reloadTimeOwn;
    private float reloadTime;
    private string reloadTimeStr;

    //  Numがカスタムプロパティ

    void Update()
    {
        reloadTime = reloadTimeOwn;
        DG.Tweening.DOTween.To(() => reloadTime, (n) => reloadTime = n, 0, reloadTimeOwn);
    }
}