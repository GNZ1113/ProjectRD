using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIManager : MonoBehaviour
{

//    private Player player;
    private Spaceship spaceship;

    public Image lifeGage;
    public Image lifeRedGage;

    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        this.initParameter();
    }

    void Update()
    {
        lifeGage.fillAmount = spaceship.life / spaceship.maxLife;
        lifeRedGage.fillAmount = spaceship.redLife / spaceship.maxLife;
    }

    private void initParameter()
    {
        lifeGage = GameObject.Find("LifeGage").GetComponent<Image>();
        lifeGage.fillAmount = 1;

        lifeRedGage = GameObject.Find("LifeRedGage").GetComponent<Image>();
        lifeRedGage.fillAmount = 1;
    }
}