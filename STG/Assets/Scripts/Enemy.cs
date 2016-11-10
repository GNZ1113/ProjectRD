using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	// 激突時の攻撃力
	public float power = 100;



	// Spaceshipコンポーネント
	Spaceship spaceship;

	void Start ()
	{
		
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
        
	}

	// 機体の移動
	public void Move (Vector2 direction)
	{
		GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
	}


    void OnTriggerStay2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet(player)") return;

        // Bulletコンポーネントを取得
        Bullet bullet = c.GetComponent<Bullet>();

        //弱点、耐性の処理
        if(bullet.element == spaceship.resistElement)
        { bullet.power = bullet.power * 0.5f; }

        if (bullet.element == spaceship.weekElement)
        { bullet.power = bullet.power * 2.0f; }

        // ヒットポイントを減らす
        spaceship.life = spaceship.life - bullet.power;

        ////赤ゲージの制御
        DG.Tweening.DOTween.To(() => spaceship.redLife, (n) => spaceship.redLife = n, spaceship.life, 2.0f);


        //// 弾の削除
        //Destroy(c.gameObject);

        // ヒットポイントが0以下であれば
        if (spaceship.life <= 0)
        {
            // 爆発
            spaceship.Explosion();

            // エネミーの削除
            Destroy(gameObject);

        }
        else
        {
            // Damageトリガーをセット
            spaceship.GetAnimator().SetTrigger("Damage");

        }
    }


    void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		// レイヤー名がBullet (Player)以外の時は何も行わない
		if (layerName != "Bullet(player)") return;

		// Bulletコンポーネントを取得
		Bullet bullet = c.GetComponent<Bullet>();

        //弱点、耐性の処理
        if (bullet.element == spaceship.resistElement)
        { bullet.power = bullet.power * 0.5f; }

        if (bullet.element == spaceship.weekElement)
        { bullet.power = bullet.power * 2.0f; }

        // ヒットポイントを減らす
        spaceship.life = spaceship.life - bullet.power;

        ////赤ゲージの制御
        DG.Tweening.DOTween.To(() => spaceship.redLife, (n) => spaceship.redLife = n, spaceship.life, 2.0f);

        //// 弾の削除
        //Destroy(c.gameObject);

        // ヒットポイントが0以下であれば
        if (spaceship.life <= 0 )
		{
			// 爆発
			spaceship.Explosion ();
			
			// エネミーの削除
			Destroy (gameObject);

		}else{
			// Damageトリガーをセット
			spaceship.GetAnimator().SetTrigger("Damage");
		
		}
	}



}