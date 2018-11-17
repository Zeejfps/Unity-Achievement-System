using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour {

    public AchievementManager achievementManager;


    public void MilestoneReached()
    {
        achievementManager.UnlockAchievement(AchievementID.GoodBye);
    }

}
