using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Tower_sc : MonoBehaviour
{
    public float TowerHP;
    public GameObject TowerHPText;
    TextMeshProUGUI TowerHP_text;
    // Start is called before the first frame update
    void Start()
    {
        TowerHP_text = TowerHPText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TowerHP < 1){
            GameObject.FindObjectOfType<GameControl_sc>().PlayerDeath();
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            TowerHP -= GameObject.FindObjectOfType<Enemy_sc>().EnemyDamage;
            TowerHP_text.text = TowerHP.ToString();
        }
    }
}
