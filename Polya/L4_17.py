size = int(input("Размер массива (целое число): "))
numbers = [0] * size

for i in range(size):
    numbers[i] = float(input(f'Элемент массива {i+1}: ' ))

print(f'Ваш массив: {numbers}')
