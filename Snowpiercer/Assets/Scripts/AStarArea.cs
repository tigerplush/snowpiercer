using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum Area
{
    FIRST_CLASS = (1 << 0),
    SECOND_CLASS = (1 << 1),
    THIRD_CLASS = (1 << 2),
}

public class AStarArea : MonoBehaviour
{
    public Rect area;
    public Area permission;

    public Vector3 Center
    {
        get
        {
            Vector3 center = transform.position;
            center.x += area.x + area.width / 2f;
            center.y += area.y + area.height / 2f;
            return center;
        }
    }

    private void Start()
    {
        Register(this);
    }

    public bool Contains(Vector3 point)
    {
        return area.Contains(point - transform.position, true);
    }

    static public List<AStarArea> areas = new List<AStarArea>();
    static public void Register(AStarArea area)
    {
        areas.Add(area);
    }

    static public AStarArea Find(Vector3 point)
    {
        AStarArea area = null;
        foreach (AStarArea testArea in areas)
        {
            if(testArea.Contains(point))
            {
                area = testArea;
                break;
            }
        }

        return area;
    }
}
