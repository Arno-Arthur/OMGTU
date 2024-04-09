from random import randint

size = 10
numbers = [0] * size

for i in range(size):
    numbers[i] = randint(-15,50)

print(f'Ваш несортированный массив: {numbers}')

iterations = size - 1

for i in range (iterations):
    for j in range (iterations - i - 1):
        if numbers[j] > numbers[j+1]:
            numbers[j], numbers[j+1] = numbers[j+1], numbers[j]

print(f'Ваш сортированный массив: {numbers}')
