print("Введите число")
k = int(input())
l = 7
m = 10
n = 5
answer = 0

for i in range(k):
    answer += 2 * (l + m + n) + 2 * m * i

print("Если грядок " + str(k) + ", то расстояние = " + str(answer))

print(sum(2 * (l + n) + 2 * m * i for i in range(1, k + 1)))
