using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ManaPoolVisual : MonoBehaviour {

    public int TestFullSkillPoints;
    public int TestTotalSkillPointsThisTurn;

    private int totalSkillPoints;
    public int TotalSkillPoints
    {
        get{ return totalSkillPoints; }

        set
        {
            //Debug.Log("Changed total mana to: " + value);

            if (value > SkillPoints.Length)
                totalSkillPoints = SkillPoints.Length;
            else if (value < 0)
                totalSkillPoints = 0;
            else
                totalSkillPoints = value;

            for (int i = 0; i < SkillPoints.Length; i++)
            {
                if (i < totalSkillPoints)
                {
                    if (SkillPoints[i].color == Color.clear)
                        SkillPoints[i].color = Color.gray;
                }
                else
                    SkillPoints[i].color = Color.clear;
            }

            // update the text
            ProgressText.text = string.Format("{0}/{1}", availableSkillPoints.ToString(), totalSkillPoints.ToString());
        }
    }

    private int availableSkillPoints;
    public int AvailableSkillPoints
    {
        get{ return availableSkillPoints; }

        set
        {
            //Debug.Log("Changed mana this turn to: " + value);

            if (value > totalSkillPoints)
                availableSkillPoints = totalSkillPoints;
            else if (value < 0)
                availableSkillPoints = 0;
            else
                availableSkillPoints = value;

            for (int i = 0; i < totalSkillPoints; i++)
            {
                if (i < availableSkillPoints)
                    SkillPoints[i].color = Color.white;
                else
                    SkillPoints[i].color = Color.gray;
            }

            // update the text
            ProgressText.text = string.Format("{0}/{1}", availableSkillPoints.ToString(), totalSkillPoints.ToString());

        }
    }
    public Image[] SkillPoints;
    public Text ProgressText;

    
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            TotalSkillPoints = TestTotalSkillPointsThisTurn;
            AvailableSkillPoints = TestFullSkillPoints;
        }
    }
}
