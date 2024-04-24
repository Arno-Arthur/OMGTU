class Graph:
    def __init__(self, graph):
        self.graph = graph
        self.V = len(graph)

    def bfs(self, s, t, parent):
        visited = [False] * self.V
        queue = []
        queue.append(s)
        visited[s] = True

        while queue:
            u = queue.pop(0)
            for ind, val in enumerate(self.graph[u]):
                if visited[ind] == False and val > 0:
                    queue.append(ind)
                    visited[ind] = True
                    parent[ind] = u

        return True if visited[t] else False

    def ford_fulkerson(self, source, sink):
        parent = [-1] * self.V
        max_flow = 0

        while self.bfs(source, sink, parent):
            path_flow = float("Inf")
            s = sink
            while (s != source):
                path_flow = min(path_flow, self.graph[parent[s]][s])
                s = parent[s]

            max_flow += path_flow
            v = sink
            while (v != source):
                u = parent[v]
                self.graph[u][v] -= path_flow
                self.graph[v][u] += path_flow
                v = parent[v]

        return max_flow


def read_graph_from_file(filename):
    with open(filename, "r") as f:

        lines = f.readlines()
        if len(lines) < 3:
            raise ValueError("Недостаточно информации")

        N = int(lines[0])
        if N <= 0:
            raise ValueError("Число вершин должно быть положительным")

        graph = [[0] * N for _ in range(N)]

        for line in lines[1:-1]:
            u, v, c = map(int, line.split())
            if 0 <= u <= (N-1) and 0 <= v <= (N-1):
                graph[u][v] = c
            else:
                raise ValueError("Вершин должно быть от 0 до N-1")

        source, sink = map(int, lines[-1].split())
        if not (0 <= source <= (N-1) and 0 <= sink <= (N-1)):
            raise ValueError("Исток и сток должны быть от 0 до N-1")

    return graph, source, sink


while True:
    print(
        "\nМеню"
        "\n1. Постановка задачи"
        "\n2. Рассчитать максимальный поток"
        "\n3. Данные об авторе"
        "\n4. Выйти из программы"
    )

    choice = input("Выберите действие: ")

    if choice == '1':
        print(
            "\nЕсть железнодорожная транспортная сеть."
            "\nНа отдельные компоненты сети  наложены ограничения максимальная допустимая нагрузка."
            "\nНеобходимо определить максимальный поток, который можно перевезти в этой сети между двумя городами"
        )
    elif choice == '2':
        graph, source, sink = read_graph_from_file("input.txt")
        g = Graph(graph)
        max_flow = g.ford_fulkerson(source, sink)
        print(f"\nИсток: {source}"
              f"\nСток: {sink}"
              f"\nМаксимальный поток (алгоритм Форда-Фалкерсона): {max_flow}"
              )
    elif choice == '3':
        print("\nФИО: Репин Артур Александрович"
              "\nГруппа: ФИТ-231")
    elif choice == '4':
        print("\nЗавершение работы...")
        break
    else:
        print("\nНеверный выбор, попробуйте еще раз")
