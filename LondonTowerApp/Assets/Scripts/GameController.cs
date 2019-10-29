using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int current_level = 0;
    bool is_holding = false;
    bool checking = false;
    Ring current_ring = null;

    [SerializeField]
    private Tower[] towers;
    [SerializeField]
    private Ring[] rings;
    [SerializeField]
    private Level[] levels;

	void Start ()
    {
        setInitialConfig();
	}
	
    void setInitialConfig()
    {
        Level level = levels[current_level];

        Ring[] level_config; Ring ring_object;

        for(int i = 0; i < 3; i++)
        {
            level_config = level.getInitialConfigTower(i);

            for (int j = 0; j < level_config.Length; j++)
            {
                Debug.Log(level_config.Length);

                ring_object = level_config[j];

                if (ring_object.getValue() == rings[0].getValue())
                    rings[0].transform.position = towers[i].getPosition(j).position;
                else if (ring_object.getValue() == rings[1].getValue())
                    rings[1].transform.position = towers[i].getPosition(j).position;
                else if (ring_object.getValue() == rings[2].getValue())
                    rings[2].transform.position = towers[i].getPosition(j).position;
            }

            level_config = null;
            ring_object = null;
        }
    }

    public void advanceLevel()
    {
        current_level++;
        if (current_level >= levels.Length)
            gameClearRoutine();
        else
            setInitialConfig();
    }

    void gameClearRoutine()
    {

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

    public void moveRingUp(Ring target)
    {
        checking = true;

        //MOVE AND WAIT COROUTINES

        is_holding = true;
        checking = false;
    }

    public void moveRingDown(Ring target)
    {
        checking = true;

        //MOVE AND WAIT COROUTINES

        is_holding = false;
        checking = false;
    }
}
