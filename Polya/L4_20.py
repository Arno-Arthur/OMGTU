from random import randint

size = 20
numbers = [0] * size

for i in range(0, size):
    numbers[i] = randint(-100,100)

print(f'Ваш массив: {numbers}')

maximum = max(numbers)
print(f'Максимальный элемент: {maximum}\nЕго индекс: {numbers.index(maximum)}\nЕго порядковый номер: {numbers.index(maximum)+1}')
