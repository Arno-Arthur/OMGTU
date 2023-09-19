print("Введите число")
k = int(input())
answer = 0

for i in range(k):
    answer += 44 + 20 * i
    
print("Если грядок " + str(k) + ", то расстояние = " + str(answer))
