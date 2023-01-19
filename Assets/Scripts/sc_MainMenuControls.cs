using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sc_MainMenuControls : MonoBehaviour
{
    int SceneInteger;

    public GameObject Player;
    public GameObject EnemyPrefab;
    public GameObject ContinueButon;
    public Slider BGM_Volume;
    public GameObject BGM;
    public GameObject MenuButons;
    public GameObject Settings;
    bool IsSettingsOpen = false;
    public GameObject Loadingg;
    public Fire_sc FireTargetCount;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        FireTargetCount = GameObject.FindObjectOfType<Fire_sc>();
        MenuButons.GetComponent<Canvas>().enabled = true;
        BGM_Volume.value = BGM.GetComponent<AudioSource>().volume;
        Settings.GetComponent<Canvas>().enabled = false;
        Loadingg.GetComponent<Canvas>().enabled = false;
    }
    void Destroybgmf()
    {
        Destroy(BGM.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Saved_Game"))
        {
            ContinueButon.GetComponent<Button>().interactable = true;
        }
        else
        {
            ContinueButon.GetComponent<Button>().interactable = false;
        }

        BGM.GetComponent<AudioSource>().volume = BGM_Volume.value;
    }

    public void SaveLoad()
    {
        SceneInteger = PlayerPrefs.GetInt("Saved_Game");
        Loadingg.GetComponent<Canvas>().enabled = true;
        StartCoroutine(ChangeScene());
    }

    public void SaveReset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SettingsPage()
    {
        if (IsSettingsOpen == false)
        {
            Settings.GetComponent<Canvas>().enabled = true;
            MenuButons.GetComponent<Canvas>().enabled = false;
            IsSettingsOpen = true;
        }
        else if (IsSettingsOpen == true)
        {
            Settings.GetComponent<Canvas>().enabled = false;
            MenuButons.GetComponent<Canvas>().enabled = true;
            IsSettingsOpen = false;
        }

    }
    public void NewGame()
    {
        SceneInteger = 1;
        Loadingg.GetComponent<Canvas>().enabled = true;
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneInteger);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
