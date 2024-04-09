size = int(input("Размер массива (целое число): "))
numbers = [0] * size
sum = 0

for i in range(size):
    numbers[i] = float(input(f'Элемент массива {i+1}: ' ))
    sum += numbers[i]

print(f'Ваш массив: {numbers}', f'\nCумма элементов массива: {sum}')
