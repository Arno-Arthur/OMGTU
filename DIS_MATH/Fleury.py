class Graph:
    def __init__(self, vertices):
        self.V = vertices
        self.graph = [[] for _ in range(vertices)]

    def add_edge(self, u, v):
        self.graph[u].append(v)
        self.graph[v].append(u)

    def remove_edge(self, u, v):
        self.graph[u].remove(v)
        self.graph[v].remove(u)

    def dfs_count(self, v, visited):
        count = 1
        visited[v] = True
        for i in self.graph[v]:
            if not visited[i]:
                count = count + self.dfs_count(i, visited)
        return count

    def is_valid_next_edge(self, u, v):
        if len(self.graph[u]) == 1:
            return True
        else:
            visited = [False] * self.V
            count1 = self.dfs_count(u, visited)

            self.remove_edge(u, v)
            visited = [False] * self.V
            count2 = self.dfs_count(u, visited)

            self.add_edge(u, v)
            return count1 <= count2

    def print_euler_util(self, u, path):
        for v in self.graph[u]:
            if self.is_valid_next_edge(u, v):
                path.append(v)
                self.remove_edge(u, v)
                self.print_euler_util(v, path)
                break

    def print_euler_tour(self):
        u = 0
        for i in range(self.V):
            if len(self.graph[i]) % 2 != 0:
                u = i
                break
        path = [u]
        self.print_euler_util(u, path)
        return "-".join(str(node) for node in path)

# Пример использования
g = Graph(4)
g.add_edge(0, 1)
g.add_edge(0, 2)
g.add_edge(1, 2)
g.add_edge(2, 3)
g.add_edge(0, 3)
print(g.print_euler_tour())

# Ответ: 0-1-2-0-3-2
