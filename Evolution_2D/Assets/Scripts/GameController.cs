using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public static float GOLD = 0;
    [SerializeField]
    public static float INCOME = 1f;
    public Text goldText;
    private void Update()
    {
        goldText.text = "Золото:"+GOLD.ToString();
    }
}
