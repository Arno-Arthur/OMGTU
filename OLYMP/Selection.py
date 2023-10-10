n = int(input())
count = 0
if n >= 3:
    p = 1
    while (p <= n / 2):
        p *= 2
        print(p)
    if (n <= p + p/2):
        count = n - p
    else: count = 2 * p - n
print(count)
