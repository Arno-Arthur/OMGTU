print("Введите число")
k = int(input())
l = 7
m = 10
n = 5
answer = 0

for i in range(k):
    answer += 2 * (l + m + n) + 2 * m * i

print("Если грядок " + str(k) + ", то расстояние = " + str(answer))
