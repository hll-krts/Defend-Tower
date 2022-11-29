using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fire_sc : MonoBehaviour
{
    public float Target_Count;
    public float MagazineSize;
    public GameObject AmmoCount;
    TextMeshProUGUI AmmoCount_Text;
    public GameObject ScoreText;
    TextMeshProUGUI ScoreText_Text;
    
    public Slider ReloadSlider;
    public GameObject Bullet;
    public GameObject Gun;
    public float FireRat_e;
    public float FireTime;
    public float Damage;
    public float ReloadTime;
    public float ReloadTime_add;
    public bool ReloadControl;
    // Start is called before the first frame update
    void Start()
    {              
        ScoreText_Text = ScoreText.GetComponent<TextMeshProUGUI>();
        ReloadSlider.maxValue = ReloadTime_add;
        ReloadSlider.value = ReloadSlider.maxValue;
        AmmoCount_Text = AmmoCount.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MagazineSize>=1){            
            Fire();
        }
        else{
            //ReloadTime = Time.time + ReloadTime_add;
            Reload();
        }
        AmmoCount_Text.text = MagazineSize.ToString();
    }

    public void Fire(){
        float FireInput = Input.GetAxis("Fire1");
        if(FireInput > 0 && Time.time >= FireTime){
            Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
            FireTime = Time.time + FireRat_e;
            MagazineSize--;
            ReloadTime = Time.time + ReloadTime_add;
        }
    }
    public void Reload(){
        ReloadSlider.value = ReloadTime - Time.time;
        if(Time.time >= ReloadTime){
            MagazineSize = 30;
            ReloadSlider.value = ReloadSlider.maxValue;
        }
    }
    public void Target_Counter(){
        Target_Count++;        
        ScoreText_Text.text = Target_Count.ToString();
    }
}
