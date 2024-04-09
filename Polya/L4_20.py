from random import randint

size = 20
numbers = [0] * size

for i in range(size):
    numbers[i] = randint(-100,100)

print(f'Ваш массив: {numbers}')

maximum = max(numbers) #Функция-поиск максимального элемента в массиве

print(f'Максимальный элемент: {maximum}\nЕго индекс: {numbers.index(maximum)}\nЕго порядковый номер: {numbers.index(maximum)+1}')

#Разница между индексом и порядковым номером:
#Индекс от 0 до N, порядковыый номер от 1 до N+1
#В данном случае индекс от 0 до 19, порядковый номер от 1 до 20
#numbers.index(maximum) - индекс максимального числа в массиве numbers
