class Graph:

    def __init__(self, graph):
        self.graph = graph
        self.ROW = len(graph)

    def BFS(self, s, t, parent):
        visited = [False] * (self.ROW)
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
                    if ind == t:
                        return True
        return False

    def FordFulkerson(self, source, sink):
        parent = [-1] * (self.ROW)
        max_flow = 0

        while self.BFS(source, sink, parent):
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


graph = [[0, 16, 13, 0, 0, 0],
         [0, 0, 10, 12, 0, 0],
         [0, 4, 0, 0, 14, 0],
         [0, 0, 9, 0, 0, 20],
         [0, 0, 0, 7, 0, 4],
         [0, 0, 0, 0, 0, 0]]

g = Graph(graph)
source = 1
sink = 6

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
        print("Максимальный поток: %d " % g.FordFulkerson(source-1, sink-1))
    elif choice == '3':
        print("\nФИО: Репин Артур Александрович"
              "\nГруппа: ФИТ-231")
    elif choice == '4':
        print("\nЗавершение работы...")
        break
    else:
        print("\nНеверный выбор, попробуйте еще раз")
