using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject floorPrefabSpawnG = null; // ghost spawn
    public GameObject floorPrefabSpawnP = null; // player spawn
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
        "#.####..#!!!!!1!!!!!!!!!!!!!!!!!!!1!!#..####.#",
        "#.####..#!!1!!!!!!!!!!!!!!!!!!!1!!!!!#..####.#",
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
                if (maze[y][x] == '1')
                {
                    Instantiate(floorPrefabSpawnG, position, Quaternion.identity, transform);
                }
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