for i in range(1, 13):
    file = open(fr"C:\Users\Admin\Downloads\Отгадай число\input_s1_{i:02}.txt")
    file2 = open(fr"C:\Users\Admin\Denis\Downloads\Отгадай число\output_s1_{i:02}.txt")
    n = int(file.readline())
    A = []
    for j in range(n+1):
        s = file.readline().split()
        A.append(s)
    A.reverse()
    x_count = 0
    sum_chis = int(A[0][0])
    A.pop(0)
    for a in A:
        if a[0] == "+":
            if a[1] == "x":
                x_count += 1
            else:
                sum_chis -= int(a[1])
        elif a[0] == "-":
            if a[1] == "x":
                x_count -= 1
            else:
                sum_chis += int(a[1])
        elif a[0] == "*":
            sum_chis /= int(a[1])
            x_count /= int(a[1])
    x_count += 1
    answer = round(sum_chis / x_count)
    result = file2.readline()
    print(f"Тест {i}: {answer} {result}")
