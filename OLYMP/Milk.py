count = int(input()) #количество фирм
result = []
for i in range(0,count):
    package = [float(a) for a in input().split()] #ввод данных

    s1 = 2 * ((package[0] * package[1]) + (package[1] * package[2]) + (package[2] * package[0])) #площадь поверхности 1
    s2 = 2 * ((package[3] * package[4]) + (package[4] * package[5]) + (package[3] * package[5])) #площадь поверхности 2
    v1 = package[0] * package[1] * package[2] / 1000 #объем 1
    v2 = package[3] * package[4] * package[5] / 1000 #объем 2
    price1 = package[6] #цена 1
    price2 = package[7] #цена 2

    milk = (price1 * s2 - price2 * s1) / (v1 * s2 - v2 * s1) #цена молока
    result.append(round(milk,2)) #массив из цен на молоко

factory = result.index(min(result)) + 1 #Номер фирмы
min_price = format(min(result), '.2f') #Минимальная цена на молоко + добавление числовых разрядов после запятой
print(factory,min_price) #итог