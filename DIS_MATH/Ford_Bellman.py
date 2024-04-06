INF = float('inf')

def ford_bellman(graph, start):
    V = len(graph)
    dist = [INF] * V
    dist[start] = 0
    prev = [-1] * V

    for i in range(V-1):
        for u in range(V):
            for v in range(V):
                if graph[u][v] != INF:
                    if dist[u] + graph[u][v] < dist[v]:
                        dist[v] = dist[u] + graph[u][v]
                        prev[v] = u
                        
    for u in range(V):
        for v in range(V):
            if graph[u][v] != INF:
                if dist[u] + graph[u][v] < dist[v]:
                    return "Граф содержит отрицательный цикл"
                    
    return dist, prev

def reconstruct_path(prev, start, end):
    path = []
    current = end
    while current != -1:
        path.insert(0, current)
        current = prev[current]
    
    return path

graph = [
    [0, -5, INF, 10],
    [INF, 0, 3, INF],
    [INF, INF, 0, 1],
    [INF, INF, INF, 0]
]

start = 0
distances, predecessors = ford_bellman(graph, start)

for i, d in enumerate(distances):
    if d != INF:
        path = reconstruct_path(predecessors, start, i)
        print(f'Кратчайший путь от вершины {start} до вершины {i}: {" -> ".join(map(str, path))}, расстояние = {d}')
    else:
        print(f'От вершины {start} до вершины {i} нет пути')
