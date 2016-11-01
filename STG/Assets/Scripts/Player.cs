using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;

    void Start ()
	{
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
    }

	void Update()
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");
		
		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;
		
		// 移動の制限
		Move (direction);
	}

	// 機体の移動
	void Move (Vector2 direction)
	{
		// 画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		
		// プレイヤーの座標を取得
		Vector2 pos = transform.position;
		
		// 移動量を加える
		pos += direction  * spaceship.speed * spaceship.buffSpeed * Time.deltaTime;

		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;
	}

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        //// レイヤー名がBullet (Enemy)の時は弾を削除
        //if (layerName == "Bullet(enemy)")
        //{
        //    // 弾の削除
        //    Destroy(c.gameObject);
        //}

        // レイヤー名がBullet (Enemy)の場合
        if (layerName == "Bullet(enemy)")
        {
            // enemyBulletのTransformを取得
            Transform enemyBulletTransform = c.transform.parent;

            // Bulletコンポーネントを取得
            Bullet bullet = enemyBulletTransform.GetComponent<Bullet>();

            // ヒットポイントを減らす
            spaceship.life = spaceship.life - bullet.power;

            ////赤ゲージの制御
            DG.Tweening.DOTween.To(() => spaceship.redLife, (n) => spaceship.redLife = n, spaceship.life, 2.0f);

            spaceship.GetAnimator().SetTrigger("Damage");

        }

        // レイヤー名がEnemyの場合
        if (layerName == "Enemy")
        {

            // Enemyコンポーネントを取得
            Enemy enemy = c.GetComponent<Enemy>();

            // ヒットポイントを減らす
            spaceship.life = spaceship.life - enemy.power;

            ////赤ゲージの制御
            DG.Tweening.DOTween.To(() => spaceship.redLife, (n) => spaceship.redLife = n, spaceship.life, 2.0f);

            spaceship.GetAnimator().SetTrigger("Damage");

        }

        // ヒットポイントが0以下であれば
        if (spaceship.life <= 0)
        {
            //// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
            //FindObjectOfType<Manager>().GameOver();

            //// 爆発する
            //spaceship.Explosion();

            // プレイヤーを削除
            Destroy(gameObject);

        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        //// レイヤー名がBullet (Enemy)の時は弾を削除
        //if (layerName == "Bullet(enemy)")
        //{
        //    // 弾の削除
        //    Destroy(c.gameObject);
        //}

        // レイヤー名がBullet (Enemy)の場合
        if (layerName == "Bullet(enemy)")
        {
            // enemyBulletのTransformを取得
            Transform enemyBulletTransform = c.transform.parent;

            // Bulletコンポーネントを取得
            Bullet bullet = enemyBulletTransform.GetComponent<Bullet>();

            // ヒットポイントを減らす
            spaceship.life = spaceship.life - bullet.power;

            ////赤ゲージの制御
            DG.Tweening.DOTween.To(() => spaceship.redLife, (n) => spaceship.redLife = n, spaceship.life, 2.0f);

            spaceship.GetAnimator().SetTrigger("Damage");

        }

        // レイヤー名がEnemyの場合
        if (layerName == "Enemy")
        {

            // Enemyコンポーネントを取得
            Enemy enemy = c.GetComponent<Enemy>();

            // ヒットポイントを減らす
            spaceship.life = spaceship.life - enemy.power;

            ////赤ゲージの制御
            DG.Tweening.DOTween.To(() => spaceship.redLife, (n) => spaceship.redLife = n, spaceship.life, 2.0f);

            spaceship.GetAnimator().SetTrigger("Damage");

        }

        // ヒットポイントが0以下であれば
        if (spaceship.life <= 0)
        {
            //// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
            //FindObjectOfType<Manager>().GameOver();

            //// 爆発する
            //spaceship.Explosion();

            // プレイヤーを削除
            Destroy(gameObject);

        }
    }
}