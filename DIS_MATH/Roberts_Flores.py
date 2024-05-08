def is_valid(v, pos, path, graph):
    if graph[path[pos - 1]][v] == 0:
        return False
    for vertex in path:
        if vertex == v:
            return False
    return True

def hamiltonian_cycle_util(graph, path, pos, cycles):
    if pos == len(graph):
        if graph[path[pos - 1]][path[0]] == 1:
            cycles.append(path + [path[0]])
            return True
        else:
            return False

    for v in range(1, len(graph)):
        if is_valid(v, pos, path, graph):
            path[pos] = v
            hamiltonian_cycle_util(graph, path[:], pos + 1, cycles)
            path[pos] = -1

def hamiltonian_cycle(graph):
    path = [-1] * len(graph)
    path[0] = 0
    cycles = []

    hamiltonian_cycle_util(graph, path, 1, cycles)

    if not cycles:
        print("Гамильтоновы циклы не существуют")
    else:
        print("Найденные гамильтоновы циклы:")
        for cycle in cycles:
            print(cycle)

graph = [[0, 1, 1, 1, 0, 0, 0],
         [1, 0, 1, 0, 1, 0, 1],
         [1, 1, 0, 1, 1, 1, 1],
         [1, 0, 1, 0, 1, 1, 1],
         [0, 1, 1, 1, 0, 1, 0],
         [0, 0, 1, 1, 1, 0, 1],
         [0, 1, 1, 1, 0, 1, 0]]

hamiltonian_cycle(graph)
