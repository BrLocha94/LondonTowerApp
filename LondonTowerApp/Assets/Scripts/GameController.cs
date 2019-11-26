using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int current_level = 0;
    bool is_holding = false;
    bool checking = false;
    Ring current_ring = null;

    public WindowManager window_manager;
    public CongratsWindow window_congrats;
    public GameClearWindow window_clear;
    public GameObject block;
    public InputWindow window_input;

    public Transform position_holder;

    [SerializeField]
    private Tower[] towers;
    [SerializeField]
    private Ring[] rings;
    [SerializeField]
    private Level[] levels;

    int movements = 0;
    float time = 0f;
    bool count = false;

	void Start ()
    {
        block.SetActive(true);
        window_input.InTransition();
        //setInitialConfig();
	}

    void Update()
    {
        if(count == true)
        {
            time += Time.deltaTime;
            //Debug.Log("TIME " + time);
        }
    }

    public void startGame()
    {
        block.SetActive(false);
        setInitialConfig();
    }
	
    void setInitialConfig()
    {
        for (int i = 0; i < towers.Length; i++)
        {
            //Debug.Log("Flush tower " + (i + 1) + " data");
            towers[i].FlushData();
        }

        for(int i = 0; i < towers.Length; i++)
        {
            towers[i].DebugConfig();
        }

        //Debug.Log("Current Level " + current_level);
        Level level = levels[current_level];

        Ring[] level_config; Ring ring_object;

        for(int i = 0; i < 3; i++)
        {
            level_config = level.getInitialConfigTower(i);

            for (int j = 0; j < level_config.Length; j++)
            {
                ring_object = level_config[j];

                //Debug.Log("Tower " + (i + 1) + " ring " + ring_object.getValue());

                if (ring_object.getValue() == rings[0].getValue())
                {
                    rings[0].transform.position = towers[i].GetPosition(j).position;
                    towers[i].AddRing(rings[0]);
                }
                else if (ring_object.getValue() == rings[1].getValue())
                {
                    rings[1].transform.position = towers[i].GetPosition(j).position;
                    towers[i].AddRing(rings[1]);
                }
                else if (ring_object.getValue() == rings[2].getValue())
                {
                    rings[2].transform.position = towers[i].GetPosition(j).position;
                    towers[i].AddRing(rings[2]);
                }
            }

            level_config = null;
            ring_object = null;
        }
        
        window_manager.updateHud();

        time = 0f;
        movements = 0;
        count = true;
    }

    void advanceLevel()
    {
        current_level++;
        if (current_level >= levels.Length)
        { 
            StartCoroutine(gameOverRoutine());
        }
        else
        {
            block.SetActive(true);
            window_congrats.InTransition();
        }
    }

    public void AdvanceGame()
    {
        block.SetActive(false);
        is_holding = false;
        checking = false;
        setInitialConfig();
    }

    void gameClearRoutine()
    {
        SoundController.instance().playGameClear();
        advanceLevel();
    }

    IEnumerator gameOverRoutine()
    {
        block.SetActive(true);

        yield return new WaitForSeconds(1f);

        window_clear.InTransition();
    }

    bool checkGameClear()
    {
        Level level = levels[current_level];

        Ring[] level_clear_config; Ring ring_object; Ring ring_tower;

        for (int i = 0; i < 3; i++)
        {
            level_clear_config = level.getRingsTower(i);

            //Debug.Log("Level " + i);

            if (towers[i].GetCurrentRingsCount() != level_clear_config.Length)
            {
                //Debug.Log("Tower " + i + " config is not correct");
                return false;
            }
            else
            {
                for (int j = 0; j < level_clear_config.Length; j++)
                {
                    //Debug.Log("Towers " + j);

                    ring_object = level_clear_config[j];
                    ring_tower = towers[i].GetRing(j);

                    if (ring_object.getValue() != ring_tower.getValue())
                    {
                        //Debug.Log("Diferent ring config");
                        return false;
                    }

                    ring_object = null;
                    ring_tower = null;
                }
            }

            level_clear_config = null;
        }

        Debug.Log("Correct ring config");
        return true;
    }

    public Level getCurrentLevel()
    {
        return levels[current_level];
    }

    public bool getChecking()
    {
        return checking;
    }

    public bool getIsHolding()
    {
        return is_holding;
    }

    public Ring getCurrentRing()
    {
        return current_ring;
    }

    public void setCurrentRing(Ring param)
    {
        current_ring = param;
    }

    public void moveRingUp(Transform pos_target)
    {
        checking = true;

        //Debug.Log("Initiated move up routine");

        StartCoroutine(moveUp(pos_target));
    }

    IEnumerator moveUp(Transform pos_target)
    {
        iTween.MoveTo(current_ring.gameObject, iTween.Hash(
                                               "position", pos_target.position,
                                               "time", 1f));

        SoundController.instance().playMovement();

        yield return new WaitForSeconds(1f);

        iTween.RotateBy(current_ring.gameObject, iTween.Hash(
                                                 "z", 2f,
                                                 "time", 0.5f));

        iTween.MoveTo(current_ring.gameObject, iTween.Hash(
                                               "position", position_holder.position,
                                               "time", 0.5f));

        SoundController.instance().playFlip();

        yield return new WaitForSeconds(0.6f);

        current_ring.gameObject.transform.rotation = Quaternion.identity;

        is_holding = true;
        checking = false;
    }

    public void moveRingDown(Transform pos_target, Transform pos_destiny)
    {
        checking = true;

        movements++;
        //Debug.Log("Initiated mode down routine");

        StartCoroutine(moveDown(pos_target, pos_destiny));
    }

    IEnumerator moveDown(Transform pos_target, Transform pos_destiny)
    {
        iTween.MoveTo(current_ring.gameObject, iTween.Hash(
                                               "position", pos_target.position,
                                               "time", 0.5f));

        iTween.RotateBy(current_ring.gameObject, iTween.Hash(
                                                 "z", 2f,
                                                 "time", 0.5f));

        SoundController.instance().playFlip();

        yield return new WaitForSeconds(0.6f);

        current_ring.gameObject.transform.rotation = Quaternion.identity;

        iTween.MoveTo(current_ring.gameObject, iTween.Hash(
                                               "position", pos_destiny.position,
                                               "time", 1f));

        SoundController.instance().playMovement();

        yield return new WaitForSeconds(1.2f);

        current_ring = null;

        bool result = checkGameClear();

        if (result == true)
        {
            Debug.Log("time and moviments " + time + " " + movements);
            PlayerData.instance().AddStorageItem(time, movements);
            gameClearRoutine();
        }
        else
        {
            is_holding = false;
            checking = false;
        }
    }
}
