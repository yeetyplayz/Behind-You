using UnityEngine;

public class pathfindGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject straightXX;
    public GameObject straightZZ;
    public GameObject cornerL;
    public GameObject cornerRL;
    public GameObject cornerR;
    public GameObject cornerRR;
    public GameObject tSectionU;
    public GameObject tSectionD;
    public GameObject tSectionR;
    public GameObject tSectionL;
    public GameObject xSection;

    [Header("Maze Settings")]
    public float cellSize = 4f;

    private string[] maze =
    {
        // . =  <-->
        // ,  = up and down
        // r = a corner from up to the right
        // R = a corner from down to right
        // l = a corner from up to the left
        // L = a corner from down to the left
        // ^ = a T section going up
        // > = a T section to the right
        // < = a T section to the left
        // t = a normal T section
        // x = a X section = +
        "##############################################", // done
        "#R..L###,#,##r.....t.t..t.t.....L##,#,###R..L#", // done 
        "#,##r..tl#>.#,#####,#,##,#,#####,#.<#rt..l##,#", // done 
        "#,#####,##,#####RL###,##,###LR#####,##,#####,#", // done
        "#,#R...^t.^t..t.^^t.tl##rt.t^^.t..t^.t^...L#,#", // done
        "#,#,####,##,##,###,#,####,#,###,##,##,####,#,#", // done
        "#>.l#R.#,##,##r.#Rl#>.##.<#rL#.l##,##,#,L#r.<#", // done
        "#,###,##rL#,#####,##,####,##,#####,#Rl##,###,#", // done 
        "#,#R.<###>.^..#R.l##,####,##r.L#..^.<###>.L#,#", // done
        "#r.l#,#..l#####,###Rl####rL###,#####l..#,#r.l#", // done
        "#####,#####R..#>...<######>...<#..L#####,#####", // done
        "#R...^.###Rl###,###,#R..L#,###,###rL###.^...L#", // done
        "#,######,#,##R.l#,#r.l##r.l#,#r.L##,#,######,#", // done
        "#rt.....l#,##,###,##########,###,##,#r.....tl#", // done
        "##,#######,##,#R.^..L####R..^.L#,##,#######,##", // done
        "#R^.L#.L##,##,#,####rL##Rl####,#,##,##R.#R.^L#", // done
        "#,##,##r..^..l#r..L##,##,##R..l#r.....l##,##,#", // done 
        "#,##,#############,##,##,##,#############,##,#", // done
        "#r.#>.t.#R.......#,##r..l##,#.......L#.t.<#.l#", // done
        "####,#,##,########,########,########,##,#,####", // done
        "#R..l#,#R^........^........^........^L#,#r..L#", // done
        "#,####>t<############################>t<####,#", // done
        "#,####>xxttttttttttttttttttttttttttttxx<####,#", // done
        "#,####>xx^^^^^^^^^^^^^^^^^^^^^^^^^^^^xx<####,#", // done
        "#,####>^<############################>^<####,#", // done
        "#r..L#,#rt........t........t........tl#,#R..l#", // done
        "####,#,##,########,########,########,##,#,####", // done
        "#R.#>.^.#r.......#,##R..L##,#.......l#.^.<#.L#", // done
        "#,##,#############,##,##,##,#############,##,#", // done
        "#,##,##R..t..L#R..l##,##,##r..L#R..t..L##,##,#", // done 
        "#rt.l#.l##,##,#,####Rl##rL####,#,##,##r.#r.tl#", // done
        "##,#######,##,#r.t..l####r..t.l#,##,#######,##", // done
        "#R^.....L#,##,###,##########,###,##,#R.....^L#", // done
        "#,######,#,##r.L#,#R.L##R.L#,#R.l##,#,######,#", // done
        "#r...t.###rL###,###,#r..l#,###,###Rl###.t...l#", // done
        "#####,#####r..#>...l######r...<#..l#####,#####", // done
        "#R.L#,#..L#####,###rL####Rl###,#####R..#,#R.L#", // done
        "#,#r.l###>.t..#r.L##,####,##R.l#..t.<###>.l#,#", // done
        "#,###,##Rl#,#####,##,####,##,#####,#rL##,###,#", // done
        "#>.L#r.#,##,##R.#rL#>.##.<#Rl#.L##,##,#.l#r.<#", // done
        "#,#,####,##,##,###,#,####,#,###,##,##,####,#,#", // done
        "#,#r...t^.t^..^.tt^.^L##R^.^tt.^..^t.^t...l#,#", // done
        "#,#####,##,#####rl###,##,###rl#####,##,#####,#", // done
        "#,##R..^L#>.#,#####,#,##,#,#####,#.<#R^..L##,#", // done
        "#r..l###,#,##r.....^.^..^.^.....l##,#,###r..l#", // done
        "##############################################" // done
    };

    [ContextMenu("Generate Path")]
    void GeneratePath()
    {
        ClearPath();
        for (int y = 0; y < maze.Length; y++)
        {
            for (int x = 0; x < maze[y].Length; x++)
            {
                Vector3 position = new Vector3(
                    x * cellSize,
                    1.25f,
                    -y * cellSize
                );

                if (maze[y][x] == '.') { Instantiate(straightXX, position, Quaternion.identity, transform); }
                if (maze[y][x] == ',') { Instantiate(straightZZ, position, Quaternion.identity, transform); }
                if (maze[y][x] == 'r') { Instantiate(cornerR, position, Quaternion.identity, transform); }
                if (maze[y][x] == 'R') { Instantiate(cornerRR, position, Quaternion.identity, transform); }
                if (maze[y][x] == 'l') { Instantiate(cornerL, position, Quaternion.identity, transform); }
                if (maze[y][x] == 'L') { Instantiate(cornerRL, position, Quaternion.identity, transform); }
                if (maze[y][x] == '^') { Instantiate(tSectionU, position, Quaternion.identity, transform); }
                if (maze[y][x] == 't') { Instantiate(tSectionD, position, Quaternion.identity, transform); }
                if (maze[y][x] == '>') { Instantiate(tSectionR, position, Quaternion.identity, transform); }
                if (maze[y][x] == '<') { Instantiate(tSectionL, position, Quaternion.identity, transform); }
                if (maze[y][x] == 'x') { Instantiate(xSection, position, Quaternion.identity, transform); }
                if (maze[y][x] == '#') { Debug.Log("Im A wall"); }
            }
        }
    }
    [ContextMenu("Clear Path")]
    void ClearPath()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}