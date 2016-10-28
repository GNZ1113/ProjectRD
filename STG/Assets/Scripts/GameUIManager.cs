using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIManager : MonoBehaviour
{

    private Player player;

    public Image lifeGage;
    public Image lifeRedGage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        this.initParameter();
    }

    void Update()
    {
        lifeGage.fillAmount = player.life / player.maxLife;
    }

    private void initParameter()
    {
        lifeGage = GameObject.Find("LifeGage").GetComponent<Image>();
        lifeGage.fillAmount = 1;

        lifeRedGage = GameObject.Find("LifeRedGage").GetComponent<Image>();
        lifeRedGage.fillAmount = 1;
    }
}