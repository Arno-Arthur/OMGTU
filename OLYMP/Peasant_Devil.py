N = int(input())
i = 1
s = 0
while (2**i - 1 <= N):
    s += N // (2**i - 1)
    i += 1
print(s)
