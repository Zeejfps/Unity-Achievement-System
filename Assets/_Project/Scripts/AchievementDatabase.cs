using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Malee;

[CreateAssetMenu()]
public class AchievementDatabase : ScriptableObject {
    [Reorderable(sortable = false, paginate = false)]
    public AchievementsArray achievements;

    [System.Serializable]
    public class AchievementsArray : ReorderableArray<Achievement> { }
}
