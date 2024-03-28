INF = float('inf')

def ford_bellman(graph, start):
    V = len(graph)
    dist = [INF] * V
    dist[start] = 0

    for i in range(V-1):
        for u in range(V):
            for v in range(V):
                if graph[u][v] != INF:
                    if dist[u] + graph[u][v] < dist[v]:
                        dist[v] = dist[u] + graph[u][v]

    for u in range(V):
        for v in range(V):
            if graph[u][v] != INF:
                if dist[u] + graph[u][v] < dist[v]:
                    return "Граф содержит отрицательный цикл"

    return dist

graph = [
    [0, -5, INF, 10],
    [INF, 0, 3, INF],
    [INF, INF, 0, 1],
    [INF, INF, INF, 0]
]

start = 0
result = ford_bellman(graph, start)

for i, d in enumerate(result):
    print(f'Кратчайшее расстояние от вершины {start} до вершины {i} = {d}')
