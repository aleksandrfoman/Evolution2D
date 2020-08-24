using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("UI")]
    public Image curHpImage;
    public Text hpText;
    public Text damageText;
    public Text expText;
    public Image curExpImage;
    public Text lvlPlayerText;
    [Header("Характеристики")]
    public int lvlPlayer;
    public float expCurent;
    public float expMax;
    public float hpCurent;
    public float hpMax;
    public float damage;
    public float speed = 3f;

    private void Start()
    {
        curHpImage.fillAmount = hpCurent / hpMax;
        hpText.text = hpCurent.ToString() + " / " + hpMax.ToString();
        damageText.text = "Урон: " + damage.ToString();
        lvlPlayerText.text = "Уровень:" + lvlPlayer.ToString();
        curExpImage.fillAmount = expCurent / expMax;
        expText.text = expCurent.ToString() + " / " + expMax.ToString();
    }

    private void Update()
    {
        damageText.text = "Урон: " + damage.ToString();
    }
    private void FixedUpdate()
    {
        MoveLogic();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(enemy.damageEnemy);
            enemy.TakeDamageEnemy(damage);
            GameController.GOLD += (enemy.goldEnemy * GameController.INCOME);
            AddExp(enemy.expEnemy);
        }
    }

    private Vector2 _movmentVector
    {
        get
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            return new Vector2(horizontal, vertical);
        }
    }
    private void MoveLogic()
    {
        transform.Translate(_movmentVector * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        hpCurent -= damage;
        if (hpCurent <= 0)
        {
            Destroy(gameObject);
        }
        curHpImage.fillAmount = hpCurent/hpMax;
        hpText.text = hpCurent.ToString() + " / " + hpMax.ToString();
    }
    public void AddHp(float hp)
    {
        if(hpCurent!=hpMax)
        hpCurent += hp;
        else
        {
            Debug.Log("MaxHp");
        }
        curHpImage.fillAmount = hpCurent / hpMax;
        hpText.text = hpCurent.ToString() + " / " + hpMax.ToString();

    }
    public void AddExp(float exp)
    {
        expCurent += exp;
        if (expCurent == expMax)
        {
            lvlPlayer++;
            expCurent = 0;
            expMax += 10;
        }
        lvlPlayerText.text = "Уровень:" + lvlPlayer.ToString();
        curExpImage.fillAmount = expCurent/expMax;
        expText.text = expCurent.ToString() + " / " + expMax.ToString();

    }
}
