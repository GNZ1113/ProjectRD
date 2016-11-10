using UnityEngine;

public class Bullet : MonoBehaviour
{
	// 弾の移動スピード
	public int speed = 0;

	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime = 1;

	// 攻撃力
	public float power = 1;

	// ホーミング精度
	public float homingPower = 0;

	// ホーミング頻度
	public float homingTime = 0;

    //弾の属性  0:無  1:火  2:水  3:風  4:雷  5:光  6:闇
    [SerializeField, TooltipAttribute("0:無  1:火  2:水  3:風  4:雷  5:光  6:闇")]
    public int element = 0;

	void Start ()
	{
		// ローカル座標のY軸方向に移動する
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;

		// lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}
}