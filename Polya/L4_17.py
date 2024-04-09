size = int(input("Размер массива (целое число): ")) #Думаю и так понятно
numbers = [0] * size #Заполняем массив numbers нулями - в количестве size 

for i in range(size): #Для каждого i в диапозоне от 0 до size выполняем
    numbers[i] = float(input(f'Элемент массива {i+1}: ' )) #Элемент i массива numbers вводит пользователь

print(f'Ваш массив: {numbers}') #Вывод массива 
