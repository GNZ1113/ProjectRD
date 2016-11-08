using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIManagerBoss : MonoBehaviour
{

 //   private Enemy enemy;
    private Spaceship spaceship;

    public Image lifeGageE;
    public Image lifeRedGageE;

    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Boss").GetComponent<Spaceship>();
        this.initParameter();
    }

    void Update()
    {
        lifeGageE.fillAmount = spaceship.life / spaceship.maxLife;
        lifeRedGageE.fillAmount = spaceship.redLife / spaceship.maxLife;
    }

    private void initParameter()
    {
        lifeGageE = GameObject.Find("LifeGageE").GetComponent<Image>();
        lifeGageE.fillAmount = 1;

        lifeRedGageE = GameObject.Find("LifeRedGageE").GetComponent<Image>();
        lifeRedGageE.fillAmount = 1;
    }
}