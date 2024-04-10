using System;
using UnityEngine;

public class ChangePlayerPos : MonoBehaviour
{
    public static Action OnChangePlayerPosFinished;

    [SerializeField] private Transform player;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        Transition.OnFinishedFadeInTransition += MoveToPos;
    }

    private void MoveToPos(int scene)
    {
        if (scene == 0)
        {
            player.position = pos1.position;
            
        }

        if(scene == 1)
        {
            player.position = pos2.position;
        }
        OnChangePlayerPosFinished?.Invoke();
    }


}
