matrix = [
    [0, 7, 0, 0, 9, 2, 0, 0, 0, 0, 0, 0], #1 - 2/5/6

    [7, 0, 5, 4, 8, 2, 0, 0, 0, 0, 0, 0], #2 - 1/3/4/5/6

    [0, 5, 0, 2, 9, 0, 0, 0, 0, 0, 0, 0], #3 - 2/4/5

    [0, 4, 2, 0, 3, 0, 8, 3, 0, 0, 0, 0], #4 - 2/3/5/7/8

    [9, 8, 9, 3, 0, 3, 5, 1, 7, 0, 0, 0], #5 - 1/2/3/4/6/7/8/9

    [2, 2, 0, 0, 3, 0, 0, 6, 1, 0, 0, 0], #6 - 1/2/5/8/9

    [0, 0, 0, 8, 5, 0, 0, 6, 0, 4, 4, 0], #7 - 4/5/8/10/11

    [0, 0, 0, 3, 1, 6, 6, 0, 2, 7, 8, 5], #8 - 4/5/6/7/9/10/11/12

    [0, 0, 0, 0, 7, 1, 0, 2, 0, 0, 6, 1], #9 - 5/6/8/11/12

    [0, 0, 0, 0, 0, 0, 4, 7, 0, 0, 10, 0], #10 - 7/8/11

    [0, 0, 0, 0, 0, 0, 4, 8, 6, 10, 0, 3], #11 - 7/8/9/10/12

    [0, 0, 0, 0, 0, 0, 0, 5, 1, 0, 3, 0] #12 - 8/9/11
]


def dijkstra(matrix, start, end):
    n = len(matrix)
    dist = [float('inf')] * n
    dist[start] = 0
    visited = [False] * n
    path = [-1] * n

    for _ in range(n):
        u = min((dist[i], i) for i in range(n) if not visited[i])[1]
        visited[u] = True

        for v in range(n):
            if matrix[u][v] > 0 and not visited[v]:
                if dist[v] > dist[u] + matrix[u][v]:
                    dist[v] = dist[u] + matrix[u][v]
                    path[v] = u


    shortest_path = []
    end_vertex = end - 1
    while end_vertex != -1:
        shortest_path.insert(0, end_vertex)
        end_vertex = path[end_vertex]

    return dist[end - 1], shortest_path


start = int(input("Введите начальную вершину (от 1 до 12): "))
end = int(input("Введите конечную вершину (от 1 до 12): "))

result_dist, result_path = dijkstra(matrix, start - 1, end)

print("Кратчайшее расстояние от вершины", start, "до вершины", end, ":", result_dist)
print("Кратчайший путь:", " -> ".join([str(vertex + 1) for vertex in result_path]))

# Кратчайшее расстояние от вершины 1 до вершины 10 : 12
# Кратчайший путь: 1 -> 6 -> 9 -> 8 -> 10

# Кратчайшее расстояние от вершины 2 до вершины 12 : 4
# Кратчайший путь: 2 -> 6 -> 9 -> 12
