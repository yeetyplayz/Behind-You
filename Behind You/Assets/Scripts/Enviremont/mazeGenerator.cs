using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject floorPrefabSpawnG1;
    public GameObject floorPrefabSpawnG2;
    public GameObject floorPrefabSpawnG3;
    public GameObject floorPrefabSpawnG4;
    public GameObject floorPrefabSpawnP;
    public GameObject cheeseBallPrefab1;

    [Header("Maze Settings")]
    public float cellSize = 4f;

    private string[] maze =
    {
        "##############################################",
        "#....###.#.##....................##.#.###....#",
        "#.##.....#..#.#####.#.##.#.#####.#..#.....##.#",
        "#.#####.##.#####..###.##.###..#####.##.#####.#",
        "#.#...................##...................#.#",
        "#.#.####.##.##.###.#.####.#.###.##.##.####.#.#",
        "#...#..#.##.##..#..#..##..#..#..##.##.#..#...#",
        "#.###.##..#.#####.##.####.##.#####.#..##.###.#",
        "#.#.?.###.....#...##.####.##...#.....###.?.#.#",
        "#...#.#...#####.###..####..###.#####...#.#...#",
        "#####.#####...#.....######.....#...#####.#####",
        "#......###..###.###.#....#.###.###..###......#",
        "#.######.#.##...#.#...##...#.#...##.#.######.#",
        "#........#.##.###.##########.###.##.#........#",
        "##.#######.##.#......####......#.##.#######.##",
        "#....#..##.##.#.####..##..####.#.##.##..#....#",
        "#.##.##.......#....##.##.##....#.......##.##.#",
        "#.##.#############.##.##.##.#############.##.#",
        "#..#....#........#.##....##.#........#....#..#",
        "####.#.##.########.########.########.##.#.####",
        "#....#.#..............................#.#....#",
        "#.####...############################...####.#",
        "#.####..#!!!!!2!!!!!!!!!!!!!!!!!!!4!!#..####.#",
        "#.####..#!!1!!!!!!!!!!!!!!!!!!!3!!!!!#..####.#",
        "#.####...############################...####.#",
        "#....#.#..............................#.#....#",
        "####.#.##.########.########.########.##.#.####",
        "#..#....#........#.##....##.#........#....#..#",
        "#.##.#############.##.##.##.#############.##.#",
        "#.##.##.......#....##.##.##....#.......##.##.#",
        "#....#..##.##.#.####..##..####.#.##.##..#....#",
        "##.#######.##.#......####......#.##.#######.##",
        "#........#.##.###.##########.###.##.#........#",
        "#.######.#.##...#.#...##...#.#...##.#.######.#",
        "#......###..###.###.#....#.###.###..###......#",
        "#####.#####...#.....######.....#...#####.#####",
        "#...#.#...#####.###..####..###.#####...#.#...#",
        "#.#.?.###.....#...##.####.##...#.....###.?.#.#",
        "#.###.##..#.#####.##.####.##.#####.#..##.###.#",
        "#...#..#.##.##..#..#..##..#..#..##.##.#..#...#",
        "#.#.####.##.##.###.#.####.#.###.##.##.####.#.#",
        "#.#...................##...................#.#",
        "#.#####.##.#####..###.##.###..#####.##.#####.#",
        "#.##.....#..#.#####.#.##.#.#####.#..#.....##.#",
        "#....###.#.##....................##.#.###....#",
        "##############################################"
    };

    [ContextMenu("Generate Maze")]
    void GenerateMaze()
    {
        ClearMaze();
        for (int y = 0; y < maze.Length; y++)
        {
            for (int x = 0; x < maze[y].Length; x++)
            {
                Vector3 position = new Vector3(
                    x * cellSize,
                    0,
                    -y * cellSize
                );

                if (maze[y][x] == '.')
                {
                    Instantiate(floorPrefab, position, Quaternion.identity, transform);
                    position.y = 1;
                    Instantiate(cheeseBallPrefab1, position, Quaternion.identity, transform);
                    position.y = 22;
                    //Instantiate(floorPrefab, position, Quaternion .identity, transform);
                }

                if (maze[y][x] == '#')
                {
                    position.y = 11;
                    Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
                if (maze[y][x] == '!')
                {
                    Instantiate(floorPrefab, position, Quaternion.identity, transform);
                    position.y = 22;
                    //Instantiate(floorPrefab, position, Quaternion.identity, transform);
                }
                if (maze[y][x] == '1') { Instantiate(floorPrefabSpawnG1, position, Quaternion.identity, transform); }
                if (maze[y][x] == '2') { Instantiate(floorPrefabSpawnG2, position, Quaternion.identity, transform); }
                if (maze[y][x] == '3') { Instantiate(floorPrefabSpawnG3, position, Quaternion.identity, transform); }
                if (maze[y][x] == '4') { Instantiate(floorPrefabSpawnG4, position, Quaternion.identity, transform); }
                if (maze[y][x] == '?')
                {
                    Instantiate(floorPrefabSpawnP, position, Quaternion.identity, transform);
                }
            }
        }
    }
    [ContextMenu("Clear Maze")]
    void ClearMaze()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}