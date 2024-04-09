def floyd_algorithm(graph):
    n = len(graph)
    dist = [row.copy() for row in graph]

    for k in range(n):
        for i in range(n):
            for j in range(n):
                if dist[i][k] != float('inf') and dist[k][j] != float('inf'):
                    dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j])

    return dist

def build_path(start_vertex, end_vertex, dist):
    if dist[start_vertex][end_vertex] == float('inf'):
        return None
    path = [start_vertex]
    while start_vertex != end_vertex:
        for i in range(len(dist)):
            if dist[start_vertex][end_vertex] == dist[start_vertex][i] + dist[i][end_vertex]:
                path.append(i)
                start_vertex = i
    return path

graph = [
    [0, 5, float('inf'), 10],
    [float('inf'), 0, 3, float('inf')],
    [float('inf'), float('inf'), 0, 1],
    [float('inf'), float('inf'), float('inf'), 0]
]

result = floyd_algorithm(graph)

print("Матрица кратчайших путей:")
for row in result:
    print(' '.join(str(elem) if elem != float('inf') else 'inf' for elem in row))

print("\nКратчайшие расстояния")
n = len(result)
for i in range(n):
    for j in range(n):
        if i != j and j != 0:
            path = build_path(i, j, result)
            if path:
                print("От вершины {} до вершины {}: {}, путь: {}".format(i + 1, j + 1, result[i][j],
                                                                         " -> ".join(map(lambda x: str(x+1), path))))
