from random import random, randint
size = 20
numbers = [0] * size

for i in range(0, size):
    numbers[i] = randint(-100,100)

print(f'Ваш массив: {numbers}')
