using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> levels = new List<Level>();
    Level currentLevel;
    public Player player;
    int level=1;
    public void Start()
    {
       LoadLevel();
    }
    public void LoadLevel()
    {
        LoadMap(level);
        Oninit();
    }
    public void LoadMap(int IndexLevel)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levels[IndexLevel -1]);
    }
   
    public void Oninit()
    {
        player.transform.position = currentLevel.startPoint.position;
        player.OnInit();
     
    }
    public void NextLevel()
    {
        level++;
        LoadLevel();
    }
}
