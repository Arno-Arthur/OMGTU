from random import randint #Импорт функции randint

size = 20
numbers = [0] * size

for i in range(size):
    numbers[i] = randint(-100,100) #Элемент i массива = рандомное число в отрезке от -100 до 100

print(f'Ваш массив: {numbers}')
