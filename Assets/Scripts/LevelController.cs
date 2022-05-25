using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Monster[] _monster;
    [SerializeField] string _nextLevelName;

    private void OnEnable()
    {
        
        _monster =FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonsterAreAllDead())
            GoToNextLevel();
    }

   
    void GoToNextLevel()
    {
        Debug.Log("Go to Level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    private bool MonsterAreAllDead()
    {
        foreach (var monster in _monster)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }
}
