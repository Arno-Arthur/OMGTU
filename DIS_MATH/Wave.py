def li_algorithm(graph, start_vertex, end_vertex):
    visited = [False] * len(graph)
    path = [-1] * len(graph)

    def dfs(vertex):
        visited[vertex] = True
        if vertex == end_vertex:
            return True
        for neighbor in range(len(graph)):
            if graph[vertex][neighbor] == 1 and not visited[neighbor]:
                path[neighbor] = vertex
                if dfs(neighbor):
                    return True
        return False

    if dfs(start_vertex):
        vertex = end_vertex
        print("Искомый путь:")
        while vertex != -1:
            print(vertex, end=" ")
            vertex = path[vertex]
        print()
    else:
        print("Путь не найден")

graph = [[0, 1, 1, 1, 0, 0, 0],
         [1, 0, 1, 0, 1, 0, 1],
         [1, 1, 0, 1, 1, 1, 1],
         [1, 0, 1, 0, 1, 1, 1],
         [0, 1, 1, 1, 0, 1, 0],
         [0, 0, 1, 1, 1, 0, 1],
         [0, 1, 1, 1, 0, 1, 0]]

li_algorithm(graph, 0, 6)
