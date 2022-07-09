using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    const int enemyTypeNum = 2;
    const int catsTypeNum = 10;
    const int starMax = 3;

    public List<GameObject> CatsSelect = new List<GameObject>();
    public List<GameObject> Enemys = new List<GameObject>();
    public List<Spell> Spell = new List<Spell>();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (var enemy in Enemys)
        {
            int enemyType = Random.Range(0, enemyTypeNum);
            enemy.SetActive(true);
            enemy.GetComponent<BasicEnemy>().SpawnEnemy((EnemyType)enemyType);
        }
        foreach (var cat in CatsSelect)
        {
            int catType = Random.Range(0, 3);
            //int catType = Random.Range(0, catsTypeNum);
            int star = Random.Range(0, starMax);
            cat.GetComponent<Cat>().SpawnCat(star, (CatType)catType);
        }
    }

    public void Fight()
    {
        StartCoroutine(FightCoroutine());
    }
    private IEnumerator FightCoroutine()
    {
        if(Spell != null)
        {
        }
        while (CatsSelect != null || Enemys != null)
        {
            foreach (var cat in CatsSelect)
            {
                cat.GetComponent<Cat>().Attack();
                yield return new WaitForSeconds(1f);
            }
            foreach (var enemy in Enemys)
            {
                enemy.GetComponent<BasicEnemy>().Attack();
                yield return new WaitForSeconds(1f);
            }

        }

    }
    private void GameOver()
    {

    }
    private void NextWave()
    {
        foreach (var enemy in Enemys)
        {
            int enemyType = Random.Range(0, enemyTypeNum);
            enemy.SetActive(true);
            enemy.GetComponent<BasicEnemy>().SpawnEnemy((EnemyType)enemyType);
        }
        foreach (var cat in CatsSelect)
        {
            int catType = Random.Range(0, catsTypeNum);
            int star = Random.Range(0, 3);
            cat.GetComponent<Cat>().SpawnCat(star, (CatType)catType);
        }
    }
    public void Reroll()
    {
        foreach (var cat in CatsSelect)
        {
            int catType = Random.Range(0, 3);

            //int catType = Random.Range(0, catsTypeNum);
            int star = Random.Range(0, starMax);
            cat.GetComponent<Cat>().SpawnCat(star, (CatType)catType);
        }
    }
}
