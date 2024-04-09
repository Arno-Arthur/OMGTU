size = int(input("Размер массива (целое число): "))
numbers = [0] * size
for i in range(0, size):
    numbers[i] = float(input(f'Элемент массива {i+1}: ' ))
print(numbers)
