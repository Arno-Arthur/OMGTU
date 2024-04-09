from random import randint

size = 15
numbers = [0] * size

for i in range(size):
    numbers[i] = randint(-15,50)

print(f'Ваш несортированный массив: {numbers}')

iterations = size - 1 #Количество итераций(повторений)

for i in range (iterations):
    for j in range (iterations):
        if numbers[j] < numbers[j+1]: #Если элемент 1 меньше элемента 2 - меняем их местами
            numbers[j], numbers[j+1] = numbers[j+1], numbers[j] #То есть сортируем массив в порядке убывания

print(f'Ваш сортированный массив: {numbers}')
