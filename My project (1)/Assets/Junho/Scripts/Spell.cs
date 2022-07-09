using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType{
    //물리 공격
    nail,
    bite,
    //심리 공격
    bark,
    //회피
    jump,
    run,
    //회복
    grooming,
    bread,
    //버프
    sleep,
    scratch,
    //??
    golgol,
    lovely
}
public class Spell : MonoBehaviour
{
    SpellType type;
    public void SpellSlect(SpellType _type)
    {
        type = _type;
    }
    public void SpellAbility()
    {
        switch (type)
        {
            case SpellType.nail:
                GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().Hp -= 60;
                break;
            case SpellType.bite:
                GameManager.Instance.Enemys[0].GetComponent<BasicEnemy>().DotDeal();
                break;
            case SpellType.bark:
                foreach (var enemy in GameManager.Instance.Enemys)
                {
                    enemy.GetComponent<BasicEnemy>().Dmg -= 3;
                }
                break;
            case SpellType.jump:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().miss = true;
                break;
            case SpellType.run:
                foreach (var cat in GameManager.Instance.CatsSelect)
                {
                    cat.GetComponent<Cat>().miss = true;
                }
                break;
            case SpellType.grooming:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Hp += 50;
                break;
            case SpellType.bread:
                foreach (var cat in GameManager.Instance.CatsSelect)
                {
                    cat.GetComponent<Cat>().Hp += 30;
                }
                break;
            case SpellType.sleep:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Dmg += 5;
                break;
            case SpellType.scratch:
                GameManager.Instance.CatsSelect[0].GetComponent<Cat>().Dmg += 10;
                break;
            case SpellType.golgol:
                print("golgol");
                break;
            case SpellType.lovely:
                print("lovely");
                break;
        }
    }
}
