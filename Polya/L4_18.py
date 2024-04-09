size = int(input("Размер массива (целое число): "))
numbers = [0] * size
sum = 0 #Переменная-сумма

for i in range(size):
    numbers[i] = float(input(f'Элемент массива {i+1}: ' ))
    sum += numbers[i] #Увеличиваем сумму на каждый элемент массива 

print(f'Ваш массив: {numbers}', f'\nCумма элементов массива: {sum}')
