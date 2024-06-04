from collections import deque

class Graph:
    def __init__(self, matrix):
        self.matrix = matrix
        self.num_nodes = len(matrix)
    
    def breadth_first_search(self, start_node):
        visited = set()
        queue = deque([start_node])
        visited.add(start_node)
        
        while queue:
            node = queue.popleft()
            print(node + 1, end=' ')  # Выводим номер вершины, начиная с 1
            
            for neighbor, connected in enumerate(self.matrix[node]):
                if connected == 1 and neighbor not in visited:
                    queue.append(neighbor)
                    visited.add(neighbor)
    
    def depth_first_search(self, start_node, visited):
        visited.add(start_node)
        print(start_node + 1, end=' ')  # Выводим номер вершины, начиная с 1
        
        for neighbor, connected in enumerate(self.matrix[start_node]):
            if connected == 1 and neighbor not in visited:
                self.depth_first_search(neighbor, visited)
    
    def dfs(self, start_node):
        visited = set()
        self.depth_first_search(start_node, visited)
        
# Создание графа с матрицей смежности
matrix = [
    [0, 1, 1, 1],
    [1, 0, 0, 1],
    [1, 1, 0, 0],
    [0, 1, 1, 0]
]

graph = Graph(matrix)

print("Поиск в ширину:")
graph.breadth_first_search(0)

print("\nПоиск в глубину:")
graph.dfs(0)

#Результат
#Поиск в ширину:
#1 2 3 4 
#Поиск в глубину:
#1 2 4 3
