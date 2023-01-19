using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl_sc : MonoBehaviour
{
    bool Pause_control_bool = false;
    bool Level_up_menu_control_bool = false;
    public float Esc_key = 0;
    int SceneIndex;
    int Is_Level_up;

    GameObject BGM;

    public GameObject EnemyPrefab;
    public GameObject Player;

    public GameObject HUD;
    public GameObject PauseMenu;
    public GameObject LevelUpMenu;
    public GameObject DeathMenu;

    // Start is called before the first frame update
    void Start()
    {
        Saver();
        BGM = GameObject.FindGameObjectWithTag("musiki");

        EnemyPrefab.GetComponent<Enemy_sc>().EnemyDamage = 200;
        EnemyPrefab.GetComponent<Enemy_sc>().EnemyHealth = 20;
        EnemyPrefab.GetComponent<Enemy_sc>().speed = 5;

        Scene scene = SceneManager.GetActiveScene();
        SceneIndex = scene.buildIndex;

        Cursor.visible = false;
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
        NextLevel();
    }

    void NextLevel()
    {
        if (Is_Level_up >= 2)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                StartCoroutine(ChangeScene());
            }
        }
    }


    public void PlayerDeath()
    {
        Cursor.visible = !Cursor.visible;
        DeathMenu.GetComponent<Canvas>().enabled = !DeathMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Pause_control_bool = true;
        Time.timeScale = 0.000000000001f;
    }

    void PauseGame()
    {
        Esc_key = Input.GetAxis("Cancel");
        if (Esc_key == 1 && Pause_control_bool == false)
        {
            Cursor.visible = !Cursor.visible;
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
        Esc_key = 0;
        Cursor.visible = !Cursor.visible;
        PauseMenu.GetComponent<Canvas>().enabled = !PauseMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Time.timeScale = 1.0f;
    }
    public void Restart_Buttton()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Back_to_menu()
    {
        Destroy(BGM.gameObject); 
        StartCoroutine(MainMenu());
        Time.timeScale = 1f;
    }
    public void Saver()
    {
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Saved_Game", SceneIndex);
    }
    void Level_up_menu()
    {
        Is_Level_up = GameObject.FindObjectOfType<Fire_sc>().Target_Count;
        if (Is_Level_up > 0 && Is_Level_up % 5 == 0 && Level_up_menu_control_bool == false)
        {
            if (Is_Level_up > 0 && Is_Level_up % 5 == 0)
            {
                EnemyPrefab.GetComponent<Enemy_sc>().EnemyDamage *= 1.25f;
                EnemyPrefab.GetComponent<Enemy_sc>().EnemyHealth *= 1.2f;
                EnemyPrefab.GetComponent<Enemy_sc>().speed *= 1.25f;
            }
            GameObject.FindObjectOfType<NewEnemy_sc>().SecondsToWait = GameObject.FindObjectOfType<NewEnemy_sc>().SecondsToWait / 1.15f;
            LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
            HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
            Cursor.visible = !Cursor.visible;
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
        GameObject.FindObjectOfType<Fire_sc>().Damage = GameObject.FindObjectOfType<Fire_sc>().Damage * 2.0f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Cursor.visible = !Cursor.visible;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        Time.timeScale = 1.0f;
    }
    public void ImproveSpeedFunction()
    {
        GameObject.FindObjectOfType<Player_sc>().speed = GameObject.FindObjectOfType<Player_sc>().speed * 1.15f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Cursor.visible = !Cursor.visible;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        Time.timeScale = 1.0f;
    }
    public void ImproveReloadFunction()
    {
        GameObject.FindObjectOfType<Fire_sc>().ReloadTime_add = GameObject.FindObjectOfType<Fire_sc>().ReloadTime_add / 1.15f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Cursor.visible = !Cursor.visible;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        Time.timeScale = 1.0f;
    }
    public void ImproveMaxHealthFunction()
    {
        GameObject.FindObjectOfType<Player_sc>().MaxSaglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik * 2.0f;
        LevelUpMenu.GetComponent<Canvas>().enabled = !LevelUpMenu.GetComponent<Canvas>().enabled;
        HUD.GetComponent<Canvas>().enabled = !HUD.GetComponent<Canvas>().enabled;
        Cursor.visible = !Cursor.visible;
        GameObject.FindObjectOfType<Player_sc>().saglik = GameObject.FindObjectOfType<Player_sc>().MaxSaglik;
        Time.timeScale = 1.0f;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneIndex + 1);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(3.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
