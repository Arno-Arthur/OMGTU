answer = 0

for k in range(1,21):
    s = 24 + 20 * k
    print("Расстояние = " + str(s), "Количество грядок = " + str(k))
    answer += s

print("Итоговое расстояние = " + str(answer))