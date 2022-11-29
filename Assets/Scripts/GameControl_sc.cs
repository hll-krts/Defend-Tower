using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl_sc : MonoBehaviour
{
    bool Pause_control_bool = false;
    bool Level_up_menu_control_bool = false;
    public float Esc_key = 0;

    public GameObject EnemyPrefab;

    public GameObject HUD;
    public GameObject PauseMenu;
    public GameObject LevelUpMenu;
    public GameObject DeathMenu;
    // Start is called before the first frame update
    void Start()
    {
        EnemyPrefab.GetComponent<Enemy_sc>().EnemyDamage = 10;
        EnemyPrefab.GetComponent<Enemy_sc>().EnemyHealth = 50;
        EnemyPrefab.GetComponent<Enemy_sc>().speed = 6;

        PauseMenu.GetComponent<Canvas>().enabled = false;
        DeathMenu.GetComponent<Canvas>().enabled = false;
        HUD.GetComponent<Canvas>().enabled = true;
        LevelUpMenu.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        Level_up_menu();
    }


    public void PlayerDeath()
    {
        DeathMenu.GetComponent<Canvas>().enabled = !DeathMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Pause_control_bool = true;
        Time.timeScale = 0.000000000001f;
    }

    void PauseGame()
    {
        Esc_key = Input.GetAxis("Cancel");
        Debug.Log(Esc_key);
        if (Esc_key == 1 && Pause_control_bool == false)
        {
            PauseMenu.GetComponent<Canvas>().enabled = !PauseMenu.GetComponent<Canvas>().enabled;
            HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
            Pause_control_bool = true;
            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0.01f;
            }
        }
        else if (Esc_key != 1 && Pause_control_bool == true)
        {
            Esc_key = 0;
            Pause_control_bool = false;
        }
    }
    public void Continue_Button()
    {
        //duraklatma menüsü açıldıktan sonra devam et tuşunun oyunu devam ettirmesi
        Esc_key = 0;
        PauseMenu.GetComponent<Canvas>().enabled = !PauseMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Time.timeScale = 1.0f;
    }
    public void Restart_Buttton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    void Level_up_menu()
    {
        //seviye atlama menüsünü açma ve sonraki seviyeler için ayarlama
        float Is_Level_up = GameObject.FindObjectOfType<Fire_sc>().Target_Count;
        if (Is_Level_up > 0 && Is_Level_up % 5 == 0 && Level_up_menu_control_bool == false)
        {
            if (Is_Level_up > 0 && Is_Level_up % 15 == 0)
            {
                EnemyPrefab.GetComponent<Enemy_sc>().EnemyDamage *= 1.5f;
                EnemyPrefab.GetComponent<Enemy_sc>().EnemyHealth *= 1.2f;
                EnemyPrefab.GetComponent<Enemy_sc>().speed *= 1.5f;
            }
            GameObject.FindObjectOfType<NewEnemy_sc>().SecondsToWait = GameObject.FindObjectOfType<NewEnemy_sc>().SecondsToWait / 1.15f;
            LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
            HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
            Level_up_menu_control_bool = true;
            Time.timeScale = 0.000000000001f;
        }
        if (Is_Level_up % 5 != 0 && Level_up_menu_control_bool == true)
        {
            Level_up_menu_control_bool = false;
        }
    }

    public void ImproveDamageFunction()
    {
        //hasarı %100 artırma
        GameObject.FindObjectOfType<Fire_sc>().Damage = GameObject.FindObjectOfType<Fire_sc>().Damage * 2.0f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        //Level_up_menu_control_bool = true;
        Time.timeScale = 1.0f;
        //Debug.Log(GameObject.FindObjectOfType<Fire_sc>().Damage + "     "+Level_up_menu_control_bool);
    }
    public void ImproveSpeedFunction()
    {
        //hızı %15 artırma
        GameObject.FindObjectOfType<Player_sc>().speed = GameObject.FindObjectOfType<Player_sc>().speed * 1.15f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        //Debug.Log(GameObject.FindObjectOfType<Player_sc>().RotationSpeed + "         "+GameObject.FindObjectOfType<TankMovement>().speed);
        Time.timeScale = 1.0f;
    }
    public void ImproveReloadFunction()
    {
        GameObject.FindObjectOfType<Fire_sc>().ReloadTime_add = GameObject.FindObjectOfType<Fire_sc>().ReloadTime_add / 1.15f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        Time.timeScale = 1.0f;
    }
    public void ImproveMaxHealthFunction()
    {
        GameObject.FindObjectOfType<Player_sc>().MaxSaglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik + 1.0f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        Time.timeScale = 1.0f;
    }
}
