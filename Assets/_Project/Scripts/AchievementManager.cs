using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour {

    public AchievementDatabase database;

    public AchievementNotificationController achievementNotificationController;

    public AchievementDropdownController achievementDropdownController;

    public GameObject achievementItemPrefab;
    public Transform scrollViewContent;

    public AchievementID achievementToShow;

    [SerializeField][HideInInspector]
    private List<AchievementItemController> achievementItems;

    private void Start()
    {
        achievementDropdownController.onValueChanged += HandleAchievementDropdownValueChanged;
        LoadAchievementsTable();
    }

	public void ShowNotification()
    {
        Achievement achievement = database.achievements[(int)achievementToShow];
        achievementNotificationController.ShowNotification(achievement);
    }

    private void HandleAchievementDropdownValueChanged(AchievementID achievement)
    {
        achievementToShow = achievement;
    }

    [ContextMenu("LoadAchievementsTable()")]
    private void LoadAchievementsTable()
    {
        foreach (AchievementItemController item in achievementItems)
        {
            DestroyImmediate(item.gameObject);
        }
        achievementItems.Clear();
        foreach (Achievement achievement in database.achievements)
        {
            GameObject obj = Instantiate(achievementItemPrefab, scrollViewContent);
            AchievementItemController item = obj.GetComponent<AchievementItemController>();
            bool unlocked = PlayerPrefs.GetInt(achievement.id, 0) == 1;
            item.unlocked = unlocked;
            item.achievement = achievement;
            item.RefreshView();
            achievementItems.Add(item);
        }
    }

    public void UnlockAchievement()
    {
        UnlockAchievement(achievementToShow);
    }

    public void UnlockAchievement(AchievementID achievement) 
    {
        AchievementItemController item = achievementItems[(int)achievement];
        if (item.unlocked)
            return;

        ShowNotification();
        PlayerPrefs.SetInt(item.achievement.id, 1);
        item.unlocked = true;
        item.RefreshView();
    }

    public void LockAllAchievements()
    {
        foreach (Achievement achievement in database.achievements)
        {
            PlayerPrefs.DeleteKey(achievement.id);
        }
        foreach (AchievementItemController item in achievementItems)
        {
            item.unlocked = false;
            item.RefreshView();
        }
    }

}
