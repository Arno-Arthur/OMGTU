from collections import defaultdict

class Graph:
    def __init__(self):
        self.graph = defaultdict(dict)

    def add_edge(self, u, v, w):
        self.graph[u][v] = w
        self.graph[v][u] = 0

    def bfs(self, s, t, parent):
        visited = [False] * len(self.graph)
        queue = []
        queue.append(s)
        visited[s] = True
        
        while queue:
            u = queue.pop(0)
            for v in self.graph[u]:
                if visited[v] == False and self.graph[u][v] > 0:
                    queue.append(v)
                    visited[v] = True
                    parent[v] = u
        return visited[t]

    def ford_fulkerson(self, source, sink):
        parent = [-1] * len(self.graph)
        max_flow = 0
        
        while self.bfs(source, sink, parent):
            path_flow = float('inf')
            s = sink
            while s != source:
                path_flow = min(path_flow, self.graph[parent[s]][s])
                s = parent[s]

            max_flow += path_flow
            v = sink
            while v !=  source:
                u = parent[v]
                self.graph[u][v] -= path_flow
                self.graph[v][u] += path_flow
                v = parent[v]

        return max_flow

g = Graph()
g.add_edge(0, 1, 16)
g.add_edge(0, 2, 13)
g.add_edge(2, 1, 4)
g.add_edge(1, 3, 12)
g.add_edge(2, 4, 14)
g.add_edge(3, 2, 9)
g.add_edge(4, 3, 7)

source = 0
sink = 3

print("Исток:", source)
print("Сток:", sink)
print("Максимальный поток:", g.ford_fulkerson(source, sink))

#Результат:  
#Исток: 0
#Сток: 3
#Максимальный поток: 19
