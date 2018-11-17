using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class AchievementDropdownController : MonoBehaviour {

    private Dropdown m_dropdown;
    private Dropdown Dropdown {
        get {
            if (m_dropdown == null)
            {
                m_dropdown = GetComponent<Dropdown>();
            }
            return m_dropdown;
        }
    }

    public Action<AchievementID> onValueChanged;

    private void Start()
    {
        UpdateOptions();
        Dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
    }

    [ContextMenu("UpdateOptions()")]
    public void UpdateOptions()
    {
        Dropdown.options.Clear();
        var ids = Enum.GetValues(typeof(AchievementID));
        foreach (AchievementID id in ids)
        {
            Dropdown.options.Add(new Dropdown.OptionData(id.ToString()));
        }
        Dropdown.RefreshShownValue();
    }

    private void HandleDropdownValueChanged(int value)
    {
        if (onValueChanged != null)
        {
            onValueChanged((AchievementID)value);
        }
    }

}
