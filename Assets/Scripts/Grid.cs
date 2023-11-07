using UnityEngine;

public class Grid
{
    public int m_height;
    public int m_width;
    public float m_cellSize;
    public float m_cellSpacingX;
    public float m_cellSpacingY;
    public Vector3 m_originPosition;
    public bool[,] m_gridArray;

    public Grid(int height, int width, float spacingX,float spacingY, Vector3 originPosition)
    {
        this.m_height = height;
        this.m_width = width;
        this.m_originPosition = originPosition;
        this.m_gridArray = new bool[width, height];
        this.m_cellSpacingX = spacingX;
        this.m_cellSpacingY = spacingY;


        for (int i = 0; i < m_gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < m_gridArray.GetLength(1); j++)
            {
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1),  Color.white ,100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i+1, j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, m_height), GetWorldPosition(m_width, m_height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(m_width, 0), GetWorldPosition(m_width, m_height), Color.white, 100f);


    }

    public Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3 (x*m_cellSpacingX-m_cellSpacingX,  0, y * m_cellSpacingY-m_cellSpacingY) + m_originPosition;
    }


    public void SetValue(int x,int y, bool value)
    {
        if(x>=0 && y >= 0 && x<m_width && y<m_height)
        {
            m_gridArray[x,y] = value;
        }
    } 

    public bool GetValue(int x, int y)
    {
        return m_gridArray[x, y];
    }

}
