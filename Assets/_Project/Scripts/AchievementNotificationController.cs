using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AchievementNotificationController : MonoBehaviour {

    [SerializeField] Text achievementTitleLabel;

    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void ShowNotification(Achievement achievement)
    {
        achievementTitleLabel.text = achievement.title;
        m_animator.SetTrigger("Appear");
    }	
}

