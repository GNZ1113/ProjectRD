using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Spaceship : MonoBehaviour
{
	// ヒットポイント
    public float maxLife = 10;
    public float life = 10;
    public float redLife = 10;

    // 移動スピード
    public float speed;

	// 移動スピード（バフ）
	public float buffSpeed;

    //弱点属性
    [SerializeField, TooltipAttribute("0:無  1:火  2:水  3:風  4:雷  5:光  6:闇")]
    public int weekElement = -1;

    //耐性属性
    [SerializeField, TooltipAttribute("0:無  1:火  2:水  3:風  4:雷  5:光  6:闇")]
    public int resistElement = -1;
    
    // 爆発のPrefab
    public GameObject explosion;

	// アニメーターコンポーネント
	private Animator animator;

	void Start ()
	{
		// アニメーターコンポーネントを取得
		animator = GetComponent<Animator> ();
	}

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	// アニメーターコンポーネントの取得
	public Animator GetAnimator()
	{
		return animator;
	}
}